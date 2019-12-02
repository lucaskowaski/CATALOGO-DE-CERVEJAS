import { Entity } from "./model-base";
import { BeerIngredient } from "./beer-ingredient";

export interface Ingredient extends Entity {
    description?: string;
    beerIngredient?: BeerIngredient[];
}