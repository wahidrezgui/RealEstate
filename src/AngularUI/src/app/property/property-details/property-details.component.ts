import { ProprieteBriefDto, ImagesClient } from './../../web-api-client';
import { Component, OnInit } from '@angular/core';
import { ProprietesClient, ProprieteDetailDto } from '../../web-api-client';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {

  public property: ProprieteDetailDto | undefined;
  public propertyImages: any;
  public errorMessage: string = '';
  private id: string = '';
  public serverpath: string = "https://localhost:44348/";
  constructor(private client: ProprietesClient,
    private imageclient: ImagesClient,
    private errorHandler: ErrorHandlerService,
    private router: Router,
    private activeRoute: ActivatedRoute) {
    this.id = this.activeRoute.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.getPropertyDetail();
    this.getPhotoListing();
  }

  getPropertyDetail = () => {
    this.client.getPropertyDetails(parseInt(this.id))
      .subscribe(res => {
        this.property = res as ProprieteDetailDto;

      },
        (error) => {
          this.errorHandler.HandleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })

  }

  getPhotoListing = () => {

    this.imageclient.getAll(parseInt(this.id))
      .subscribe(res => {
        this.propertyImages = res;
      },
        (error) => {
          this.errorHandler.HandleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
  }

  public deleteOwner() {

         $('#errorModal').modal();

  }
}
