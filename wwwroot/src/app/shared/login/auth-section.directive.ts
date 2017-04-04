import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[auth-host]',
})
export class AuthSectionDirective {
  constructor(public viewContainerRef: ViewContainerRef) {

  }
}
