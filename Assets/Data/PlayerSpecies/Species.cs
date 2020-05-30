using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Species", menuName = "New Species")]
public class Species : ScriptableObject
{
    public int SpeciesName;
    public Sprite icon;
    public Sprite[] HeadSprites = new Sprite[4]; //Normal, Happy, Defeated, Inflicted
    
}
