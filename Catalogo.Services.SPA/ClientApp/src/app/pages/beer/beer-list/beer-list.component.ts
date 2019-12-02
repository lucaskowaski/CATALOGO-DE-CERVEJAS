import { Component, OnInit } from '@angular/core';
import { BeerHttpService } from 'src/app/services/beer-http.service';
import { Router } from '@angular/router';
import { Beer } from 'src/app/models/beer';
import { ArrayUtils } from 'src/app/utils/array-utils';

@Component({
  selector: 'app-beer-list',
  templateUrl: './beer-list.component.html',
  styleUrls: ['./beer-list.component.css']
})
export class BeerListComponent implements OnInit {
  beers: Beer[];
  searchTerm = '';
  constructor(
    private _beertHttpService: BeerHttpService,
    private _router: Router
  ) { }
  ngOnInit() {
    this.listAllbeer();
  }
  listAllbeer() {
    this._beertHttpService.getAll().subscribe(beers => {
      this.beers = beers;
    })
  }
  editar(ingredient: Beer) {
    this._router.navigate(['/beer-register', { id: ingredient.id }]);
  }
  excluir(beer: Beer) {
    this._beertHttpService.delete(beer).subscribe(() => {
      ArrayUtils.removeEntityOfList(this.beers, beer.id);
    });
  }
  receitas(beer:Beer){
    this._router.navigate(['/recipe-register', { beerId: beer.id }]);
  }
  search() {
    this._beertHttpService.searchByName(this.searchTerm).subscribe(beers => {
      this.beers = beers;
    }, e => console.log(e))
  }
  cleanFilters() {
    this.listAllbeer();
  }
}
