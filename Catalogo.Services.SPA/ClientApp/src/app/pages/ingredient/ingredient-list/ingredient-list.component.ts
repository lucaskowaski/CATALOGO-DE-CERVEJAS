import { Component, OnInit } from '@angular/core';
import { IngredientHttpService } from 'src/app/services/ingredient-http.service';
import { Ingredient } from 'src/app/models/ingredient';
import { Router } from '@angular/router';
import { ArrayUtils } from 'src/app/utils/array-utils';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.css']
})
export class IngredientListComponent implements OnInit {
  ingredients: Ingredient[];
  ErrorWhileListIngredients = '';
  searchTerm = '';
  constructor(
    private _ingredientHttpService: IngredientHttpService,
    private _router: Router
  ) { }

  ngOnInit() {
    this.listAllIngredients();
  }
  listAllIngredients() {
    this._ingredientHttpService.getAll().subscribe(ingredients => {
      this.ingredients = ingredients;
    })
  }
  editar(ingredient: Ingredient) {
    this._router.navigate(['/ingredient-register', { id: ingredient.id }]);
  }
  excluir(ingredient: Ingredient) {
    this._ingredientHttpService.delete(ingredient).subscribe(() => {
      ArrayUtils.removeEntityOfList(this.ingredients, ingredient.id);
    }, e=>console.log(e));
  }
  search() {
    this._ingredientHttpService.searchByDescription(this.searchTerm).subscribe(ingredients => {
      this.ingredients = ingredients;
    })
  }
  cleanFilters() {
    this.listAllIngredients();
  }
}
