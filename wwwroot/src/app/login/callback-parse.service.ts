import {Injectable} from "@angular/core";
import {Http} from '@angular/http';

@Injectable()
export class CallbackParseService {

  constructor(public http: Http) {
  }

  public parseUrl(url : string){

    let token = '';
    let id_token = '';
    let hash = window.location.hash.substr(1);

    let result: any = hash.split('&').reduce(function(result: any, item: string) {
      let parts = item.split('=');
      result[parts[0]] = parts[1];
      return result;
    }, {});

    console.log('AuthorizedCallback created, begin token validation');

    if (!result.error) {

        token = result.access_token;
        id_token = result.id_token;

        let dataIdToken: any = this.getDataFromToken(id_token);
        console.log(`access_token: ${token}`);
        console.log(`id_token: ${id_token}`);
        console.log(dataIdToken);
    }
    return token;
  }

  private getDataFromToken(token: any) {
    let data = {};
    if (typeof token !== 'undefined') {
      let encoded = token.split('.')[1];
      data = JSON.parse(atob(encoded));
    }
    return data;
  }
}
