using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Ingredients _ingredientInHand;
    public Ingredients IngredientInHand { get {  return _ingredientInHand; } }
    [SerializeField] Pizza _pizzaInHand;
    public Pizza PizzaInHand {  get { return _pizzaInHand; } }

    public static Player instance;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    public void Grab(Ingredients ingredient)
    {
        Clear();
        _ingredientInHand = ingredient;
    }

    public void Grab(Pizza pizza)
    {
        Clear();
        _pizzaInHand = pizza;
    }

    public void Clear()
    {
        _ingredientInHand = Ingredients.None;
        _pizzaInHand = null;
    }
}