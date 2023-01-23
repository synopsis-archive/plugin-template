import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule
  ],
  // use environment.backend as reference to the backend URL
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
