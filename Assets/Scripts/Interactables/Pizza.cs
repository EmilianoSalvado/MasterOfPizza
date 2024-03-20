using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    Dictionary<Ingredients, int> _ingredients = new Dictionary<Ingredients, int>();
    public Dictionary<Ingredients, int> IngredientsOf { get { return _ingredients; } }
    PizzaState _state;
    public PizzaState State { get { return _state; } }

    private void Start()
    {
        _state = PizzaState.Raw;
    }

    public void AddIngredient(Ingredients ingredient)
    {
        if (ingredient == Ingredients.None) return;

        if (_ingredients.ContainsKey(ingredient))
        {
            _ingredients[ingredient] += 1;
            return;
        }
        _ingredients.Add(ingredient, 1);
    }

    public void ChangeState(PizzaState newState)
    {
        _state = newState;
    }
}