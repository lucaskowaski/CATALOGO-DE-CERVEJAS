import { Beer } from "./beer";
import { Entity } from "./model-base";
import { RecipeIngredient } from "./recipe-ingredient";

export interface Recipe extends Entity {
    beerId?: number;
    beer?: Beer;
    bottleSize?: number;
    recipeIngredients?: RecipeIngredient[];
}