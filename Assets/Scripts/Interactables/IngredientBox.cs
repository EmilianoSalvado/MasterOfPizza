using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : Interactable
{
    [SerializeField] Ingredients _ingredient;
    public override bool Interact()
    {
        if (Player.instance.PizzaInHand != null) return false;
        Player.instance.Grab(_ingredient);
        return true;
    }
}