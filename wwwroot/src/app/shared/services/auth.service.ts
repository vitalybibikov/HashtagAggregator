import { Injectable } from "@angular/core";
import {Http} from "@angular/http";
import {AppConfigService} from "./config/app-config.service";
import {StorageService} from "./storage.service";
import {Token} from "../models/token.model";
import {Observable} from "rxjs";

@Injectable()
export class AuthService{
  constructor(private http: Http,
              private configService: AppConfigService,
              private storageService : StorageService) {
  }

  public isLoggedIn() : Observable<boolean>{
    return this.storageService.tokenSaved().map(x => this.checkSaved(x));
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

  private resetAuthData(){
    let accessTokenName = this.configService.getApp<string>("accessTokenName");
    let idTokenName = this.configService.getApp<string>("idTokenName");

    this.storageService.removeToken(accessTokenName);
    this.storageService.removeToken(idTokenName);
  }

  private checkSaved(token : Token): boolean{
    console.log(`Check: ${token}`);
    let name = this.configService.getApp<string>("accessTokenName");
    return name === token.name && token.saved;
  }
}
