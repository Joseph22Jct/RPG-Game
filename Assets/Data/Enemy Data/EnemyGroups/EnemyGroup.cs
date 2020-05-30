﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Enemy Group", menuName = "New Enemy Group")]

public class EnemyGroup : ScriptableObject
{
    public EnemyClasses[] Enemies = new EnemyClasses[1];
    public Entrance entranceType;

    public string Music;
    public string LowHPMusic;


    //AI, check a video on how is usually handled. Maybe an array of numbers that mean something to the reading combatprefab?


}