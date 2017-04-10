import {
  Component,
  OnInit, OnDestroy,
} from '@angular/core';
import {AppState} from "../../../app.service";
import {AuthService} from "../services/auth.service";
import {Subscription} from "rxjs";


@Component({
  selector: 'auth-section',
  templateUrl: 'auth-section.html'
})

export class AuthSectionComponent implements OnInit, OnDestroy {

  public isLoggedIn : boolean = false;
  private loggingSubscription : Subscription;

  constructor(public appState: AppState,
              private authService : AuthService) {
  }

  public ngOnInit(): void {
    this.loggingSubscription = this.authService.isLoggedIn()
        .subscribe(logged => this.isLoggedIn = logged);
  }

  public ngOnDestroy(): void {
      this.loggingSubscription.unsubscribe();
  }
}
