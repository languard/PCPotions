using System;
using System.Collections.Generic;
using UnityEngine;

public class House
{

    public List<Ingredient> ingredientStock;

    public House()
    {
        //ingredientStock = GameDatabase.Instance.GetFullIngredientList();
        ingredientStock = new List<Ingredient>();

    }

    public void AddIngredient(Ingredient newIng)
    {

        bool wasAdded = false;
        //match id
        for(int i=0; i<ingredientStock.Count; i++)
        {
            if (ingredientStock[i].ID == newIng.ID)
            {
                //match quality
                if(ingredientStock[i].quality == newIng.quality)
                {
                    //matched, so increas amount
                    ingredientStock[i].amount += 1;
                    wasAdded = true;
                    break;
                }
            }
        }//end for loop

        //if it wasn't added, do so now
        if (!wasAdded)
        {
            newIng.amount = 1;  //make sure amount is one
            ingredientStock.Add(newIng);
        }
    }

    public List<Ingredient> GetIngredientsByID(int targetID)
    {
        List<Ingredient> result = new List<Ingredient>();

        for(int i=0; i<ingredientStock.Count; i++)
        {
            if (ingredientStock[i].ID == targetID) result.Add(ingredientStock[i]);
        }

        return result;
    }

    public Ingredient GetIngredientByNameAndQuality(string targetName, int targetQuality)
    {
        Ingredient result = null;

        for(int i=0; i<ingredientStock.Count; i++)
        {
            if(ingredientStock[i].name == targetName && ingredientStock[i].quality == targetQuality)
            {
                result = ingredientStock[i];
                break;
            }
        }

        return result;
    }

    public void ConsumeIngredients(Ingredient[] ingredientList)
    {
        for(int i=0; i<ingredientList.Length; i++)
        {
            foreach(Ingredient curIng in ingredientStock)
            {
                if(curIng.ID == ingredientList[i].ID && curIng.quality == ingredientList[i].quality)
                {
                    curIng.amount -= 1;
                }
            }
        }//end outer for

        CleanUpIngredients();
    }

    public void CleanUpIngredients()
    {
        int curIndex = 0;

        while(curIndex < ingredientStock.Count)
        {
            if(ingredientStock[curIndex].amount <= 0)
            {
                ingredientStock.RemoveAt(curIndex);
            }
            else
            {
                curIndex += 1;
            }
        }
    }
    
}

