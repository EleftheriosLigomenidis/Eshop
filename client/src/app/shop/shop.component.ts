import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import { ShopService } from './shop.service';
import {ShopParams} from '../shared/models/shopParams';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
products: IProduct [];
@ViewChild('search',{static:false}) searchterm : ElementRef; // it does no rely on a dynamic activity
// Viewchild runs a query to the dom to get an element
// variable searchTerm of type ElementRef
brands: IBrand[];
productTypes: IProductType[];
shopParams = new ShopParams();
totalCount: number;
sortOptions = [
  {name: 'Alphabetical', value: 'name'},
  {name: 'Price:Low to High', value: 'priceAsc'},
  {name: 'Price:High to Low', value: 'priceDesc'}
];

  constructor(private shopService: ShopService) { }

  ngOnInit() {
this.getProducts();

this.getBrands();
this.getProductTypes();
  }
getProducts(){
  this.shopService.
  getProducts(this.shopParams)
 .subscribe(response =>{

    this.products = response.data;
    this.shopParams.pageNumber = response.pageIndex;
    this.shopParams.pageSize = response.pageSize;
    this.totalCount = response.count;
  }, error => {
    console.log(error);
  });
}

getBrands(){
  this.shopService.getBrands().subscribe(response  => {
    this.brands = [{id: 0, name: 'All'}, ...response];  // ====>  it just adds an object to the front of the array 
  }, error => {
    console.log(error);
  });
}


getProductTypes(){
  this.shopService.getProductTypes().subscribe(response  => {
    this.productTypes = [{id: 0, name: 'All'}, ...response];
  }, error => {
    console.log(error);
  });
}

onBrandSelected(brandId: number){
 this.shopParams.brandId = brandId;
 this.shopParams.pageNumber = 1;
 this.getProducts();
}

onTypeSelected(typeId: number){
  this.shopParams.typeId = typeId;
  this.shopParams.pageNumber = 1;
  this.getProducts();
 }


 onSortSelected(sort: string){
   this.shopParams.sort = sort;
   this.getProducts();
 }

 onSearch(){
   this.shopParams.search = this.searchterm.nativeElement.value;
   this.shopParams.pageNumber = 1;
   this.getProducts();
 }

 onReset(){
   this.searchterm.nativeElement.value = '';
   this.shopParams = new ShopParams();
   this.getProducts();
 }

 onPageChanged(event: any){
   if( this.shopParams.pageNumber !== event){
    this.shopParams.pageNumber = event;
    this.getProducts();
   }

}
}
