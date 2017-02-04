import { Inject } from "@angular/core";
import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";
import { Observable } from "rxjs";
import { Response, ResponseContentType } from "@angular/http";
import { AppConfig, APP_CONFIG_TOKEN } from "../../../platform/configuration";
import { Message } from "./models/message"

@Injectable()
export class MessageService {

    constructor(private http: Http, @Inject(APP_CONFIG_TOKEN) private config: AppConfig) {

    }

    public getData(): Observable<Message[]> {
        return this.http.get(this.config.apiEndpoint + 'statistics/microsoft')
            .map(x => x.json())
            .share();
    }
}
