import { Component, OnInit } from '@angular/core';
import { BeerHttpService } from 'src/app/services/beer-http.service';
import { RecipeHttpService } from 'src/app/services/recipe-http.service';
import { Beer } from 'src/app/models/beer';
import { Recipe } from 'src/app/models/recipe';
import { PageBase } from '../../page-base';
import { FormValidation } from 'src/app/utils/form-validation';

@Component({
  selector: 'app-ingredient-management',
  templateUrl: './ingredient-management.component.html',
  styleUrls: ['./ingredient-management.component.css']
})
export class IngredientManagementComponent extends PageBase implements OnInit {
  beers: Beer[] = [];
  selectedBeer: Beer;
  selectedRecipe: Recipe;
  recipes: Recipe[];
  amountOfBottles: number;
  totalIngerdients = [];
  constructor(
    private _beerHttpService: BeerHttpService,
    private _recipeHttpService: RecipeHttpService
  ) { super() }

  ngOnInit() {
    this.getAllBeers();
  }

  getAllBeers() {
    this._beerHttpService.getAll().subscribe(beers => {
      this.beers = beers;
    })
  }
  getRecipesByBeers(beerId: number) {
    this._recipeHttpService.getByBeer(beerId).subscribe(recipes => {
      this.recipes = recipes;
    })
  }
  onSelectBeer() {
    this.getRecipesByBeers(this.selectedBeer.id);
  }
  some(ngForm) {
    console.log(this.selectedRecipe)
    this.totalIngerdients = [];
    if (!FormValidation.validateAndSetAllFieldsAsChanged(ngForm))
      return
    this.selectedRecipe.recipeIngredients.forEach(recipeIngredient => {
      this.totalIngerdients.push({
        ingredientName: recipeIngredient.ingredient.description,
        total: recipeIngredient.quantity * this.amountOfBottles
      })
    })
  }
}
