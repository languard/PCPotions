using System;
using System.Collections.Generic;
using UnityEngine;


public class Ingredient : GenericItem, ICloneable
{
    public int quality;
    public int gatherTime;
    public int amount = 0;

    public object Clone()
    {
        Ingredient temp = new Ingredient();
        temp.quality = this.quality;
        temp.gatherTime = this.gatherTime;
        temp.name = this.name;
        temp.sprite = this.sprite;
        temp.ID = this.ID;
        temp.itemType = this.itemType;
        return temp;
    }
}

