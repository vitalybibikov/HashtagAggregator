import {
  Component,
  OnInit,
  OnDestroy
} from '@angular/core';

import {AppState} from '../../../app.service';
import {Message} from '../shared/models/message';
import {Subscription, Subject} from "rxjs";
import {MessageService} from "../shared/message.service";
import {SearchService} from "../../shared/services/search.service";
import {User} from "../shared/models/user";

@Component({
  selector: 'messages-list',
  providers: [MessageService],
  templateUrl: 'messages-list.component.html',
  styleUrls: ['messages-list.component.scss']
})

export class MessagesListComponent implements OnInit, OnDestroy {

  private searchMessage: Message;
  private messages: Message[];
  private messageSubscription: Subscription;

  constructor(private appState: AppState,
              private messageService: MessageService,
              private searchService: SearchService) {
  }

  public ngOnInit(): void {

    this.messageSubscription = this.messageService.getData()
      .subscribe(
        messages => this.messages = messages
      );

    this.searchService.searchConfirmed$
      .subscribe(text=> this.fillSearch(text));
  }

  private fillSearch(text: string){
    let message: Message = new Message();
    message.body = text;

    //todo search by user and rewrite to service
    this.searchMessage = message;
  }

  public ngOnDestroy(): void {
    this.messageSubscription.unsubscribe();
  }
}
