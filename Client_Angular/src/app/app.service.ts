import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Advertisement } from './models/advertisement.model';


const base_api = "https://localhost:44342/api";

@Injectable()
export class AppService {

    constructor(private myHttp: HttpClient) { }


    getAllAdvertisement() {
        return this.myHttp.get(`${base_api}/Advertisement`);
    }

    getAdvertisement(idAdv: number) {
        return this.myHttp.get(`${base_api}/Advertisement/${idAdv}`);
    }

    saveAdvertisement(adv: Advertisement) {
        return this.myHttp.post<Advertisement>(`${base_api}/Advertisement`, adv);
    }

    updateAdvertisement(idAdv: number, adv: Advertisement) {
        return this.myHttp.put<Advertisement>(`${base_api}/Advertisement/{idAdv}`, adv);
    }

    deleteAdvertisement(idAdv: number) {
        return this.myHttp.delete(`${base_api}/Advertisement/${idAdv}`);
    }



    getListVehicleMakers() {
        return this.myHttp.get(`${base_api}/GetVehicleMakers`);
    }

    getListVehicleModels(markerId: number) {
        return this.myHttp.get(`${base_api}/Advertisement/${markerId}`);
    }

    getListVehicleVersions(modelId: number) {
        return this.myHttp.get(`${base_api}/GetVehicleVersions/${modelId}`);
    }
}