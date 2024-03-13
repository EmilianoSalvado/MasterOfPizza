using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueGenerator : MonoBehaviour
{
    public string GetOrderDialogue(Order order)
    {
        if (order.Pizzas.Length < 1)
            Debug.LogError("Received and empty order. Must have at least one OrderedPizza in the Order Pizza's array.");

        var result = "I want a pizza with ";

        foreach (var pizza in order.Pizzas)
        {
            foreach (var ingredient in pizza.RequestedIngredients.Skip(0))
            {
                if (ingredient == pizza.RequestedIngredients.First())
                { result += $"{Utilities.wordedIngredients[ingredient]}"; }

                if (ingredient == pizza.RequestedIngredients.Last())
                { result += $"and {Utilities.wordedIngredients[ingredient]}."; break; }

                result += $", {Utilities.wordedIngredients[ingredient]}";
            }

            if (order.Pizzas.Length > 1 && pizza != order.Pizzas.Last())
                result += ". Another pizza with ";
            else if (order.Pizzas.Length > 1)
                result += ". And another one with ";
        }

        return result;
    }
}