using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Enemy", menuName = "Enemies/New Enemy")]

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

    public Sprite[] enemySprites = new Sprite[3]; //3 moving sprites

    //AI, check a video on how is usually handled. Maybe an array of numbers that mean something to the reading combatprefab?


}