import { RentPropertyListComponent } from './components/rent/rent-property-list/rent-property-list.component';
import { BuyPropertyListComponent } from './components/buy/buy-property-list/buy-property-list.component';
import { HomeComponent } from './components/home/home.component';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  {
    path: 'administration', loadChildren: () =>
      import('./modules/admin/admin.module').then((m) => m.AdminModule)
  },
  { path: '', component: HomeComponent },
  { path: 'rent', component: RentPropertyListComponent },
  { path: 'buy', component: BuyPropertyListComponent },
  { path: '**', component: NotFoundComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
