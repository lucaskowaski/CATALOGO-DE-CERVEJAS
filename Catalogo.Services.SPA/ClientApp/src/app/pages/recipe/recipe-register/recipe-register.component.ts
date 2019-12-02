import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/models/recipe';
import { Beer } from 'src/app/models/beer';
import { RecipeHttpService } from 'src/app/services/recipe-http.service';
import { BeerHttpService } from 'src/app/services/beer-http.service';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { FormValidation } from 'src/app/utils/form-validation';
import { PageBase } from '../../page-base';
import { RecipeIngredient } from 'src/app/models/recipe-ingredient';
import { ArrayUtils } from 'src/app/utils/array-utils';

@Component({
  selector: 'app-recipe-register',
  templateUrl: './recipe-register.component.html',
  styleUrls: ['./recipe-register.component.css']
})
export class RecipeRegisterComponent extends PageBase implements OnInit {
  recipes: Recipe[] = [];
  recipeStruture: Recipe = {};
  recipeIngredientsStructure: RecipeIngredient[] = [];
  recipe: Recipe = {};
  beer: Beer = {};
  recipeIngredients: RecipeIngredient[] = [];
  constructor(
    private _beerHttpService: BeerHttpService,
    private _recipeHttpService: RecipeHttpService,
    private _activatedRoute: ActivatedRoute
  ) { super() }

  ngOnInit() {
    this.getRouteBeerId();
  }
  save(ngForm: NgForm) {
    this.cleanMessages();
    if (!FormValidation.validateAndSetAllFieldsAsChanged(ngForm))
      return;
    console.log('recipe', this.recipe);
    this.recipe.recipeIngredients = [];
    if (!this.recipe.id) {
      this.recipeIngredients.forEach(recipeIngredient => {
        this.recipe.recipeIngredients.push({ ingredientId: recipeIngredient.ingredientId, quantity: recipeIngredient.quantity });
      });
      this._recipeHttpService.post(this.recipe).subscribe(() => {
        FormValidation.setAsUnchanged(ngForm);
        this.newRecepeStruture();
        this.getRecipes(this.beer.id);
        this.sucessMessage = 'Receita adicionada com sucesso.';
      });
    } else {
      this.recipeIngredients.forEach(recipeIngredient => {
        this.recipe.recipeIngredients.push({ ingredientId: recipeIngredient.ingredientId, quantity: recipeIngredient.quantity, recipeId: this.recipe.id });
      });
      this._recipeHttpService.put(this.recipe).subscribe(() => {
        this.sucessMessage = 'Receita alterada com sucesso.';
        this.getRecipes(this.beer.id);
      })
    }
  }
  getBeer(id: number) {
    this._beerHttpService.getIncludeIngredient(id).subscribe(beer => {
      this.beer = beer;
      this.recipeStruture.beerId = beer.id;
      this.recipeStruture.recipeIngredients = [];
      this.beer.beerIngredient.forEach(beerIngredient => {
        this.createRecipeIngredientsStructure(beerIngredient.ingredient.id, beerIngredient.ingredient.description);
      })
      this.recipeStruture.bottleSize = 600;
      this.newRecepeStruture();
      console.log(beer);
    })
  }
  createRecipeIngredientsStructure(id, description) {
    this.recipeIngredientsStructure.push({ ingredientId: id, ingredient: { description: description } });
  }
  newRecepeStruture() {
    this.recipeIngredientsStructure.forEach(r=>r.quantity = undefined);
    this.recipeIngredients = this.recipeIngredientsStructure;
    this.recipe = this.recipeStruture;
    this.cleanMessages();
  }
  getRouteBeerId() {
    const id = Number(this._activatedRoute.snapshot.paramMap.get('beerId'));
    if (id) {
      this.getBeer(id);
      this.getRecipes(id);
    }
  }
  getRecipes(beerId: number) {
    this._recipeHttpService.getByBeer(beerId).subscribe(recipes => {
      this.recipes = recipes;
      console.log('recipes', recipes)
    })
  }
  editRecipe(recipe: Recipe) {
    this.recipeIngredients = [];
    console.log('recipe for edit', this.recipe);
    recipe.recipeIngredients.forEach(recipeIngredient => {
      this.recipeIngredients.push({ ingredientId: recipeIngredient.ingredientId, quantity: recipeIngredient.quantity, ingredient: { description: recipeIngredient.ingredient.description } });
    })
    this.recipe = {
      id: recipe.id, beerId: recipe.beerId, bottleSize: recipe.bottleSize
    };
    window.scroll(0,0);
  }
  remove(recipe: Recipe){
    this._recipeHttpService.delete(recipe).subscribe(() => {
      ArrayUtils.removeEntityOfList(this.recipes, recipe.id);
    }, e=>console.log(e));
  }
}
