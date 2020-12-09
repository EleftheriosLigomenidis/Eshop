import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedComponent } from './shared.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import {PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';

@NgModule({
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot() 
  ],
  exports: [PaginationModule,PagingHeaderComponent,PagerComponent,CarouselModule],
  declarations: [PagingHeaderComponent,PagerComponent]
})
export class SharedModule { }
