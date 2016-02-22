using System;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase
{
    #region "Singleton hack"
    private static GameDatabase _instance;
    public static GameDatabase Instance {
        get
        {
            if (_instance == null) _instance = new GameDatabase();
            return _instance;
        }
    }
    #endregion

    List<Ingredient> masterIngredientList;
    List<Potion> masterPotionList;
    List<Zone> masterZoneList;

    private GameDatabase()
    {
        masterIngredientList = new List<Ingredient>();
        SetupIngredientsList();

        masterPotionList = new List<Potion>();
        SetupPotionList();

        masterZoneList = new List<Zone>();
        SetupZoneList();
    }

    void SetupIngredientsList()
    {
        //HAAAAAAAAAAAAAACKS!!!!!!!!11!1!
        Ingredient temp;

        temp = new Ingredient();
        temp.name = "Dragon's Tooth";
        temp.gatherTime = 3;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Pearls of Mist (thunder)";
        temp.gatherTime = 15;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Pearls of Mist (snow)";
        temp.gatherTime = 8;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Moose Dragon Fur";
        temp.gatherTime = 9;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Dragon Cow Milk";
        temp.gatherTime = 18;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Dragon Drake Feather";
        temp.gatherTime = 13;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Forest Coffee Bean";
        temp.gatherTime = 5;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Pheonix Egg Shells";
        temp.gatherTime = 23;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Tree Golem Moss";
        temp.gatherTime = 10;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Stone Golem Moss";
        temp.gatherTime = 10;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

    }

    public List<Ingredient> GetFullIngredientList()
    {
        List<Ingredient> temp = new List<Ingredient>();
        foreach(Ingredient cur in _instance.masterIngredientList)
        {
            Ingredient newIng = cur.Clone() as Ingredient;
            temp.Add(newIng);
        }
        return temp;
    }

    public Ingredient GetIngredientByName(string name)
    {
        Ingredient result = null;

        for(int i=0; i<masterIngredientList.Count; i++)
        {
            if(masterIngredientList[i].name == name)
            {
                result = masterIngredientList[i].Clone() as Ingredient;
            }
        }

        return result;
    }

    public int GetIngredientIDByName(string name)
    {
        int result = -1;

        for (int i = 0; i < masterIngredientList.Count; i++)
        {
            if (masterIngredientList[i].name == name)
            {
                result = masterIngredientList[i].ID;
            }
        }

        return result;
    }

    public string GetIngredientNameByID(int ID)
    {
        string result = "NOT FOUND";

        for (int i = 0; i < masterIngredientList.Count; i++)
        {
            if (masterIngredientList[i].ID == ID)
            {
                result = masterIngredientList[i].name;
            }
        }

        return result;
    }

    public Ingredient GetIngredientReferenceByName(string name)
    {
        Ingredient result = null;

        for (int i = 0; i < masterIngredientList.Count; i++)
        {
            if (masterIngredientList[i].name == name)
            {
                result = masterIngredientList[i];
                break;
            }
        }

        return result;
    }

    public Ingredient GetIngredientReferenceByID(int ID)
    {
        Ingredient result = null;

        for(int i=0; i<masterIngredientList.Count; i++)
        {
            if(masterIngredientList[i].ID == ID)
            {
                result = masterIngredientList[i];
                break;
            }
        }

        return result;
    }

    public void SetupPotionList()
    {
        Potion temp;

        temp = new Potion();
        temp.name = "Snowy Cofee";
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Potion;
        temp.sprite = null;
        temp.baseReaCost = 10;
        temp.valueBase = 5;
        temp.qualityScale = 0.75f;
        temp.brewTime = 45;
        temp.AddIngredient(masterIngredientList[2]);
        temp.AddIngredient(masterIngredientList[7]);
        temp.AddIngredient(masterIngredientList[6]);
        masterPotionList.Add(temp);

        temp = new Potion();
        temp.name = "Laughing";
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Potion;
        temp.sprite = null;
        temp.baseReaCost = 35;
        temp.valueBase = 25;
        temp.qualityScale = 1.15f;
        temp.brewTime = 80;
        temp.AddIngredient(masterIngredientList[8]);
        temp.AddIngredient(masterIngredientList[9]);
        temp.AddIngredient(masterIngredientList[5]);
        masterPotionList.Add(temp);

        temp = new Potion();
        temp.name = "Re-Animation";
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Potion;
        temp.sprite = null;
        temp.baseReaCost = 75;
        temp.valueBase = 120;
        temp.qualityScale = 1.75f;
        temp.brewTime = 120;
        temp.AddIngredient(masterIngredientList[0]);
        temp.AddIngredient(masterIngredientList[1]);
        temp.AddIngredient(masterIngredientList[3]);
        masterPotionList.Add(temp);

        temp = new Potion();
        temp.name = "Mega-Hairgrowth";
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Potion;
        temp.sprite = null;
        temp.baseReaCost = 51;
        temp.valueBase = 80;
        temp.qualityScale = 1.75f;
        temp.brewTime = 100;
        temp.AddIngredient(masterIngredientList[3]);
        temp.AddIngredient(masterIngredientList[4]);
        temp.AddIngredient(masterIngredientList[5]);
        masterPotionList.Add(temp);

        temp = new Potion();
        temp.name = "Bright Side";
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Potion;
        temp.sprite = null;
        temp.baseReaCost = 80;
        temp.valueBase = 100;
        temp.qualityScale = 1.45f;
        temp.brewTime = 107;
        temp.AddIngredient(masterIngredientList[2]);
        temp.AddIngredient(masterIngredientList[7]);
        temp.AddIngredient(masterIngredientList[5]);
        masterPotionList.Add(temp);

        temp = new Potion();
        temp.name = "Poshness";
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Potion;
        temp.sprite = null;
        temp.baseReaCost = 125;
        temp.valueBase = 290;
        temp.qualityScale = 2.75f;
        temp.brewTime = 313;
        temp.AddIngredient(masterIngredientList[3]);
        temp.AddIngredient(masterIngredientList[4]);
        temp.AddIngredient(masterIngredientList[5]);
        masterPotionList.Add(temp);


    }

    public Potion GetPotionReferenceByName(string name)
    {
        Potion result = null;

        for(int i=0; i<masterPotionList.Count; i++)
        {
            if (masterPotionList[i].name == name) result = masterPotionList[i];
        }

        return result;
    }

    public Potion GetPotionReferenceByIndex(int index)
    {
        Potion result = null;
        if (index < masterPotionList.Count) result = masterPotionList[index];
        return result;
    }

    public List<Potion> GetPotionListReference()
    {
        return masterPotionList;
    }

    void SetupZoneList()
    {
        Zone temp;

        temp = new Zone();
        temp.name = "Forest of Threads";
        temp.description = "A dense forest filled with ghost spiders.  And webs.  Lots of webs.  Also, strangely enough, pheonixs. How they avoid burning down the forest is anybody's guess.";
        temp.spriteName = "Zone_Forest_01";
        temp.ingredients.Add(GetIngredientReferenceByName("Forest Coffee Bean"));
        temp.ingredients.Add(GetIngredientReferenceByName("Tree Golem Moss"));
        temp.ingredients.Add(GetIngredientReferenceByName("Stone Golem Moss"));
        temp.ingredients.Add(GetIngredientReferenceByName("Dragon's Tooth"));
        temp.ingredients.Add(GetIngredientReferenceByName("Pheonix Egg Shells"));
        masterZoneList.Add(temp);

        temp = new Zone();
        temp.name = "Sky over Komana";
        temp.description = "Open and calm skies around Komana.  Home to a lot of Dragon Ducks.";
        temp.spriteName = "Zone_Sky_01";
        temp.ingredients.Add(GetIngredientReferenceByName("Dragon Drake Feather"));
        temp.ingredients.Add(GetIngredientReferenceByName("Dragon Cow Milk"));
        temp.ingredients.Add(GetIngredientReferenceByName("Pearls of Mist (thunder)"));
        temp.ingredients.Add(GetIngredientReferenceByName("Pearls of Mist (snow)"));
        temp.ingredients.Add(GetIngredientReferenceByName("Moose Dragon Fur"));
        masterZoneList.Add(temp);
    }

    public Zone GetZoneReferenceByName(string name)
    {
        Zone result = null;

        for(int i=0; i<masterZoneList.Count; i++)
        {
            if(masterZoneList[i].name == name)
            {
                result = masterZoneList[i];
                break;
            }
        }

        return result;
    }
}

