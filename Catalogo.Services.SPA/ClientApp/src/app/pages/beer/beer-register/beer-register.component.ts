import { Component, OnInit } from '@angular/core';
import { PageBase } from '../../page-base';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BeerHttpService } from 'src/app/services/beer-http.service';
import { FormValidation } from 'src/app/utils/form-validation';
import { Beer } from 'src/app/models/beer';
import { IngredientHttpService } from 'src/app/services/ingredient-http.service';
import { Ingredient } from 'src/app/models/ingredient';

@Component({
  selector: 'app-beer-register',
  templateUrl: './beer-register.component.html',
  styleUrls: ['./beer-register.component.css']
})
export class BeerRegisterComponent extends PageBase implements OnInit {
  beer: Beer = {
    beerIngredient: []
  };
  beerIngredients = [];
  ingredients: Ingredient[];
  constructor(
    private _beerHttpService: BeerHttpService,
    private _ingredientHttpService: IngredientHttpService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
  ) { super() }

  ngOnInit() {
    this.listIngredients();
  }
  getBeerRouterId() {
    const id = Number(this._activatedRoute.snapshot.paramMap.get('id'));
    if (id) {
      this.getCerveja(id);
    }
  }
  save(ngForm: NgForm) {
    this.cleanMessages();
    if (!FormValidation.validateAndSetAllFieldsAsChanged(ngForm))
      return;

    this.beer.beerIngredient = [];
    this.beerIngredients.forEach(beerIngredientId => this.beer.beerIngredient.push({ ingredientId: beerIngredientId as number }))
    console.log(this.beer);
    if (!this.beer.id) {
      this._beerHttpService.post(this.beer).subscribe(() => {
        this._router.navigateByUrl('/beer-list')
      }, e => {
        console.log(e);
        this.errorMessage = 'Ocorreu ao incluir a nova cerveja.'
      });
    } else {
      this._beerHttpService.put(this.beer).subscribe(() => {
        this.sucessMessage = "A cerveja foi alterado com sucesso";
      }, e => {
        console.log(e);
        this.errorMessage = 'Ocorreu um erro ao alterar os dados da cerveja.'
      });
    }
  }
  getCerveja(id: number) {
    this._beerHttpService.getIncludeIngredient(id).subscribe(beer => {
      beer.beerIngredient.forEach(beerIngredient => this.beerIngredients.push(beerIngredient.ingredientId))
      this.beer = beer;
      console.log('this.beer', this.beer);
    })
  }
  listIngredients() {
    this._ingredientHttpService.getAll().subscribe(ingredients => {
      this.ingredients = ingredients;
      console.log('ingredients', ingredients);
      this.getBeerRouterId()
    })
  }
}
