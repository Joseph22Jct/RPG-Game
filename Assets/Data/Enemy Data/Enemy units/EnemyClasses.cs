using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Enemy", menuName = "New Enemy")]

public class EnemyClasses : ScriptableObject
{
    //Scriptable object that contains enemy information, name stats AI Actions available.
    public string EnemyName;
    public string Description;
    public int[] BaseStats = new int[7];
    public int element;

    public float[] innateStatusResistance = new float[5]; //Carries percentage resistance to status effects.
    public float[] innateElementResistance = new float[4];
    public bool immuneToNormal;

    public Sprite[] enemySprites = new Sprite[6]; //2 attack sprites, 3 idle, 1 being hit.

    //AI, check a video on how is usually handled. Maybe an array of numbers that mean something to the reading combatprefab?


}