using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvents : MonoBehaviour //What if this were Battle Events Instead? Where theres Caster, Targets, and action, on a queue!
{

    public int[] targets = new int[12];
    public int Caster;
    public Actions thisAction;
}

