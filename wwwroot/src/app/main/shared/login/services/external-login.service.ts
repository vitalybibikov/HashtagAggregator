import {Injectable} from "@angular/core";
import {Http, URLSearchParams, Response, RequestOptions} from '@angular/http';
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";
import {Observable} from "rxjs";
import {LoginData} from "../../models/login-data";
import {AppConfigService} from "../../services/config/app-config.service";

@Injectable()
export class ExternalLoginService {

  constructor(public http: Http,
              private configService: AppConfigService) {
  }

  public getExternalLogins(): Observable<LoginData> {
    let uri = this.configService.getApp<string>("loginApiEndpoint") + 'account/login';
    let params = new URLSearchParams();
    params.set('returnUrl',  this.getReturnURL());
    let requestOptions = new RequestOptions();
    requestOptions.search = params;

    return this.http.get(uri, requestOptions)
      .map(data => this.getLogins(data))
      .catch(this.handleError).share();
  }

  public externalLogIn(returnUrl: string, scheme: string): void {
    let url = encodeURIComponent(returnUrl);
    let uri = this.configService.getApp<string>("loginApiEndpoint") + 'account/externallogin/';
    uri = uri + '?' + 'provider='  + encodeURIComponent(scheme)+ '&' + 'returnUrl=' + url;
    window.location.href = uri;
  }

  private getReturnURL() : string {
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
