import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  imports: [
    CommonModule,
  //  PaginationModule.forRoot()
SharedModule
    
  ],
  declarations: [ShopComponent,
    ProductItemComponent],
  exports: [ShopComponent]
})
export class ShopModule { }
