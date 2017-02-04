import {
    Component,
    OnInit
} from '@angular/core';

import { AppState } from '../../app.service';
import { MessageService } from '../shared/message.service';

@Component({
    selector: 'messages-list',
    providers: [MessageService],
    templateUrl: 'messages-list.component.html',
    styleUrls: ['messages-list.component.scss']
})

export class MessagesListComponent implements OnInit {
    constructor(public appState: AppState, public messageService: MessageService) {

    }

    public ngOnInit() {
        // this.title.getData().subscribe(data => this.data = data);
    }
}
