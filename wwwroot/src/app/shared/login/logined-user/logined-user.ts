import {
  Component,
  OnInit,
} from '@angular/core';
import {AppState} from "../../../app.service";

@Component({
  selector: 'logined-user',
  styleUrls: ['logined-user.scss'],
  templateUrl: 'logined-user.html'
})

export class LoginedUserComponent implements OnInit {

  constructor(public appState: AppState) {
  }

  public ngOnInit(): void {
  }

  public send(returnUrl: string, scheme: string) {
  }
}
