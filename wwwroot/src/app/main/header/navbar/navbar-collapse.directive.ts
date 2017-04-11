import {Directive, HostBinding, Input} from "@angular/core";

const SmallestTimeoutPossible : number = 4;

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

  // stale state
  @HostBinding('class.collapse')
  private isCollapse: boolean = true;

  // animation state
  @HostBinding('class.collapsing')
  private isCollapsing: boolean = false;

  @Input()
  private set collapse(value: boolean) {
    this.isExpanded = value;
    this.toggle();
  }

  private get collapse(): boolean {
    return this.isExpanded;
  }

  constructor() {
  }

  public toggle() : void {
    if (this.isExpanded) {
      this.hide();
    } else {
      this.show();
    }
  }

  public hide(): void{
    this.isCollapse = false;
    this.isCollapsing = true;

    this.isExpanded = false;
    this.isCollapsed = true;

    setTimeout(() => {
      this.height = '0';
      this.isCollapse = true;
      this.isCollapsing = false;
    }, SmallestTimeoutPossible);
  }

  public show(): void {
    this.isCollapse = false;
    this.isCollapsing = true;

    this.isExpanded = true;
    this.isCollapsed = false;

    setTimeout(() => {
      this.height = 'auto';

      this.isCollapse = true;
      this.isCollapsing = false;
    }, SmallestTimeoutPossible);
  }
}
