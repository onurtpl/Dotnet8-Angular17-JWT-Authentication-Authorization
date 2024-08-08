import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appDropdown]',
  standalone: true
})
export class DropdownDirective {

  private isOpen = false;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  @HostListener('click') toggleOpen() {
    this.isOpen = !this.isOpen;
    const dropdownMenu = this.el.nativeElement.querySelector('.dropdown-menu');
    if (this.isOpen) {
      this.renderer.setStyle(dropdownMenu, 'display', 'block');
    } else {
      this.renderer.setStyle(dropdownMenu, 'display', 'none');
    }
  }

  @HostListener('document:click', ['$event.target']) close(targetElement: EventTarget) {
    const insideClick = this.el.nativeElement.contains(targetElement);
    if (!insideClick) {
      this.isOpen = false;
      const dropdownMenu = this.el.nativeElement.querySelector('.dropdown-menu');
      this.renderer.setStyle(dropdownMenu, 'display', 'none');
    }
  }

}
