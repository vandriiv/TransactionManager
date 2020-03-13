import { Transaction } from './transaction';

export interface TransactionsList{
    transactions:Transaction[];
    totalCount:number;
}