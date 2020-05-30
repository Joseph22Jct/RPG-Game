using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Reward", menuName = "New Reward")]
public class EquipMasteryReward : ScriptableObject
{
    
    public int[] isStatBoosts = new int[7];
    public float[] isStatusRes = new float[5];
    public float[] isElementRes = new float[4];
}
