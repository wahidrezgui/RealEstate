
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { PropertiesListComponent } from './properties-list/properties-list.component';
import { PropertyDetailsComponent } from './property-details/property-details.component';
import { MapLocationComponent } from './map-location/map-location.component';
import { GoogleMapsModule } from '@angular/google-maps';
import { MapListLocationComponent } from './map-list-location/map-list-location.component'
import { SharedModule } from './../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { PropertyCreateComponent } from './property-create/property-create.component';

@NgModule({
  declarations: [
    PropertiesListComponent,
    PropertyDetailsComponent,

    MapLocationComponent,
    MapListLocationComponent,
    PropertyCreateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    GoogleMapsModule,
    RouterModule.forChild([
      { path: 'list', component: PropertiesListComponent },
      { path: 'listmap', component: MapListLocationComponent },
      { path: 'details/:id', component: PropertyDetailsComponent },
      { path: 'create', component: PropertyCreateComponent }
    ])
  ]
})
export class PropertyModule { }
