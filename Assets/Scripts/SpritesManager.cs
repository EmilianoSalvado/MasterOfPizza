using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    //[SerializeField] Sprite _tomatoSauce;
    //[SerializeField] Sprite _cheese;
    //[SerializeField] Sprite _ham;
    //[SerializeField] Sprite _redBellPepper;
    //[SerializeField] Sprite _tomato;
    //[SerializeField] Sprite _garlic;

    [SerializeField] GameObject _tomatoSauce;
    [SerializeField] GameObject _cheese;
    [SerializeField] GameObject _ham;
    [SerializeField] GameObject _redBellPepper;
    [SerializeField] GameObject _tomato;
    [SerializeField] GameObject _garlic;

    //Dictionary<Ingredients, Sprite> _sprites = new Dictionary<Ingredients, Sprite>();
    Dictionary<Ingredients, GameObject> _sprites = new Dictionary<Ingredients, GameObject>();

    public static SpritesManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        _sprites.Add(Ingredients.TomatoSauce, _tomatoSauce);
        _sprites.Add(Ingredients.Cheese, _cheese);
        _sprites.Add(Ingredients.Ham, _ham);
        _sprites.Add(Ingredients.RedBellPepper, _redBellPepper);
        _sprites.Add(Ingredients.Tomato, _tomato);
        _sprites.Add(Ingredients.Garlic, _garlic);
    }

    public void Show(Transform pizzaTransform, Ingredients ingredient)
    {
        Instantiate(_sprites[ingredient], pizzaTransform.position, Quaternion.identity, pizzaTransform);
    }
}