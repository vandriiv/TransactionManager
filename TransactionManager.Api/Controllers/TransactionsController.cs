using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Application.Transactions.Commands.DeleteTransaction;
using TransactionManager.Application.Transactions.Commands.UpdateTransaction;
using TransactionManager.Application.Transactions.Commands.UpsertTransactions;
using TransactionManager.Application.Transactions.Enums;
using TransactionManager.Application.Transactions.Queries.ExportTransactions;
using TransactionManager.Application.Transactions.Queries.GetTransactions;

namespace TransactionManager.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionsController : BaseApiController
    {
        private readonly ICsvParser _csvParser;

        /// <summary>
        /// 
        /// </summary>
        public TransactionsController(ICsvParser csvParser)
        {
            _csvParser = csvParser;
        }

        /// <summary>
        /// Get transactions list with filtering by TransactionStatus, TransactionType and pagination.
        /// </summary>
        /// <param name="limit">Taken transactions count </param>
        /// <param name="offset">Offset</param>
        /// <param name="status">Transaction status</param>
        /// <param name="type">Transaction type</param>   
        /// <response code="200"></response>       
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int limit, [FromQuery] int offset,
                                                [FromQuery] TransactionStatus? status, [FromQuery] TransactionType? type)
        {
            var transactions = await Mediator.Send(new GetTransactionsQuery
            {
                Limit = limit,
                Offset = offset,
                Status = status,
                Type = type
            });

            return Ok(transactions);
        }

        /// <summary>
        /// Deletes a specific Transaction by id.
        /// </summary>
        /// <param name="id">Transaction id</param>   
        /// <response code="204">Deleted</response>
        /// <response code="404">If the transaction with given id is not exist</response>   
        [HttpDelete("{id:long}")] 
        public async Task<IActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteTransactionCommand { Id = id });

            return NoContent();
        }

        /// <summary>
        /// Update Transaction status.
        /// </summary>
        /// <param name="id">Transaction id</param>
        /// <param name="command">Model which contains Transaction id and TransactionStatus</param>
        /// <response code="204">Transaction updated</response>
        /// <response code="404">If the transaction with given id is not exist</response>   
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateTransactionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Export Transactions,that can being filtered by TransactionStatus and TransactionType, to .csv file.
        /// </summary>
        /// <param name="status">TransactionStatus</param>
        /// <param name="type">TransactionType</param>
        /// <responce code="200">Return file 'Transactions.csv'</responce>
        [HttpGet("[action]")]
        public async Task<FileResult> Export([FromQuery] TransactionStatus? status, [FromQuery] TransactionType? type)
        {
            var exportTransactionsModel = await Mediator.Send(new ExportTransactionsQuery { Status = status, Type = type });

            return File(exportTransactionsModel.Content, exportTransactionsModel.ContentType, exportTransactionsModel.FileName);
        }

        /// <summary>
        /// Import transaction from .csv file and merge them (by TransactionId column)
        /// </summary>
        /// <param name="file">Selected file</param>
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var transactions = _csvParser.ParseStreamToTransactionUpsertModels(file.OpenReadStream());

            await Mediator.Send(new UpsertTransactionsCommand { Transactions = transactions });

            return Ok();
        }
    }
}
