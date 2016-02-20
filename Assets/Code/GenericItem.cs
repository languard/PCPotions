using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GenericItem
{

    #region "Static Methods and Properties"
    public static int[] threshold = new int[20];
    public static string[] thresholdLabels = new string[]
    {
        "Bad"
        ,"Low"
        ,"Low"
        ,"Low"
        ,"OK"
        ,"OK"
        ,"OK"
        ,"Good"
        ,"Good"
        ,"Good"
        ,"Excellent"
        ,"Excellent"
        ,"Ecellent"
        ,"Wonderous"
        ,"Wonderous"
        ,"Wonderous"
        ,"Wonderous"
        ,"Peerless"
        ,"Peerless"
        ,"Of the Gods"
    };

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
}

