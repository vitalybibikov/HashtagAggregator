import {
    Component,
    OnInit
} from '@angular/core';

import { AppState } from '../../app.service';
import { MessageService } from '../shared/message.service';
import { Message } from '../shared/models/message';

@Component({
    selector: 'messages-list',
    providers: [MessageService],
    templateUrl: 'messages-list.component.html',
    styleUrls: ['messages-list.component.scss']
})

export class MessagesListComponent implements OnInit {

    private messages: Message[];

    constructor(public appState: AppState, public messageService: MessageService) {

    }

    public ngOnInit() {
        this.messageService
            .getData()
            .subscribe(
                messages => this.messages = messages
            );
    }
}
