import {
    Component,
    OnInit,
    OnDestroy
} from '@angular/core';

import { AppState } from '../../app.service';
import { MessageService } from '../shared/message.service';
import { Message } from '../shared/models/message';
import { Subscription } from "rxjs";

@Component({
    selector: 'messages-list',
    providers: [MessageService],
    templateUrl: 'messages-list.component.html',
    styleUrls: ['messages-list.component.scss']
})

export class MessagesListComponent implements OnInit, OnDestroy {

    private messages: Message[];
    private messageSubscription: Subscription;

    constructor(public appState: AppState, public messageService: MessageService) {

    }

    public ngOnInit() {
        this.messageSubscription = this.messageService.getData()
            .subscribe(
                messages => this.messages = messages
            );
    }

    public ngOnDestroy(): any {
        this.messageSubscription.unsubscribe();
    }
}
