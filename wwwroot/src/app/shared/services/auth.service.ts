import { Injectable } from "@angular/core";
import {AppConfigService} from "./config/app-config.service";
import {StorageService} from "./storage.service";
import {Token} from "../models/token.model";
import {Observable} from "rxjs";
import {JwtHelper} from "angular2-jwt";

@Injectable()
export class AuthService{
  constructor(private configService: AppConfigService,
              private storageService : StorageService,
              private jwtHelper: JwtHelper) {
  }

  public isLoggedIn() : Observable<boolean>{
    return this.storageService.tokenSaved().map(token => this.isAuthorized(token));
  }

  public logOut() {
    let idTokenName = this.configService.getApp<string>("idTokenName");
    let token: Token = this.storageService.getTokenValueByName(idTokenName);
    let authorizationUrl = this.configService.getApp<string>("loginApiEndpoint") + "connect/endsession";

    let url =
      authorizationUrl + '?' +
      'id_token_hint=' + encodeURI(token.value) + '&' +
      'post_logout_redirect_uri=' + encodeURI(location.origin);
    console.log(`logout url: ${url}`);

    this.resetAuthData();
    window.location.href = url;
  }

  public isAuthorized(token : Token): boolean {
    let isAuthorized: boolean = false;
    console.log(`Check: ${token}`);

    let name = this.configService.getApp<string>("accessTokenName");
    if(name === token.name){
      let expired = this.isTokenExpired(token);

      if(token.saved && !expired){
        isAuthorized = true;
      }
      if(expired){
        this.resetAuthData();
      }
    }
    return isAuthorized;
  }

  private isTokenExpired(token: Token, offsetSeconds?: number): boolean {
    let expired : boolean = true;
    offsetSeconds = offsetSeconds || 0;

    if(token != null && token.value != null){
      let expirationDate : Date = this.jwtHelper.getTokenExpirationDate(token.value);
      if (expirationDate == null) {
         expired = true;
      }
      else {
        expired = !(expirationDate.valueOf() > (new Date().valueOf() + (offsetSeconds * 1000)));
      }
    }
    return expired;
  }

  private resetAuthData(){
    let accessTokenName = this.configService.getApp<string>("accessTokenName");
    let idTokenName = this.configService.getApp<string>("idTokenName");

    this.storageService.removeToken(accessTokenName);
    this.storageService.removeToken(idTokenName);
  }
}
