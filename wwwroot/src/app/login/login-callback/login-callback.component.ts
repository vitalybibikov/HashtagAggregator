import {
  Component, OnInit
} from '@angular/core';
import {Router} from "@angular/router";
import {StorageService} from "../../shared/services/storage.service";
import {CallbackParseService} from "../callback-parse.service";
import {AppConfigService} from "../../shared/services/config/app-config.service";
import {Token} from "../../shared/models/token.model";

@Component({
  selector: 'login-callback',
  styleUrls: ['./login-callback.component.scss'],
  templateUrl: './login-callback.component.html',
  providers: [
    CallbackParseService
  ],
})

export class LoginCallbackComponent implements  OnInit{

  constructor(
    private router : Router,
    private authService : StorageService,
    private callbackParse : CallbackParseService,
    private appConfigService : AppConfigService) {
  }

  ngOnInit(): void {
    let result : Token[] = this.callbackParse.parseUrl(window.location.hash.substr(1));

     for(let token of result){
       this.saveToken(token);
     }
    this.router.navigate(["home"])
  }

  private saveToken(token : Token): void {
    this.authService.saveToken(token);
  }
}
