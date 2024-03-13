using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Ingredients[] indexedIngredients = new Ingredients[]
    {
        Ingredients.Dough, Ingredients.TomatoSauce, Ingredients.Cheese, Ingredients.Ham,
        Ingredients.RedBellPepper, Ingredients.Tomato, Ingredients.Garlic
    };

    public static Dictionary<Ingredients, string> wordedIngredients = new Dictionary<Ingredients, string>
    {
        {Ingredients.Dough, "dough" }, { Ingredients.TomatoSauce, "sauce" }, { Ingredients.Cheese, "cheese"},
        { Ingredients.RedBellPepper, "red bell pepper"}, { Ingredients.Tomato, "tomato" }, { Ingredients.Garlic, "garlic" }
    };
}