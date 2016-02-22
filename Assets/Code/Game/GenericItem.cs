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
        "Pathetic (1)"           //1
        ,"Super Cheap (2)"          //2
        ,"Very Cheap (3)"          //3
        ,"Cheap (4)"          //4
        ,"Somewhat OK (5)"           //5
        ,"Mostly OK (6)"           //6
        ,"OK (7)"           //7
        ,"A Little Good (8)"         //8
        ,"Sorta Good (9)"         //9
        ,"Good (10)"         //10
        ,"Kinda Excellent (11)"    //11
        ,"Excellent (12)"    //12
        ,"Really Excellent (13)"     //13    
        ,"A Bit Wonderous (14)"    //14
        ,"Wonderous (15)"    //15
        ,"Very Wonderous (16)"    //16
        ,"Wonderfuly Wonderous (17)"    //17
        ,"Peerless (18)"     //18
        ,"Mythical (19)"     //19
        ,"Of the Gods (20)"  //20
    };
    private static int _currentID = 0;  //zero will be skipped.
    public static int GetNextID()
    {
        _currentID += 1;
        return _currentID;
    }

    /// <summary>
    /// Assumes Level is 1-20.
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static int GetThresholdValue(int level)
    {
        int target = level - 1;
        if (target >= 20) return threshold[19];
        else return threshold[target];
    }

    public static string GetThresholdName(int level)
    {
        int target = level - 1;
        if (target > 19) return thresholdLabels[19];
        else return thresholdLabels[target];
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

    public static int GetQualityByName(string target)
    {
        int result = -1;
        for(int i=0; i<thresholdLabels.Length; i++)
        {
            if(thresholdLabels[i] == target)
            {
                result = i;
                break;
            }
        }
        return result;
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

