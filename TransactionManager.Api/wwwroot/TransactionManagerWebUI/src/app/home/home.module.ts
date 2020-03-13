import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DummyPageComponent } from './dummy-page/dummy-page.component';
import { HomeRoutingModule } from './home-routing.module';



@NgModule({
  declarations: [DummyPageComponent],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
