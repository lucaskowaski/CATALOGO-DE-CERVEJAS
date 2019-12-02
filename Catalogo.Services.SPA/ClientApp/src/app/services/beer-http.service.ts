import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpBaseService } from "./http-base.service";
import { Beer } from "../models/beer";

@Injectable({
    providedIn: 'root'
})
export class BeerHttpService extends HttpBaseService<Beer>{
    private readonly beerUrl = 'beer';
    constructor(
        protected _httpClient: HttpClient
    ) {
        super(_httpClient);
        this.urlAction = {
            get: this.beerUrl,
            post: this.beerUrl,
            put: this.beerUrl,
            delete: this.beerUrl
        }
    }
    getAll() {
        return this.list({ url: this.beerUrl + '/getall' })
    }
    searchByName(name: string) {
        return this.list({ url: this.beerUrl + '/search', params: {name: name} })
    }
    getIncludeIngredient(id: number){
        return this.get(id, this.beerUrl + '/getincludeingredient')
    }
}