import { TransactionStatus } from '../enums/transaction-status';

export class TransactionUpdateModel{
    id:number;
    status:TransactionStatus;
}