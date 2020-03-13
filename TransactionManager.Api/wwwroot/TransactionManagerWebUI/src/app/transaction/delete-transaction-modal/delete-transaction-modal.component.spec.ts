import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTransactionModalComponent } from './delete-transaction-modal.component';

describe('DeleteTransactionModalComponent', () => {
  let component: DeleteTransactionModalComponent;
  let fixture: ComponentFixture<DeleteTransactionModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteTransactionModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteTransactionModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
