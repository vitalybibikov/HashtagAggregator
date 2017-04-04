import {
  Component,
  OnInit,
} from '@angular/core';
import {AppState} from "../../../app.service";
import {Token} from "../../models/token.model";
import {StorageService} from "../../services/storage.service";
import {AppConfigService} from "../../services/config/app-config.service";
import {JwtHelper} from "angular2-jwt";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'logined-user',
  styleUrls: ['logined-user.scss'],
  templateUrl: 'logined-user.html',
  providers: [JwtHelper]
})

export class LoginedUserComponent implements OnInit {

  private userName : string;

  constructor(public appState: AppState,
              private storageSerivce : StorageService,
              private configService: AppConfigService,
              private jwtHelper: JwtHelper,
              private authService : AuthService) {
  }

  public ngOnInit(): void {
    let accessTokenName = this.configService.getApp<string>("accessTokenName");
    let accessToken : Token = this.storageSerivce.getTokenValueByName(accessTokenName);

    if(accessToken != null){
      let jwt = this.jwtHelper.decodeToken(accessToken.value);
      this.userName = jwt.name;
      console.log(jwt);
    }
  }

  public logOut() {
     this.authService.logOut();
  }
}
