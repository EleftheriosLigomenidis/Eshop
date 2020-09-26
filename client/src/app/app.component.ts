import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {IPagination} from './models/pagination';
import { IProduct } from './models/product';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private http:HttpClient){

  }

  ngOnInit(){
    // lifecycle hook
    this.http.get('https://localhost:44389/api/products').subscribe((response:IPagination) =>{
      this.products = response.data;
    },error =>{
      console.log(error);
    })
  }
  title = 'Skinet';
  products: IProduct[];
}
