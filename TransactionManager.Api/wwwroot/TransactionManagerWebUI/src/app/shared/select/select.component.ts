import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-shared-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.css']
})
export class SelectComponent implements OnInit {  
  select:FormControl = new FormControl(); 
  @Input() defaultValue:any;
  @Input() selectName:string;
  @Input() labelValue:string;
  @Input() data:Map<any,string>;

  @Output() onSelectChange = new EventEmitter<string>();  

  constructor() {     
  }

  ngOnInit(): void {
    this.select.setValue(this.defaultValue || this.data.keys().next().value);
  }

  handleChange():void{    
    this.onSelectChange.emit(this.select.value);
  }

}
