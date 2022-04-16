import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {


  public errorMessage: string = '';

  constructor(private router: Router) { }

  public HandleError = (error: HttpErrorResponse) => {

    if (error.status === 500) {
      this.Handle500Error(error);
    }
    else if (error.status === 404) {
      this.Handle404Error(error)
    }
    else {
      this.HandleOtherError(error);
    }
  }

  private Handle500Error(error: HttpErrorResponse) {
    this.createErrorMessage(error);
    this.router.navigate(['/500']);
  }

  private Handle404Error(error: HttpErrorResponse) {
    this.createErrorMessage(error);
    this.router.navigate(['/404']);
  }
  private HandleOtherError(error: HttpErrorResponse) {
    this.createErrorMessage(error);
    //TODO: this will be fixed later;
  }
  private createErrorMessage = (error: HttpErrorResponse) => {
    this.errorMessage = error.error ? error.error : error.statusText;
  }
}
