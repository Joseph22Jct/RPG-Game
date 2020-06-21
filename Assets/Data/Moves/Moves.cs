using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName= "New Move", menuName = "Moves/New Move")]
public class Moves : ScriptableObject
{
    public Actions BattleAction;
    public int MPCost;
    public int ID;
    public int HPCost;
    public int HPPercentCost;
    public OWEffect OverworldEffect;

    public int[] targets = new int[12];
    public int whichsidetoTarget= 0; //0 for enemy
    public GameObject anim;
}
