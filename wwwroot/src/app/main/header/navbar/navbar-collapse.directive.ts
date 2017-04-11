import {Directive, HostBinding, Input} from "@angular/core";

@Directive({selector: '[collapse]'})
export class Collapse {

  // style
  @HostBinding('style.height')
  private height: string;

  // shown
  @HostBinding('class.in')
  @HostBinding('attr.aria-expanded')
  private isExpanded: boolean = true;

  // hidden
  @HostBinding('attr.aria-hidden')
  private isCollapsed: boolean = false;

  //stale state
  @HostBinding('class.collapse')
  private isCollapse: boolean = true;

  // animation state
  @HostBinding('class.collapsing')
  private isCollapsing: boolean = false;

  @Input()
  private set collapse(value: boolean) {
    if (value !== undefined) {
      this.isExpanded = value;
      this.toggle();
    }
    else{
      this.isExpanded = false;
      this.hide();
    }
  }

  private get collapse(): boolean {
    return this.isExpanded;
  }

  constructor() {
  }

  private toggle(): void {
    if (!this.isExpanded) {
      this.hide();
    } else {
      this.show();
    }
  }

  private hide(): void {
    this.isCollapse = true;
    this.isExpanded = false;
    this.isCollapsed = true;
  }

  private show(): void {
    this.isCollapse = false;
    this.isExpanded = true;
    this.isCollapsed =  false;
  }
}
