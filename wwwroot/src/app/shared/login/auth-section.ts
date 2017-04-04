import {
  Component,
  OnInit, OnDestroy,
} from '@angular/core';
import {AppState} from "../../app.service";
import {JwtHelper} from "angular2-jwt";
import {AppConfigService} from "../services/config/app-config.service";
import {StorageService} from "../services/storage.service";
import {AuthService} from "../services/auth.service";
import {Subscription} from "rxjs";
import {Token} from "../models/token.model";

@Component({
  selector: 'auth-section',
  templateUrl: 'auth-section.html',
  providers: [JwtHelper, AuthService]
})

export class AuthSectionComponent implements OnInit, OnDestroy {

  public isLoggedIn : boolean = false;
  private loggingSubscription : Subscription;

  constructor(public appState: AppState,
              private jwtHelper : JwtHelper,
              private configService: AppConfigService,
              private storageSerivce : StorageService,
              private authService : AuthService) {
  }

  public ngOnInit(): void {
    console.log("From auth section");
    this.loggingSubscription = this.authService.isLoggedIn().startWith().subscribe(
      x=> {
        this.isLoggedIn = x;
        console.log(`log value: ${x}`);
      });

    let idTokenName = this.configService.getApp<string>("idTokenName");
    let idToken : Token = this.storageSerivce.getTokenValueByName(idTokenName);

    if(idToken != null){
      let jwt = this.jwtHelper.decodeToken(idToken.value);
      console.log(`decoded token: ${jwt}`);
    }
  }

  public ngOnDestroy(): void {
      this.loggingSubscription.unsubscribe();
  }
}
