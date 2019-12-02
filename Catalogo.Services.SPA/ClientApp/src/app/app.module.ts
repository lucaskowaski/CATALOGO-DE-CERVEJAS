import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { IngredientRegisterComponent } from './pages/ingredient/ingredient-register/ingredient-register.component';
import { IngredientListComponent } from './pages/ingredient/ingredient-list/ingredient-list.component';
import { InputErrorsComponent } from './compoents/input-erors/input-errors.component';
import { ObjectKeysPipe } from './pipe/object-keys.pipe';
import { BeerListComponent } from './pages/beer/beer-list/beer-list.component';
import { BeerRegisterComponent } from './pages/beer/beer-register/beer-register.component';
import { RecipeRegisterComponent } from './pages/recipe/recipe-register/recipe-register.component';
import { IngredientManagementComponent } from './pages/ingredient/ingredient-management/ingredient-management.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    IngredientRegisterComponent,
    IngredientListComponent,
    InputErrorsComponent,
    ObjectKeysPipe,
    BeerListComponent,
    BeerRegisterComponent,
    RecipeRegisterComponent,
    IngredientManagementComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: BeerListComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'ingredient-register', component: IngredientRegisterComponent },
      { path: 'ingredient-list', component: IngredientListComponent },
      { path: 'ingredient-management', component: IngredientManagementComponent },
      { path: 'beer-register', component: BeerRegisterComponent },
      { path: 'beer-list', component: BeerListComponent },
      { path: 'recipe-register', component: RecipeRegisterComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
