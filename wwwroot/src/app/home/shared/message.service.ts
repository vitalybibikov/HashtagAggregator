import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class MessageService {

    constructor(public http: Http) {

    }

    public getData() {
        return {
            value: 'AngularClass'
        };
    }
}
