using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName= "New Move", menuName = "Moves/New Move")]
public class Moves : ScriptableObject
{

    public string Name;

    public string Description;

    public Sprite Icon;
    public Actions BattleAction;
    public int MPCost;
    public int ID;
    public int HPCost;
    public int HPPercentCost;
    public OWEffect OverworldEffect;

    public int[] WeaponTypesAllowed = new int[1];

    public int[] targets = new int[12];
    public bool TargetAllies; //0 for enemy

}
