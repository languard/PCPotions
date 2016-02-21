﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Zone
{
    public string name;
    public Sprite sprite;
    public string description;
    public List<Ingredient> ingredients;
    public int travelTime;  //in minutes;

    public Zone()
    {
        ingredients = new List<Ingredient>(0);
    }
}
