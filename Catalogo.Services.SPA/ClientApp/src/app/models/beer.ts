import { Entity } from "./model-base";
import { BeerIngredient } from "./beer-ingredient";

export interface Beer extends Entity {
    name?: string;
    brand?: string;
    beerIngredient?: BeerIngredient[];
    family?: string;
    style?: string;
    abv?: number;
    ibu?: number;
}