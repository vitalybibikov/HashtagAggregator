import {
  Component,
  OnInit,
  Input, Output
} from '@angular/core';

import {AppState} from '../../../app.service';
import {Message} from '../../shared/models/message';
import {AppConfigService} from '../../../shared/services/config/app-config.service';
import {MediaType} from "../../shared/enums/social-media.enum";

@Component({
  selector: 'message',
  templateUrl: 'message.component.html',
  styleUrls: ['message.component.scss']
})

export class MessageComponent implements OnInit {

  @Input() message: Message;

  private defaultImage = '';
  private offset = 20;

  constructor(public appState: AppState, private configService: AppConfigService) {

  }

  public ngOnInit() {
    let avatarLink: string = this.configService.getApp<string>("defaultAvatar");
    this.defaultImage = avatarLink;
  }

  public getMessageLink(message: Message): string {
    let uri: string = null;

    if (message.mediaType == MediaType.VK) {
      uri = this.configService.getVk<string>("vkMessageUri");
      uri = uri.replace("{user}", message.user.profileId)
        .replace("{userId}", message.user.networkId)
        .replace("{networkId}", message.networkId);
    }
    else {
      uri = this.configService.getTwitter<string>("twitterMessageUri");
      uri = message.user.url;
    }

    console.log(uri);
    return uri;
  }
}
