using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OWEffect : ScriptableObject
{
    public abstract bool Effect(PlayableUnit[] Targets, Consumables item);

}
