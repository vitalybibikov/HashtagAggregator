import { Inject } from "@angular/core";
import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { AppConfig, APP_CONFIG_TOKEN } from "../../../platform/configuration";
import { Message } from "./models/message"
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";
import { Observable } from "rxjs";
import { AppConfigService } from "../../shared/services/config/app-config.service";

@Injectable()
export class MessageService {

    constructor(public http: Http,
                @Inject(APP_CONFIG_TOKEN) private config: AppConfig,
                private  configService: AppConfigService) {
    }

    public getData(): Observable<Message[]> {
        let hashtag  = this.configService.getApp<string>("hashtag");
        let uri = this.config.apiEndpoint + 'statistics/' + hashtag;
        console.log(uri);
        return this.http.get(uri)
            .map(messages => this.getMappedMessage(messages))
            .share();
    }

    private getMappedMessage(message: any): Message[] {
        let messages = <Message[]>message.json();
        messages.sort((first, second) => first.postDate < second.postDate ? 1 : -1);
        return messages;
    }
}
