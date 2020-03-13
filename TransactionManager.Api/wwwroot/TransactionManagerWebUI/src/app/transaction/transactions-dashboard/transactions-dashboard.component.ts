import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TransactionsService } from 'src/app/core/services/transactions.service';
import { TransactionType } from 'src/app/core/enums/transaction-type';
import { TransactionStatus } from 'src/app/core/enums/transaction-status';
import { Transaction } from 'src/app/core/models/transaction';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DeleteTransactionModalComponent } from '../delete-transaction-modal/delete-transaction-modal.component';
import { TransactionUpdateModel } from 'src/app/core/models/transaction-update-model';
import { EditTransactionModalComponent } from '../edit-transaction-modal/edit-transaction-modal.component';

@Component({
  selector: 'app-transactions-dashboard',
  templateUrl: './transactions-dashboard.component.html',
  styleUrls: ['./transactions-dashboard.component.css']
})
export class TransactionsDashboardComponent implements OnInit {
 
  constructor(private transactionsService:TransactionsService, private modalService:NgbModal) { }

  transactions:Transaction[];
  page:number=1;
  limit:number=10; 
  total:number=0;

  uploadDataTypeError:any=null;
  uploadDataFormatError:any=null;
  
  statusFilter?:TransactionStatus;
  typeFilter?:TransactionType;

  transactionStatuses:Map<any,string> = new Map([
    [0,"Status"],
    [TransactionStatus.Pending,"Pending"],
    [TransactionStatus.Completed,"Completed"],
    [TransactionStatus.Cancelled,"Cancelled"]
  ]);

  transactionTypes:Map<any,string> = new Map([
    [0,"Type"],
    [TransactionType.Refill,"Refill"],
    [TransactionType.Withdrawal,"Withdrawal"]   
  ]);

  fileImport:FormControl = new FormControl('');  

  ngOnInit(): void {
    this.getTransactions();
  }
  

  getTransactions():void{
    let offset = (this.page-1)*this.limit;
    this.transactionsService.getTransactions(offset,this.limit,this.statusFilter,this.typeFilter).subscribe(res=>{
      this.transactions = res.transactions;
      this.total = res.totalCount;
    });
  }

  openDeleteTransactionModal(transaction:Transaction):void{
    const modalRef = this.modalService.open(DeleteTransactionModalComponent,
      {
        scrollable: true,       
        keyboard: true       
      });
      
      modalRef.componentInstance.transaction = transaction;

      modalRef.result.then(()=>{
        this.deleteTransaction(transaction.id);
      })
      .catch(()=>{});
  }

  deleteTransaction(id:number){
    this.transactionsService.deleteTransaction(id)
    .subscribe(()=>this.getTransactions());
  }

  openEditTransactionModal(transaction:Transaction){
    let transactionUpsertModel = new TransactionUpdateModel();
    transactionUpsertModel.id =transaction.id;
    transactionUpsertModel.status =(<any>TransactionStatus)[transaction.status];

    const modalRef = this.modalService.open(EditTransactionModalComponent,
      {
        scrollable: true,       
        keyboard: true       
      });
      
      modalRef.componentInstance.transaction = transactionUpsertModel;

      modalRef.result.then(updatedTransaction=>{      
        this.updateTransaction(updatedTransaction);
      })
      .catch(e=>{});
  }

  updateTransaction(updatedTransaction:TransactionUpdateModel){
    this.transactionsService.updateTransaction(updatedTransaction.id,updatedTransaction)
    .subscribe(()=>this.getTransactions());
  }
  
  statusSelectChanged(value:TransactionStatus):void{
    this.statusFilter=value;
    this.getTransactions();
  }

  typeSelectChanged(value:TransactionType):void{
    this.typeFilter=value;
    this.getTransactions();
  }

  goToPrevious(): void {   
    this.page--;
    this.getTransactions();
  }

  goToNext(): void {   
    this.page++;
    this.getTransactions();
  }

  goToPage(n: number): void {
    this.page = n;
    this.getTransactions();
  }
  
  openFileDialog():void{    
    let importFileInput: HTMLElement = document.querySelector('#transactions-file-import') as HTMLElement;
    importFileInput["value"] = '';  
    importFileInput.click();
  }

  uploadFile(event):void{
    if (event.target.files.length === 0) {
      return;
    }
 
    let fileToUpload = <File>event.target.files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);  

    this.uploadDataTypeError = null;
    this.uploadDataFormatError = null;

    this.transactionsService.uploadTransactions(formData)
      .subscribe(()=>{       
        this.resetPagination();
        this.getTransactions();               
      }
      ,error=>{
        console.log(error);
        if(error.failures){
          this.uploadDataFormatError = error;
        }
        else{
          this.uploadDataTypeError = error;
        }
      });
  }

  resetPagination():void{
    this.page=1;
    this.total=0;
  }

  exportFile():void{
    this.transactionsService.exportTransactions(this.statusFilter,this.typeFilter).subscribe((res:any)=>{    
      let blob = new Blob([res.body],{
       type:'text/csv'
      });
      var a = document.createElement("a");
      a.href = URL.createObjectURL(blob); 
      a.download = "Transactions.csv";
      a.click();
    });
  }
}
