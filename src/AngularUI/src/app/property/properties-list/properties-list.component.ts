import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http"
import { Router } from '@angular/router';

import { ProprietesClient, PaginatedListOfProprieteBriefDto, WeatherForecast, ProprieteBriefDto } from '../../web-api-client';
import { ErrorHandlerService } from '../../shared/services/error-handler.service';

@Component({
  selector: 'app-properties-list',
  templateUrl: './properties-list.component.html',
  styleUrls: ['./properties-list.component.css']
})
export class PropertiesListComponent {



  constructor(private client: ProprietesClient,
              private errorHandler: ErrorHandlerService,
              private router:Router) {

    this.GetData(1, this.itemsPerPage);
  }

  public errorMessage: string = '';

  totalCount: number = 0;
  totalPages: number = 0;
  pageNumber: number = 0;
  itemsPerPage = 10;
  proprietes: any;

  public maxSize: number = 15;
  public directionLinks: boolean = true;
  public autoHide: boolean = false;
  public responsive: boolean = true;

  ngOnInit() {

  }

  GetData(page: any, itemsperPage: number) {
    /* this.http.get(`https://api.instantwebtools.net/v1/passenger?page=${page}&size=${this.itemsPerPage}`).subscribe((data: any) => {
      this.passenger = data.data;
      this.totalItems = data.totalPassengers;
    }) */
    this.client.getProprietesWithPagination(page, itemsperPage).subscribe(result => {

      this.proprietes = result.items;
      this.totalCount = result.totalCount;
      this.totalPages = result.totalPages;
      this.pageNumber = result.pageNumber;

      $('#successModal').modal();


    }, (error: any) => {
      console.error(error);
      this.errorHandler.HandleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    }

    );
  }

  getPropertyDetails(idproperty: any) {
    const detailsUrl: string = `/prop/details/${idproperty}`;
    this.router.navigate([detailsUrl]);
  }
}
