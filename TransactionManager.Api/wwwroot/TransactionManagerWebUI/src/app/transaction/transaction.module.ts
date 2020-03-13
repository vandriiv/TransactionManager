import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { TransactionsTableComponent } from './transactions-table/transactions-table.component';
import { TransactionsDashboardComponent } from './transactions-dashboard/transactions-dashboard.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { DeleteTransactionModalComponent } from './delete-transaction-modal/delete-transaction-modal.component';
import { EditTransactionModalComponent } from './edit-transaction-modal/edit-transaction-modal.component';
import { TransactionRoutingModule } from './transaction-routing.module';

@NgModule({
  declarations: [
    TransactionsTableComponent, 
    TransactionsDashboardComponent,     
    DeleteTransactionModalComponent,      
    EditTransactionModalComponent],
  imports: [
    TransactionRoutingModule,
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    NgbModule
  ],
  exports: [TransactionsDashboardComponent]
})
export class TransactionModule { }
