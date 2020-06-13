using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Equipment", menuName = "Items/New Equipment")]
public class UsableEquipment : ScriptableObject
{
    //Scriptable object, has an ID, name, stat increase, effect, weapon mastery exp limit (int) and Mastery Reward
    public Color[] colors = new Color[8];
    
    

    public int EquipmentType; // 0 = weapon, 1 = Head, 2 = Chest, 3 = Legs.
    public int maxEXP;
    

    

    public int[] boosts = new int[7];
    public float[] resBoosts = new float[4]; //Ailment resistances
    public float[] elementalresBoosts = new float[4];
    public EquipMasteryReward Reward;

    
    public int ElementalType;
    public int WeaponAccuracy;

    public Sprite[] SouthWalking = new Sprite[3];
    public Sprite[] NorthWalking = new Sprite[3];
    public Sprite[] EastWalking = new Sprite[3];
    public Sprite[] WestWalking = new Sprite[3];
    public Sprite[] PrepAttack = new Sprite[2];

    public Sprite[] WeaponSprite = new Sprite[2];

    public Sprite Hurt;
    public Sprite Death;

    //

    
    
}
