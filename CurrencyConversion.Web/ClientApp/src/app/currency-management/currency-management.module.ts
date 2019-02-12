import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { CurrencyManagementRoutes } from './currency-management.routes';
import { AppCoreModule } from '../app-core/app-core.module';
import { AppMaterialModule } from '../app-material.module';
import { AppCoreUiModule } from '../app-core-ui/app-core-ui.module';
import { FormsModule } from '@angular/forms';
import { ConversionResultDisplayComponent } from './components/conversion-result-display/conversion-result-display.component';

@NgModule({
  declarations: [HomeComponent, ConversionResultDisplayComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(CurrencyManagementRoutes),

    AppMaterialModule,
    AppCoreModule,
    AppCoreUiModule
  ]
})
export class CurrencyManagementModule { }
