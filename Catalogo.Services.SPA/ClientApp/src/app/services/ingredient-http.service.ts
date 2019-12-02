import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpBaseService } from "./http-base.service";
import { Ingredient } from "../models/ingredient";

@Injectable({
    providedIn: 'root'
})
export class IngredientHttpService extends HttpBaseService<Ingredient>{
    private readonly beerUrl = 'ingredient';
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
    searchByDescription(description:string) {
        return this.list({ url: this.beerUrl + '/search', params: {
            description: description
        } })
    }
}