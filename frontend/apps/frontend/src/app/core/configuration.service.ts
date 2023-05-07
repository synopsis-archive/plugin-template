import { Injectable } from '@angular/core';
import {Configuration} from "../backend";
import {AuthService} from "./auth.service";
import {environment} from "../../environments/environment";
import {SignalRService} from "./signal-r.service";

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {
  private config: Configuration = new Configuration();

  constructor(private authService: AuthService, private signalRHub: SignalRService) {}

  async init(): Promise<void> {
    const token = await this.authService.getToken();
    this.config = new Configuration({
      credentials: {
        'Bearer': token
      },
      basePath: environment.backend
    });
    await this.signalRHub.startConnection();
  }

  getConfig(): Configuration {
    return this.config;
  }
}
