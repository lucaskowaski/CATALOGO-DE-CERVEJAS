import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpBaseService } from "./http-base.service";
import { Recipe } from "../models/recipe";

@Injectable({
    providedIn: 'root'
})
export class RecipeHttpService extends HttpBaseService<Recipe>{
    private readonly beerUrl = 'recipe';
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
    getByBeer(beerId:number) {
        return this.list({ url: this.beerUrl + '/getbybeer', params: {beerId: beerId} })
    }
    searchByName() {
        return this.list({ url: this.beerUrl + '/search' })
    }
}