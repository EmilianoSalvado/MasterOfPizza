using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField][Range(1,4)] int _numberOfPizzas;
    [SerializeField] OrderedPizza[] _pizzas;

    public void Randomize()
    {
        _numberOfPizzas = Random.Range(1, 4);
        _pizzas = new OrderedPizza[_numberOfPizzas];

        for (int i = 0; i < _pizzas.Length; i++)
        {
            int numberOfIngredients = Random.Range(2, Utilities.indexedIngredients.Length);
            var requestedIngredients = Utilities.indexedIngredients.Take(numberOfIngredients).ToArray();

            if (requestedIngredients.Contains(Ingredients.Tomato))
            {
                requestedIngredients.SkipWhile((x) => x == Ingredients.Ham || x == Ingredients.RedBellPepper).ToArray();
            }

            _pizzas[i] = new OrderedPizza(requestedIngredients);
        }
    }
}