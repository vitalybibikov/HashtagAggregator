import { NgModule } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { AuthHttp, AuthConfig } from 'angular2-jwt';
import {AppConfigService} from "./services/config/app-config.service";

function authHttpServiceFactory(http: Http, options: RequestOptions, configService: AppConfigService) {
  var tokenName = "id_token";//sessionStorage.getItem(configService.getApp<string>("tokenName"));

  return new AuthHttp(new AuthConfig({
    tokenName: tokenName,
    tokenGetter: (() => tokenName),
    globalHeaders: [
      {
        'Content-Type':'application/json',
        "Accept": "application/json"
      }
      ],
  }), http, options);
}

@NgModule({
  providers: [
    {
      provide: AuthHttp,
      useFactory: authHttpServiceFactory,
      deps: [Http, RequestOptions]
    }
  ]
})
export class AuthModule {

}
