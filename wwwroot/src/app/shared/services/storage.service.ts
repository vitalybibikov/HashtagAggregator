import { Injectable } from "@angular/core";
import {Http} from "@angular/http";
import {AppConfigService} from "./config/app-config.service";
import {Subject, Observable} from "rxjs";
import {Token} from "../models/token.model";

@Injectable()
export class StorageService {

  private tokenTracker = new Subject<Token>();

  constructor(private http: Http, private configService: AppConfigService) {
      console.log("constructor storage");
  }

  public tokenSaved(): Observable<Token> {
    return this.tokenTracker.asObservable().startWith(this.initAuth());
  }

  private initAuth() : Token{
    let name = this.configService.getApp<string>("accessTokenName");
    let token = this.getTokenValueByName(name);
    if(token == null){
        token = new Token();
        token.name = name;
        token.saved = false;
    }
    return token;
    //this.tokenTracker.next(token);
  }

  public saveToken(token : Token) : void{
     localStorage.setItem(token.name, token.value);
     token.saved = true;
     console.log(`${token.name} saved.`);

     this.tokenTracker.next(token);
  }

  public removeToken(name : string) : void{
    let value = localStorage.getItem(name);
    localStorage.removeItem(name);

    let token = new Token();
    token.name= name;
    token.value = value;
    token.saved = false;

    this.tokenTracker.next(token);
    console.log(`${name} removed.`);
  }

  public getTokenValueByName(name : string) : Token{
    let tokenValue = localStorage.getItem(name);
    let token : Token  = null;

    if(tokenValue != null){
      token = new Token();
      token.value = tokenValue;
      token.name = name;
      token.saved = true;
    }
    return token;
  }
}
