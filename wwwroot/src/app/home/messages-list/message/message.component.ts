import {
    Component,
    OnInit,
    Input
} from '@angular/core';

import { AppState } from '../../../app.service';
import { Message } from '../../shared/models/message';
import { MediaType } from '../enums/social-media.enum'

@Component({
    selector: 'message',
    templateUrl: 'message.component.html',
    styleUrls: ['message.component.scss']
})

export class MessageComponent implements OnInit {

    @Input() message: Message;

    constructor(public appState: AppState) {

    }

    public ngOnInit() {
    }
}
