﻿using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Witch
{
    public string name;
    public Sprite portrait;

    public string magicSchool;
    public Sprite magicSchoolImage;

    public Familiar familiar;
    public House house;

    public int dreams;      //stored Rea
    public int vision;      //Rea focus
    public int potential;   //Rea generation

    public int ko;          //money

    public TimeSpan elapsedTime;

    public Witch()
    {
        familiar = new Familiar();
        house = new House();
    }

    public string GetTime()
    {
        return elapsedTime.ToString();
    }

    public void ElapseTime(int minutes)
    {
        elapsedTime = elapsedTime.Add(new TimeSpan(0, minutes, 0));
    }
}
