import { Injectable } from "@angular/core";
import {Http} from "@angular/http";
import {AppConfigService} from "./config/app-config.service";

@Injectable()
export class AuthService {

  constructor(private http: Http, private configService: AppConfigService) {
  }

  public getReturnURL() : string {
    let clientId = this.configService.getApp<string>("clientId");
    let loginApiEndpoint = this.configService.getApp<string>("loginApiEndpoint");

    let redirect_uri = `${location.origin}/login-callback`;
    let authorizationUrl = '/connect/authorize/login';
    let response_type = 'id_token token';
    let scope = 'openid profile statisticsapi';

    let nonce = 'N' + Math.random() + '' + Date.now();
    let state = Date.now() + '' + Math.random();

    let url =
      authorizationUrl + '?' +
      'client_id=' + encodeURIComponent(clientId) + '&' +
      'redirect_uri=' + encodeURIComponent(redirect_uri) + '&' +
      'response_type=' + encodeURIComponent(response_type) + '&' +
      'scope=' + encodeURIComponent(scope) + '&' +
      'state=' + encodeURIComponent(state) + '&' +
      'nonce=' + encodeURIComponent(nonce);
    return url;
  }

  public saveToken(token : string) : void{
     localStorage.setItem('access_token', token);
     console.log('access_token saved');
  }

  public removeToken() : void{
    localStorage.removeItem('access_token');
  }
}
