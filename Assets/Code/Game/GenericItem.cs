using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum ItemType
{
    Ingrediant,
    Potion
}

[Serializable]
public class GenericItem
{

    #region "Static Methods and Properties"
    public static int[] threshold = new int[20];
    public static string[] thresholdLabels = new string[]
    {
        "Bad"           //1
        ,"Low"          //2
        ,"Low"          //3
        ,"Low"          //4
        ,"OK"           //5
        ,"OK"           //6
        ,"OK"           //7
        ,"Good"         //8
        ,"Good"         //9
        ,"Good"         //10
        ,"Excellent"    //11
        ,"Excellent"    //12
        ,"Ecellent"     //13    
        ,"Wonderous"    //14
        ,"Wonderous"    //15
        ,"Wonderous"    //16
        ,"Wonderous"    //17
        ,"Peerless"     //18
        ,"Peerless"     //19
        ,"Of the Gods"  //20
    };
    private static int _currentID = 0;  //zero will be skipped.
    public static int GetNextID()
    {
        _currentID += 1;
        return _currentID;
    }

    public static int GetThresholdValue(int level)
    {
        return threshold[level];
    }

    public static string GetThresholdName(int level)
    {
        return thresholdLabels[level];
    }

    public static int GetThresholdLevel(int value)
    {
        int lastLevel = 0;
        for(int i=0; i<20; i++)
        {
            if (value >= threshold[i]) lastLevel = i;
            else break;
        }

        return lastLevel;
    }

    //simple precalculated lookup table for the Fibonacci sequence to 20, starting with 2
    public static void GenerateThreshold()
    {
        int a = 1;
        int b = 2;
        int temp = 0;
        for(int i=0; i<20; i++)
        {
            UnityEngine.Debug.Log(b.ToString());
            threshold[i] = b;
            temp = b;
            b = a + b;
            a = temp;            
        }
    }
    #endregion

    

    public string name;
    public Sprite sprite;
    public int ID;
    public ItemType itemType;

}

