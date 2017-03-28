import {
  Component,
  OnInit,
  ViewEncapsulation
} from '@angular/core';

import { TranslateService } from 'ng2-translate';
import { AppState } from './app.service';
import {Http, RequestOptionsArgs, Headers} from "@angular/http";

@Component({
  selector: 'app',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['app.component.scss'],
  templateUrl: 'app.component.html',
  providers: [TranslateService]
})
export class AppComponent implements OnInit {
  constructor(public appState: AppState, translate: TranslateService, private http: Http) {
    translate.setDefaultLang('en');
    translate.use('en');
  }

  public ngOnInit() {

  }

  public makeAuthCall(){

    let args = this.processRequestOptions(null, '296338075-QWYKwRyKLvNhW0gTcmSEUXxo8a7rZQhRMXhiST2t');
    this.http.get('http://localhost:5005/api/identity', args).subscribe();

  }

  private  processRequestOptions(options: RequestOptionsArgs, token: string): RequestOptionsArgs {

    if (!options) {
      options = <RequestOptionsArgs> {};
    }

    if (!options.headers) {
      options.headers = new Headers();
    }
    if (options.headers.has("Authorization")) {
      options.headers.delete("Authorization");
    }

    options.headers.append('Content-Type', 'application/json');
    options.headers.append("Authorization", `Bearer ${token}`);
    options.headers.append("Accept", "application/json");

    return options;
  }
}

