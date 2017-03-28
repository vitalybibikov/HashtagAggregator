import {
  Component,
  OnInit,
  Input
} from '@angular/core';

import {AppState} from '../../../app.service';
import {Message} from '../../shared/models/message';
import {AppConfigService} from '../../../shared/services/config/app-config.service';
import {MediaType} from "../../shared/enums/social-media.enum";
import {User} from "../../shared/models/user";


@Component({
  selector: 'message',
  templateUrl: 'message.component.html',
  styleUrls: ['message.component.scss']
})

export class MessageComponent implements OnInit {

  @Input() message: Message;

  constructor(public appState: AppState, private  configService: AppConfigService) {

  }

  public ngOnInit() {
  }

  public getMessageLink(message: Message): string {
    let uri: string = null;
    if (message.mediaType == MediaType.VK) {
      uri = this.configService.get<string>("vkMessageUri");
      uri = uri.replace("{user}", message.user.profileId)
        .replace("{userId}", message.user.networkId)
        .replace("{networkId}", message.networkId);
    }
    else {
      uri = this.configService.get<string>("twitterMessageUri");
      uri = message.user.url;
    }
    console.log(uri);
    return uri;
  }
}
