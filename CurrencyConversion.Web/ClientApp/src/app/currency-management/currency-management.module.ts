import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { CurrencyManagementRoutes } from './currency-management.routes';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(CurrencyManagementRoutes)
  ]
})
export class CurrencyManagementModule { }
