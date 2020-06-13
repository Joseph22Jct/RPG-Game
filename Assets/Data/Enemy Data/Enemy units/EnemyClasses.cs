using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Enemy", menuName = "Enemies/New Enemy")]

public class EnemyClasses : ScriptableObject
{
    //Scriptable object that contains enemy information, name stats AI Actions available.
    public string EnemyName;
    public string Description;
    public int element;
    public bool replaceColors;
    public Color[] colors = new Color[8];
    
    public int[] BaseStats = new int[7];

    public float[] innateStatusResistance = new float[5]; //Carries percentage resistance to status effects.
    public float[] innateElementResistance = new float[4];
    public bool immuneToNormal;

    public Moves[] availableMoves = new Moves[1];

    public Sprite[] enemySprites = new Sprite[6]; //3 moving sprites front and back

    public AI defaultAI;

    //AI, check a video on how is usually handled. Maybe an array of numbers that mean something to the reading combatprefab?


}