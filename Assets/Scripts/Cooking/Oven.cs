using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField] float _cookedTime, _overcookedTime, _burntTime;
    Pizza _pizza;

    public void PizzaIn(Pizza pizza)
    {
        if (_pizza != null) return;
        _pizza = pizza;
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