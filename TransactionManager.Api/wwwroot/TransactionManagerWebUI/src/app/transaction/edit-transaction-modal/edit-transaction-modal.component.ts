import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { TransactionUpdateModel } from 'src/app/core/models/transaction-update-model';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TransactionStatus } from 'src/app/core/enums/transaction-status';

@Component({
  selector: 'app-edit-transaction-modal',
  templateUrl: './edit-transaction-modal.component.html',
  styleUrls: ['./edit-transaction-modal.component.css']
})
export class EditTransactionModalComponent implements OnInit {

  @Input() transaction:TransactionUpdateModel;

  transactionStatuses:Map<any,string> = new Map([  
    [TransactionStatus.Pending,"Pending"],
    [TransactionStatus.Completed,"Completed"],
    [TransactionStatus.Cancelled,"Cancelled"]
  ]);

  editForm = new FormGroup({
    id:new FormControl(''),
    status:new FormControl('')
  });

  constructor(private activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    this.editForm.patchValue({
      id:this.transaction.id,
      status:this.transaction.status
    });
  }

  cancel(){
    this.activeModal.dismiss(false);
  }

  confirm(){    
    this.activeModal.close(this.editForm.value);
  }

}
