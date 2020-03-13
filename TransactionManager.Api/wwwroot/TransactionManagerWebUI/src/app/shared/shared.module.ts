import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './pagination/pagination.component';
import { SelectComponent } from './select/select.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [PaginationComponent, SelectComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule    
  ],
  exports:[PaginationComponent, SelectComponent]
})
export class SharedModule { }
