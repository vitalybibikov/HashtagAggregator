import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

@Injectable()
export class CanActivateViaAuthGuard implements CanActivate {

  constructor() {}

  canActivate() {
    console.log("Activated root");
    return true;
  }
}
