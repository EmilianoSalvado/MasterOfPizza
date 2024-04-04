using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Interactable
{
    [SerializeField] float _cookedTime, _overcookedTime, _burntTime;
    Pizza _pizza;

    public override bool Interact()
    {
        if (_pizza != null && Player.instance.PizzaInHand == null)
        { Player.instance.Grab(PizzaOut()); return true; }
        else if (_pizza != null)
        { return false; }

        _pizza = Player.instance.PizzaInHand;
        _pizza.transform.position = transform.position;
        Player.instance.Clear();
        StartCoroutine(CookPizza());
        return true;
    }

    public void PizzaIn(Pizza pizza)
    {
        StartCoroutine(CookPizza());
    }

    public Pizza PizzaOut()
    {
        StopAllCoroutines();
        StartCoroutine(EmptyPizzaVariable());
        return _pizza;
    }

    IEnumerator CookPizza()
    {
        var ct = new WaitForSeconds(_cookedTime);
        var oct = new WaitForSeconds(_overcookedTime);
        var bt = new WaitForSeconds(_burntTime);

        yield return ct;
        _pizza.ChangeState(PizzaState.Cooked);
        yield return oct;
        _pizza.ChangeState(PizzaState.Overcooked);
        yield return bt;
        _pizza.ChangeState(PizzaState.Burnt);
    }

    IEnumerator EmptyPizzaVariable()
    {
        yield return new WaitForSeconds(.1f);
        _pizza = null;
    }
}