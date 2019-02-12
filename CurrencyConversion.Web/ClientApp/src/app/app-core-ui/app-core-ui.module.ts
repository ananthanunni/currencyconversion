import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThrobberComponent } from './components/throbber/throbber.component';
import { AppMaterialModule } from '../app-material.module';

@NgModule({
  declarations: [ThrobberComponent],
  imports: [
    CommonModule,
    AppMaterialModule
  ],
  exports:[ThrobberComponent]
})
export class AppCoreUiModule { }
