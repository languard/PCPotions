using System;
using System.Collections.Generic;
using UnityEngine;

public class Potion : GenericItem, ICloneable
{
    public int valueBase;
    public float qualityScale;
    public int brewTime;
    public int baseReaCost;
    public List<Ingredient> ingredientList;

    public Potion()
    {
        ingredientList = new List<Ingredient>();
    }

    public void AddIngredient(Ingredient newIng)
    {
        ingredientList.Add(newIng);
    }

    public object Clone()
    {
        Potion newPotion = new Potion();
        newPotion.ID = this.ID;
        newPotion.name = this.name;
        newPotion.sprite = this.sprite;
        newPotion.itemType = this.itemType;
        newPotion.baseReaCost = this.baseReaCost;
        newPotion.valueBase = this.valueBase;
        newPotion.brewTime = this.brewTime;
        newPotion.qualityScale = this.qualityScale;
        newPotion.ingredientList = this.ingredientList;  //shallow copy is what we want.  Do NOT need a full copy.
        return newPotion;
    }
}

