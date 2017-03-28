import {Inject} from "@angular/core";
import {Injectable} from "@angular/core";
import {Http, URLSearchParams, Response, RequestOptions} from '@angular/http';
import {AppConfig, APP_CONFIG_TOKEN} from "../../../platform/configuration";
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";
import {Observable} from "rxjs";
import {LoginData} from "../models/login-data";
import {AuthService} from "./auth.service";

@Injectable()
export class ExternalLoginService {

  constructor(public http: Http, @Inject(APP_CONFIG_TOKEN) private config: AppConfig, private authService : AuthService) {
  }

  public getExternalLogins(): Observable<LoginData> {
    let uri = this.config.loginApiEndpoint + 'account/login';
    let params = new URLSearchParams();
    params.set('returnUrl',  this.authService.getReturnURL());
    let requestOptions = new RequestOptions();
    requestOptions.search = params;

    return this.http.get(uri, requestOptions)
        .map(data => this.getLogins(data))
        .catch(this.handleError).share();
  }

  public externalLogIn(returnUrl: string, scheme: string): void {
    let url = encodeURIComponent(returnUrl);
    console.log(url);

    let uri = this.config.loginApiEndpoint + 'account/externallogin/';
    uri = uri + '?' +
      'provider='  + encodeURIComponent(scheme)+ '&' +
      'returnUrl=' + url;
    //connect%2Fauthorize%3Fclient_id%3Dstatisticsapiclient%26redirect_uri%3Dhttp%3A%2F%2Flocalhost%3A5001%2Flogin-callback%26response_type%3Did_token%2520token%26scope%3Dopenid%2520profile%2520statisticsapi%26state%3D14907102064940.09816897976491923%26nonce%3DN0.046676473705870251490710206494
    //"%2Fconnect%2Fauthorize%2Flogin%3Fclient_id%3Dstatisticsapiclient%26redirect_uri%3Dhttp%253A%252F%252Flocalhost%253A3000%26response_type%3Did_token%2520token%26scope%3Dopenid%2520profile%2520statisticsapi%26state%3D13f4c8e9e4724cb1933640490baa2b10%26nonce%3Db27c95beb64a4413bd9932395ee363b7"

    window.location.href = uri;
  }

  private getLogins(data: any): LoginData {
    let login = <LoginData> data.json();
    return login;
  }

  private handleError(error: Response | any) {
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }
}
