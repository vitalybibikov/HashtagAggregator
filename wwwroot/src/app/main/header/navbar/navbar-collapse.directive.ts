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
      console.log(value);
      this.isExpanded = value;
      this.toggle();
      console.log("here");
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
    this.toggleVariables();
    setTimeout(() => {
      this.height = '0';
      this.isCollapsing = false;
    }, 4);
  }

  private show(): void {
    this.toggleVariables();
    setTimeout(() => {
      this.height = 'auto';
      this.isCollapsing = false;
    }, 4);
  }

  private toggleVariables(): void {
    this.isCollapsing = !this.isCollapsing;
    this.isCollapse = !this.isCollapse;
    this.isExpanded = !this.isExpanded;
    this.isCollapsed = !this.isCollapsed;
  }
}
