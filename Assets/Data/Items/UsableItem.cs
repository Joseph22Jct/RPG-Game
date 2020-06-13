using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName= "New Item", menuName = "Items/New Item")]
public class UsableItem : ScriptableObject
{
     public string ClassName;
    public string Description;
    public Sprite icon;
    public int ID;

    public UsableEquipment isEquip;

    public Consumables isConsumable;
    public int buyCost;
    public bool isEmptyEquip;
    public bool isKeyItem;

    




}
