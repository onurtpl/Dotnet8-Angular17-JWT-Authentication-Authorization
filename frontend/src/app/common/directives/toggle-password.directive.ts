import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appTogglePassword]',
  standalone: true
})
export class TogglePasswordDirective {
  private _shown = false;
  constructor(private el: ElementRef, private renderer: Renderer2) { }

  @HostListener('click')
  togglePasswordVisibility() {
    this._shown = !this._shown;
    this.renderer.setAttribute(
      this.el.nativeElement.parentNode.querySelector('input'),
      'type',
      this._shown ? 'text' : 'password'
    );

    // Change the icon class accordingly
    if (this._shown) {
      this.renderer.addClass(this.el.nativeElement, 'fa-eye-slash');
      this.renderer.removeClass(this.el.nativeElement, 'fa-eye');
    } else {
      this.renderer.addClass(this.el.nativeElement, 'fa-eye');
      this.renderer.removeClass(this.el.nativeElement, 'fa-eye-slash');
    }
  }
}
