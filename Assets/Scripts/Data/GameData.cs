using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data")]
public class GameData : ScriptableObject
{
    [Header("Power-Up Base Cost")]
    public float range_base; //50
    public float throwRate_base; //50
    public float income_base; //100

    [Header("Power-Up Cost Increase")]
    public float range_increase; //5
    public float throwRate_increase; //5
    public float income_increase; //50

    [Header("Power-Up Level")]
    public float range_level; //1
    public float throwRate_level; //1
    public float income_level; //1

    [Header("In-Game Stats")]

    public float totalMoney;
    public float range_value;
    public float throwRate_value;
    public float income_value;

    
}
