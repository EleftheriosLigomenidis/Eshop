import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { ShopRoutingModule } from './shop-routing.module';
import { ProductDetailsComponent } from './product-details/product-details.component';

@NgModule({
  imports: [
    CommonModule,
  //  PaginationModule.forRoot()
SharedModule,ShopRoutingModule
    
  ],
  declarations: [ShopComponent,
    ProductItemComponent,ProductDetailsComponent],
  exports: [ShopComponent]
})
export class ShopModule { }
