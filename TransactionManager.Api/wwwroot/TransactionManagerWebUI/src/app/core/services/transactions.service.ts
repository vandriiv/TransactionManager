import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { TransactionEndpointsService } from './transaction-endpoints.service';
import { Observable, throwError, of, empty } from 'rxjs';
import {catchError, map } from 'rxjs/operators';
import { Transaction } from '../models/transaction';
import { TransactionStatus } from '../enums/transaction-status';
import { TransactionType } from '../enums/transaction-type';
import { TransactionUpdateModel } from '../models/transaction-update-model';
import { TransactionsList } from '../models/transactions-list';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService{


  constructor(private http:HttpClient, private endpoinsService:TransactionEndpointsService) {     
  }

  getTransactions(offset:number,limit:number,status?:TransactionStatus,type?:TransactionType):Observable<TransactionsList>{
    const url = this.endpoinsService.getTransactionsPaginatedEndpoint(offset,limit,status,type);    
    return this.http.get<TransactionsList>(url).pipe(
      catchError(this.handleError)
    );
  }  

  uploadTransactions(file:FormData) : Observable<any>{
    const url = this.endpoinsService.getUploadFileEndpoint();
    return this.http.post(url, file).pipe(
      catchError(this.handleError)
    );
  }

  updateTransaction(id:number,transaction:TransactionUpdateModel):Observable<any>{
    const url = this.endpoinsService.getUpdateTransactionEndpoint(id);
    return this.http.put(url,transaction).pipe(
      catchError(this.handleError)
    );
  }

  deleteTransaction(id:number):Observable<any>{
    const url = this.endpoinsService.getDeleteTransactionEndpoint(id);
    return this.http.delete(url).pipe(
      catchError(this.handleError)
    );
  }

  exportTransactions(status?:TransactionStatus,type?:TransactionType) : Observable<any>{
    const url = this.endpoinsService.getExportFileEndpoint(status,type);    
    let options : any = {
      observe: "response",
      responseType: "blob",			
      headers: new HttpHeaders({
          "Accept": "application/json"
      })
  };
    return this.http.get(url,options).pipe(
      catchError(this.handleError)
    );    
  }
  

  private handleError(error){    
    if(error.status == 400 || error.status==404){      
      return throwError(error.error);
    }
    else{
      //do log
      console.error("An unexpected error occured");
      return empty();
    } 
  }

}
