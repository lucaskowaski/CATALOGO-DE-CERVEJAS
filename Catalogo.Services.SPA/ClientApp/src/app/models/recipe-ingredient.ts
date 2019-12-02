import { Recipe } from "./recipe";
import { Ingredient } from "./ingredient";

export interface RecipeIngredient {
    ingredientId?: number;
    ingredient?: Ingredient;
    recipeId?: number;
    recipe?: Recipe;
    quantity?: number;
}