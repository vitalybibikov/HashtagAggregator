import {
  Component,
  OnInit,
  ViewEncapsulation
} from '@angular/core';

import { TranslateService } from 'ng2-translate';
import { AppState } from './app.service';

@Component({
  selector: 'app',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['app.component.scss'],
  templateUrl: 'app.component.html',
  providers: [TranslateService]
})
export class AppComponent implements OnInit {
  constructor(public appState: AppState, translate: TranslateService) {
    translate.setDefaultLang('en');
    translate.use('en');
  }

  public ngOnInit() {

  }
}