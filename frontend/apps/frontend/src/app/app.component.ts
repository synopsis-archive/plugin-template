import {Component, OnInit} from '@angular/core';
import {SampleService} from "./backend";
import {switchMap, tap} from "rxjs";
import {SignalRService} from "./core/signal-r.service";
import {HubConnection} from "@microsoft/signalr";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  withoutAuth: boolean = false;
  withAuth: boolean = false;
  databaseRequest: boolean = false;

  hubConnection: HubConnection = null!;

  signalRMessages: string[] = [];
  signalRWithoutAuth: boolean = false;
  signalRWithAuth: boolean = false;

  constructor(private sampleService: SampleService, private signalRService: SignalRService) { }

  async ngOnInit(): Promise<void> {
    this.hubConnection = this.signalRService.getHubConnection();

    this.printDisclaimer();
    this.callRequests();
    await this.initializeSignalRListener();
  }

  getClass(value: boolean): string {
    return value ? 'success' : 'error';
  }

  private printDisclaimer(): void {
    console.log('-'.repeat(100));
    console.info('You\'re running the plugin-template!');
    console.info('Most of the code is just a sample to show how to use the backend API. Feel free to remove it.');
    console.info('Update the hubUrl in the environment files, if you changed the hub path.');
    console.info('If you start the BackendDev-Server, it is available at https://localhost:7226/swagger/index.html');
    console.info('If you have implemented new Endpoints, just call the `apiGen` npm-script in package.json');
    console.log('-'.repeat(100));
  }

  private callRequests(): void {
    this.sampleService.sampleTestGet().pipe(
      tap(() => this.withoutAuth = true),
      switchMap(x => this.sampleService.sampleAuthorizeTestGet()),
      tap(() => this.withAuth = true),
      switchMap(x => this.sampleService.sampleSampleDbRequestGet()),
      tap(() => this.databaseRequest = true)
    ).subscribe()
  }

  private async initializeSignalRListener(): Promise<void> {
    this.hubConnection.on('SendRandomMessage', (message: string) => {
      this.signalRMessages.push(message);
      if (this.signalRMessages.length > 10)
        this.signalRMessages.shift();
    });
    await this.sendSignalRMessage();
    await this.sendSignalRAuthMessage();
  }

  async sendSignalRMessage(): Promise<void> {
    const msg = await this.hubConnection.invoke<string>('Ping');
    this.signalRWithoutAuth = msg === 'Pong!';
  }

  async sendSignalRAuthMessage(): Promise<void> {
    const msg = await this.hubConnection.invoke<string>('PingAuthorized');
    this.signalRWithAuth = msg === 'PongAuthorized!';
  }
}
