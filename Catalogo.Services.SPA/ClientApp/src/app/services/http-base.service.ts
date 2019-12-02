import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { UrlActions } from './url-actions';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HttpBaseService<TEntity>{
    constructor(
        protected _httpClient: HttpClient, protected urlAction?: UrlActions) {
    }
    list(data: listParams) {
        return this._httpClient.get<TEntity[]>(this.buildUrl(data.url), {
            params: data.params
        })
    }
    get(id: any, url?: string) {
        console.log('**', this.buildUrl(url || this.urlAction.get));
        return this._httpClient.get<TEntity>(this.buildUrl(url || this.urlAction.get), {
            params: {id:id}
        })
    }
    post(entity: TEntity, url?: string) {
        return this._httpClient.post<TEntity>(this.buildUrl(url || this.urlAction.post),
            entity, { headers: this.buildHeaderForSedJson() })
    }
    put(entity: TEntity, url?: string) {
        return this._httpClient.put<TEntity>(this.buildUrl(url || this.urlAction.put),
            entity, { headers: this.buildHeaderForSedJson() })
    }
    delete(params: any, url?: string) {
        return this._httpClient.delete<TEntity>(this.buildUrl(url || this.urlAction.delete), {
            params: params
        })
    }
    buildHeaderForSedJson() {
        const headers = new HttpHeaders();
        this.setHeaderContentJson(headers);
        return headers;
    }
    private setHeaderContentJson(headers: HttpHeaders) {
        headers.append('Content-Type', 'application/json')
    }
    private buildUrl(url: string) {
        return environment.apiUrl +  url;
    }
}
export interface listParams {
    url?: string;
    params?: any;
}
