import { Component, OnInit, Input } from '@angular/core';
import { Transaction } from 'src/app/core/models/transaction';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-delete-transaction-modal',
  templateUrl: './delete-transaction-modal.component.html',
  styleUrls: ['./delete-transaction-modal.component.css']
})
export class DeleteTransactionModalComponent implements OnInit {

  @Input() transaction:Transaction;
  constructor(private activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  cancel(){
    this.activeModal.dismiss(false);
  }

  confirm(){
    this.activeModal.close(true);
  }
}
