import { Beer } from "./beer";
import { Ingredient } from "./ingredient";

export interface BeerIngredient {
    beerId?: number;
    beer?: Beer;
    ingredientId?: number;
    ingredient?: Ingredient;
}