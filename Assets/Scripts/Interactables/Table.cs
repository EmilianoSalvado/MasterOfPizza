using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    [SerializeField] Pizza _pizzaPrefab;
    [SerializeField] Transform _pizzaPoint;
    [SerializeField] Collider[] _colliders;
    Pizza _pizza;
    public override bool Interact()
    {
        if (Player.instance.IngredientInHand != Ingredients.Dough) return false;

        if (_pizza == null)
        {
            _pizza = Instantiate(_pizzaPrefab, _pizzaPoint.position, _pizzaPrefab.transform.rotation);
            SwitchColliders();
            return true;
        }

        Player.instance.Grab(_pizza);
        _pizza = null;
        SwitchColliders();
        return true;
    }

    void SwitchColliders()
    {
        foreach (Collider collider in _colliders)
        {
            collider.enabled = !collider.enabled;
        }
    }
}