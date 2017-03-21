import {Inject} from "@angular/core";
import {Injectable} from "@angular/core";
import {Http, URLSearchParams, Response, RequestOptions} from '@angular/http';
import {AppConfig, APP_CONFIG_TOKEN} from "../../../platform/configuration";
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";
import {Observable} from "rxjs";
import {AppConfigService} from "../../shared/services/app-config.service";
import {LoginData} from "../models/login-data";
import {AuthService} from "./auth.service";

@Injectable()
export class ExternalLoginService {

  constructor(public http: Http, @Inject(APP_CONFIG_TOKEN) private config: AppConfig, private authService : AuthService) {
  }

  public getExternalLogins(): Observable<LoginData> {
    let uri = this.config.loginApiEndpoint + 'account';

    let params = new URLSearchParams();
    params.set('returnUrl',  this.authService.getReturnURL());
    let requestOptions = new RequestOptions();
    requestOptions.search = params;

    return this.http.get(uri, requestOptions)
        .map(data => this.getLogins(data))
        .catch(this.handleError).share();
  }

  public externalLogIn(returnUrl: string, scheme: string): void {
    let uri = this.config.loginApiEndpoint + 'account/externallogin';

    uri = uri + '?' +
      'provider='  + encodeURIComponent(scheme)+ '&' +
      'returnUrl=' + encodeURIComponent(window.location.href);
    console.log(uri);
    window.location.href = uri;
  }

  private getLogins(data: any): LoginData {
    let login = <LoginData>data.json();
    console.log(login);
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
