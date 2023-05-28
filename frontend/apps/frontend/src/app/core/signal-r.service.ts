import {Injectable} from '@angular/core';
import {HttpTransportType, HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: HubConnection | undefined;

  async startConnection(token: string): Promise<void> {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(
        `${environment.backend}/${environment.hubUrl}`,
        {
          //TODO: Negotiation should not be skipped anymore, therefore CORS needs to be configured correctly
          //TODO: Remove this workaround
          skipNegotiation: true,
          transport: HttpTransportType.WebSockets,

          accessTokenFactory: () => token
        }
      )
      .build();

    await this.hubConnection.start();
  }

  getHubConnection(): HubConnection {
    if(this.hubConnection === undefined)
      throw new Error('HubConnection is not initialized');
    return this.hubConnection;
  }
}
