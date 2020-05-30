using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Player", menuName = "New Player")]
public class PlayerSpriteInfo : ScriptableObject
{
    public Sprite[] FrontIdle = new Sprite[3];
    public Sprite[] FrontPhys = new Sprite[2];
    public Sprite[] FrontMag = new Sprite[2];

    public Sprite[] BackIdle = new Sprite[3];
    public Sprite[] BackPhys = new Sprite[2];
    public Sprite[] BackMag = new Sprite[2];

    public Sprite[] Win = new Sprite[2];

    public Sprite Hurt;
    public Sprite Death;
}
