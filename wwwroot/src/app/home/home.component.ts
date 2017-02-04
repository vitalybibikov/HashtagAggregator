import {
  Component,
  OnInit
} from '@angular/core';

import { AppState } from '../app.service';
import { MessageService } from './shared/message.service';

@Component({
  selector: 'home',
  providers: [
    MessageService
  ],
  styleUrls: ['./home.component.scss'],
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  public localState = { value: '' };

  constructor(public appState: AppState, public messageService: MessageService) {

  }

  public ngOnInit() {
    // this.title.getData().subscribe(data => this.data = data);
  }

  public submitState(value: string) {
    this.appState.set('value', value);
    this.localState.value = '';
  }
}
