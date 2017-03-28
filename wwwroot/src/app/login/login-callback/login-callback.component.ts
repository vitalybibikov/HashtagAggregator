import {
  Component, OnInit, OnDestroy
} from '@angular/core';
import {Router} from "@angular/router";
import {AuthService} from "../../shared/services/auth.service";
import {CallbackParseService} from "../callback-parse.service";

@Component({
  selector: 'login-callback',
  styleUrls: ['./login-callback.component.scss'],
  templateUrl: './login-callback.component.html',
  providers: [
    AuthService,
    CallbackParseService
  ],
})

export class LoginCallbackComponent implements  OnInit, OnDestroy{

  constructor(
    private router : Router,
    private authService : AuthService,
    private callbackParse : CallbackParseService) {
  }

  ngOnInit(): void {
    let result : string = this.callbackParse.parseUrl( window.location.hash.substr(1));
    this.saveToken(result);
  }

  ngOnDestroy(): void {
    //this.loginSubscription.unsubscribe();
  }

  private saveToken(token : string): void {
    this.authService.saveToken(token);
    this.router.navigate(["home"])
  }
}
