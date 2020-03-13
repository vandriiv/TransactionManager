import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Transaction } from 'src/app/core/models/transaction';

@Component({
  selector: 'app-transactions-table',
  templateUrl: './transactions-table.component.html',
  styleUrls: ['./transactions-table.component.css']
})
export class TransactionsTableComponent implements OnInit {

  @Input() transactions:Transaction[];
  @Output() onDelete = new EventEmitter<Transaction>();
  @Output() onEdit = new EventEmitter<Transaction>();

  constructor() { }

  ngOnInit(): void {
  }

  deleteButtonClick(transaction:Transaction){    
    this.onDelete.emit(transaction);
  }

  editButtonClick(transaction:Transaction){
    this.onEdit.emit(transaction);
  }

}
