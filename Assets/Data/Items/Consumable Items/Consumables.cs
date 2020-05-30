using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Consumable", menuName = "New Consumable")]
public class Consumables : ScriptableObject
{
    public int ConsumableType; //0 HP Healing or mana, 1= Battle Items


     //if null it has no action
    public OWEffect[] effect = new OWEffect[1];
    public int healsfor;
    public int managains;
    public int restoresWhichStatus =-1; //-1 for none, -2 for all status.
    public bool multitarget; //if targets everyone in the party.
    public bool OverworldOnly;
    public int[] StatModifiers = new int[7];
    

}
