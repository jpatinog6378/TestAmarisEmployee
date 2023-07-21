import { Injectable } from "@angular/core";
import Swal from "sweetalert2";

@Injectable({
  providedIn: 'root',
})


export class GenericService { 
  constructor() { }

  showMessage(text: string, icon: any) {
    Swal
      .fire({
        text: text,

        icon: icon,
      })
      .then((result) => { });
  };

  showAutoCloseMessage(title: string, text: string, timer: number,) {
    Swal.fire({
      title: title,
      text: text,
      timer: timer,
      showConfirmButton: false
    });
  }



}
