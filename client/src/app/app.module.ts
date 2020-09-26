import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, // used for serving content into the browser
    AppRoutingModule, NgbModule // used for routing example  https://www.skinet.gr/products
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
