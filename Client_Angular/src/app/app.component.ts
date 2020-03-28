import { Component } from '@angular/core';
import { Advertisement } from './models/advertisement.model';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  lstAdvertisement: Array<Advertisement>;
  isCreateMode: boolean;
  advertisement: Advertisement;

  constructor(public appService: AppService) {
    this.lstAdvertisement = new Array<Advertisement>();
    this.getAllAdvertisement();
    this.advertisement = new Advertisement();
  }


  public getAllAdvertisement() {

    this.appService.getAllAdvertisement()
      .subscribe((data: any) => {
        this.lstAdvertisement = data;
      });
  }

  public startAddAdvertisement() {
    this.isCreateMode = !this.isCreateMode;

    var obj = document.getElementById("btnAddAdv");

    if (obj.innerHTML.trim() == "Adicionar anúncio") {
      obj.innerHTML = "Cancelar";
    } else {
      obj.innerHTML = "Adicionar anúncio";

    }

    this.advertisement = new Advertisement();
  }

  public addAdvertisement() {

    this.appService.saveAdvertisement(this.advertisement).subscribe((data: any) => {
      this.startAddAdvertisement();
      this.getAllAdvertisement();
    });

  }

  public removeAdvertisement(idAdv: number) {

    this.appService.deleteAdvertisement(idAdv).subscribe((data: any) => {
      this.getAllAdvertisement();
    });

  }
}
