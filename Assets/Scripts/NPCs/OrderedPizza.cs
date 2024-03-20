using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class OrderedPizza
{
    List<Ingredients> _requestedIngredients = new List<Ingredients>();
    public List<Ingredients> RequestedIngredients { get { return _requestedIngredients; } }
    int regularMin = 6, extraMin = 10;

    public List<Ingredients> GetOrder()
    { return _requestedIngredients; }

    public OrderedPizza(params Ingredients[] ingredients)
    {
        foreach (var item in ingredients)
            _requestedIngredients.Add(item);
    }

    public OrderResult CheckOrder(Pizza pizza)
    {
        if (pizza.State == PizzaState.Burnt || pizza.State == PizzaState.Raw)
            return OrderResult.Failed;

        int correct = 0;

        foreach (var ing in pizza.IngredientsOf.Keys)
        {
            if (_requestedIngredients.Contains(ing))
            {
                correct++;
            }

            if (correct < _requestedIngredients.Count)
                return OrderResult.Failed;
            if (pizza.IngredientsOf.All((x) => x.Value < regularMin))
                return OrderResult.Poor;
        }

        if (pizza.State == PizzaState.Overcooked)
            return OrderResult.Succesful;

        if (pizza.IngredientsOf.Any((x) => x.Value >= extraMin))
            return OrderResult.Great;

        return OrderResult.Succesful;
    }
}