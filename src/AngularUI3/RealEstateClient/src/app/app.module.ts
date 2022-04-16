import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './components/login/login.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeroesComponent } from './components/heroes/heroes.component';
import { LastAddedSellComponent } from './components/last-added-sell/last-added-sell.component';
import { AgentsImmobilierComponent } from './components/agents-immobilier/agents-immobilier.component';
import { NotairesComponent } from './components/notaires/notaires.component';
import { NotaireCardComponent } from './components/shared/notaire-card/notaire-card.component';
import { HouseCardComponent } from './components/shared/house-card/house-card.component';
import { AgentCardComponent } from './components/shared/agent-card/agent-card.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TopmenuComponent } from './components/topmenu/topmenu.component';
import { RentPropertyListComponent } from './components/rent/rent-property-list/rent-property-list.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ForgotPasswordComponent,
    NotFoundComponent,
    HomeComponent,

    FooterComponent,

    HeroesComponent,
    LastAddedSellComponent,
    AgentsImmobilierComponent,
    NotairesComponent,
    NotaireCardComponent,
    HouseCardComponent,
    AgentCardComponent,
    TopmenuComponent,
    RentPropertyListComponent,



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FontAwesomeModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
