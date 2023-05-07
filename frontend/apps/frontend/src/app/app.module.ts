import {APP_INITIALIZER, NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {ApiModule, Configuration} from './backend';
import {HttpClientModule} from '@angular/common/http';
import {ConfigurationService} from "./core/configuration.service";

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, ApiModule, HttpClientModule],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: (configService: ConfigurationService) => () => configService.init(),
      deps: [ConfigurationService],
      multi: true
    },
    {
      provide: Configuration,
      useFactory: (configService: ConfigurationService) => configService.getConfig(),
      deps: [ConfigurationService],
      multi: false
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
