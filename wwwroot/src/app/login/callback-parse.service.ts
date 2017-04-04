import {Injectable} from "@angular/core";
import {Http} from '@angular/http';
import {Token} from "../shared/models/token.model";
import {AppConfigService} from "../shared/services/config/app-config.service";

@Injectable()
export class CallbackParseService {

  constructor(public http: Http, private configService: AppConfigService ) {
  }

  public parseUrl(url : string) : Token[]{

    let tokens: Token [] = null;
    let hash = window.location.hash.substr(1);

    let result: any = hash.split('&').reduce(function(result: any, item: string) {
      let parts = item.split('=');
      result[parts[0]] = parts[1];
      return result;
    }, {});

    console.log('AuthorizedCallback created, begin token validation');

    if (!result.error) {

        let accessToken = new Token();
        accessToken.name = this.configService.getApp<string>("accessTokenName");
        accessToken.value = result.access_token;

      let identityToken = new Token();
      identityToken.name = this.configService.getApp<string>("idTokenName");
      identityToken.value = result.id_token;
      tokens = [ identityToken, accessToken ];
    }
    return tokens;
  }
}
