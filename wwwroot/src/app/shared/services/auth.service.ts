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

  private checkSaved(token : Token): boolean{
    console.log(`Check: ${token}`);
    let name = this.configService.getApp<string>("accessTokenName");
    return name === token.name && token.saved;
  }
}
