import { Injectable, Inject } from "@angular/core";
import { APP_CONFIG_TOKEN, AppConfig } from "../../../platform/configuration";
import {Http} from "@angular/http";

@Injectable()
export class AuthService {

  constructor(private http: Http,  @Inject(APP_CONFIG_TOKEN) private config: AppConfig) {
  }

  public getReturnURL() : string {

    console.log('Begin authorize');

    let authorizationUrl = '/connect/authorize';
    let client_id = 'StatisticsAPI';
    let redirect_uri = this.config.apiEndpoint + 'signin-external';
    let response_type = 'id_token';
    let scope = 'openid profile';
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
