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
        temp.gatherTime = 8;
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
        temp.gatherTime = 5;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Dragon Cow Milk";
        temp.gatherTime = 13;
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
        temp.gatherTime = 13;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Pheonix Egg Shells";
        temp.gatherTime = 13;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Tree Golem Moss";
        temp.gatherTime = 13;
        temp.quality = 1;
        temp.ID = GenericItem.GetNextID();
        temp.itemType = ItemType.Ingrediant;
        temp.sprite = null;
        masterIngredientList.Add(temp);

        temp = new Ingredient();
        temp.name = "Stone Golem Moss";
        temp.gatherTime = 13;
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

    void SetupZoneList()
    {
        Zone temp;

        temp = new Zone();
        temp.name = "Forest of Threads";
        temp.description = "A dense forest filled with ghost spiders.  And webs.  Lots of webs.";
        temp.sprite = Resources.Load<Sprite>(@"Sprites\Zone_Forest_01");
        temp.ingredients.Add(GetIngredientReferenceByName("Forest Coffee Bean"));
        temp.ingredients.Add(GetIngredientReferenceByName("Tree Golem Moss"));
        temp.ingredients.Add(GetIngredientReferenceByName("Dragon's Tooth"));
        masterZoneList.Add(temp);

        temp = new Zone();
        temp.name = "Sky over Komana";
        temp.description = "Open and calm skies around Komana.  Home to a lot of Dragon Ducks.";
        temp.sprite = Resources.Load<Sprite>(@"Sprites\Zone_Sky_01");
        temp.ingredients.Add(GetIngredientReferenceByName("Dragon Drake Feather"));
        temp.ingredients.Add(GetIngredientReferenceByName("Dragon Cow Milk"));
        temp.ingredients.Add(GetIngredientReferenceByName("Pearls of Mist (thunder)"));
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

