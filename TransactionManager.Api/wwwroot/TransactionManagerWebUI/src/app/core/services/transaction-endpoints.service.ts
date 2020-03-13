import { Injectable } from '@angular/core';
import { BaseEndpointsService } from './base-endpoints.service';
import { QueryStringParameters } from 'src/app/shared/helpers/query-string-parameters';
import { TransactionStatus } from '../enums/transaction-status';
import { TransactionType } from '../enums/transaction-type';

@Injectable({
  providedIn: 'root'
})
export class TransactionEndpointsService extends BaseEndpointsService  { 

  url:string = "https://localhost:5001/api/transactions";
  
  constructor() {
    super();  
  }

  public getTransactionsEndpoint():string{
    return this.createUrl('');
  }

  public getTransactionsPaginatedEndpoint(offset:number,limit:number,status?:TransactionStatus,type?:TransactionType){
    const qs:QueryStringParameters = new QueryStringParameters();
    qs.push('limit',limit);
    qs.push('offset',offset);

    if(status)
      qs.push('status',status);
    if(type)
      qs.push('type',type);

    return this.createUrlWithQueryParameters('',qs);
  }

  public getUploadFileEndpoint():string{
    return this.createUrl('/upload');
  }

  public getExportFileEndpoint(status?:TransactionStatus,type?:TransactionType):string{
    const qs:QueryStringParameters = new QueryStringParameters();

    if(status)
      qs.push('status',status);
    if(type)
      qs.push('type',type);

    return this.createUrlWithQueryParameters('/export',qs);
  }

  public getDeleteTransactionEndpoint(id:number):string{
    return this.createUrlWithPathVariables('',[id]);
  }

  public getUpdateTransactionEndpoint(id:number):string{
    return this.createUrlWithPathVariables('',[id]);
  }
  
}


