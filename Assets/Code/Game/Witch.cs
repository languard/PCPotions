using System;
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

    public int dreams;      //stored Rea
    public int vision;      //Rea focus
    public int potential;   //Rea generation

    public int ko;          //money


    public Witch()
    {
        familiar = new Familiar();
    }
}
