import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TransactionsDashboardComponent } from './transactions-dashboard/transactions-dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: TransactionsDashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransactionRoutingModule { }
