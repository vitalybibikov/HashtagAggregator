import { Injectable, Inject } from "@angular/core";
import {Http} from "@angular/http";

@Injectable()
export class AuthService {

  constructor(private http: Http) {
  }

  public getReturnURL() : string {
    let authorizationUrl = 'connect/authorize';
    let client_id = 'statisticsapiclient';
    let redirect_uri = "http://localhost:3000/";
    let response_type = 'id_token token';
    let scope = 'openid profile statisticsapi';
    let nonce = 'N' + Math.random() + '' + Date.now();
    let state = Date.now() + '' + Math.random();

    let url =
      authorizationUrl + '?' +
      'response_type=' + encodeURI(response_type) + '&' +
      'client_id=' + encodeURI(client_id) + '&' +
      'redirect_uri=' + encodeURI(redirect_uri) + '&' +
      'scope=' + encodeURI(scope) + '&' +
      'nonce=' + encodeURI(nonce) + '&' +
      'state=' + encodeURI(state);

    return url;
  }
}
