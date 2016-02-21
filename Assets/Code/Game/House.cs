using System;
using System.Collections.Generic;
using UnityEngine;

public class House
{

    public List<Ingredient> ingredientStock;

    public House()
    {
        ingredientStock = GameDatabase.Instance.GetFullIngredientList();
    }
}

