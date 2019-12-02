import { Component, OnInit } from '@angular/core';
import { Ingredient } from 'src/app/models/ingredient';
import { NgForm } from '@angular/forms';
import { IngredientHttpService } from '../../../services/ingredient-http.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PageBase } from '../../page-base';
import { FormValidation } from '../../../utils/form-validation';

@Component({
  selector: 'app-ingredient-register',
  templateUrl: './ingredient-register.component.html',
  styleUrls: ['./ingredient-register.component.css']
})
export class IngredientRegisterComponent extends PageBase implements OnInit {

  ingredient: Ingredient = {};
  constructor(private _ingredientHttpService: IngredientHttpService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
  ) { super() }

  ngOnInit() {
    const id = Number(this._activatedRoute.snapshot.paramMap.get('id'));
    if (id) {
      this.getIngredient(id);
    }
  }
  save(form: NgForm) {
    this.cleanMessages();
    if (!FormValidation.validateAndSetAllFieldsAsChanged(form))
      return;
    if (!this.ingredient.id) {
      this._ingredientHttpService.post(this.ingredient).subscribe(() => {
        this._router.navigateByUrl('/ingredient-list')
      }, e => {
        console.log(e);
        this.errorMessage = 'Ocorreu ao incluir o novo ingrediente.'
      });
    } else {
      this._ingredientHttpService.put(this.ingredient).subscribe(() => {
        this.sucessMessage = "O ingrediente foi alterado com sucesso";
      }, e => {
        console.log(e);
        this.errorMessage = 'Ocorreu um erro ao alterar os dados do ingrediente.'
      });
    }
  }
  getIngredient(id: number) {
    this._ingredientHttpService.get(id).subscribe(l => {
      this.ingredient = l;
      console.log(this.ingredient);
    })
  }
}
