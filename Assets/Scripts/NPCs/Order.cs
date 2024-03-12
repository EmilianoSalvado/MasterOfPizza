using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    Dictionary<Ingredients, bool> _requestedIngredients = new Dictionary<Ingredients, bool>();
    int regularMin = 6, extraMin = 10;

    public Dictionary<Ingredients, bool> GetOrder()
    { return _requestedIngredients; }

    public OrderResult CheckOrder(Pizza pizza)
    {
        if (pizza.State == PizzaState.Burnt || pizza.State == PizzaState.Raw)
            return OrderResult.Failed;

        int correct = 0;

        foreach (var ing in pizza.Ingredients.Keys)
        {
            if (_requestedIngredients.ContainsKey(ing))
            {
                correct++;
            }

            if (correct < _requestedIngredients.Count)
                return OrderResult.Failed;
            if (pizza.Ingredients.All((x) => x.Value < regularMin))
                return OrderResult.Poor;
        }

        if (pizza.State == PizzaState.Overcooked)
            return OrderResult.Succesful;

        if (pizza.Ingredients.Any((x) => x.Value >= extraMin))
            return OrderResult.Great;

        return OrderResult.Succesful;
    }
}