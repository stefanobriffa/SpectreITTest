import { Injectable, ErrorHandler, Inject, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { UNAUTHORIZED, BAD_REQUEST, FORBIDDEN } from "http-status-codes";
import { ToastrService } from 'ngx-toastr'

@Injectable()
export class GlobalErrorHandlerService implements ErrorHandler {
    constructor(@Inject(Injector) private injector: Injector) { } 
    
    // Need to get ToastrService from injector rather than constructor injection to avoid cyclic dependency error
    private get toastrService(): ToastrService {
        return this.injector.get(ToastrService);
    }

    handleError(error: any) {
    //     let httpErrorCode = error.httpErrorCode;
    // switch (httpErrorCode) {
    //   case UNAUTHORIZED:

    //       break;
    //   case FORBIDDEN:

    //       break;
    //   case BAD_REQUEST:
    //      //this.showError(error.message);
    //       break;
    //   default:
    //      //this.showError(REFRESH_PAGE_ON_TOAST_CLICK_MESSAGE);
    // }
    
      if (error instanceof HttpErrorResponse) {
          //Backend returns unsuccessful response codes such as 404, 500 etc.				  
          console.error('Backend returned status code: ', error.status);
          console.error('Response body:', error.message);   
          
          this.toastrService.error(error.error.Message);
    


          


      } else {
        
          //A client-side or network error occurred.	          
          console.error('An error occurred:', error.message);          
      }    
      
      

      

    }

    // private showError(message:string){
    //     this.toastManager.error(message, DEFAULT_ERROR_TITLE, { dismiss: 'controlled'}).then((toast:Toast)=>{
    //             let currentToastId:number = toast.id;
    //             this.toastManager.onClickToast().subscribe(clickedToast => {
    //                 if (clickedToast.id === currentToastId) {
    //                     this.toastManager.dismissToast(toast);
    //                     window.location.reload();
    //                 }
    //             });
    //         });
    //   }
} 