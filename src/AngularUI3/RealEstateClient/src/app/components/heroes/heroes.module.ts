import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { HeroesComponent } from './heroes.component';

@NgModule({
  imports: [BrowserModule, FormsModule, NgbModule],
 
  exports: [HeroesComponent],
  bootstrap: [HeroesComponent]
})
export class NgbdCarouselPauseModule { }
