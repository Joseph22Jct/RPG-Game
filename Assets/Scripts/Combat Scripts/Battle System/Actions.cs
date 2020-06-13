using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions : MonoBehaviour
{
    public abstract void Effect();
    public int[] targets = new int[12];
    public int whichsidetoTarget;
    public GameObject anim;
}

/*
Example:

Effect(){
    GetTargets.
    for int i, i - 0....
    if targets[i] = 1
    int damage = 100* Caster.SPAtk - Target[i].SpDef (Enum to get calcs faster?)
    Targets[i] = damage;
    Text shown = "This and this happened! with target1 and target2 names"
    BattleManager.addPhases(1, targets)

    new targets[]
    target[Caster.slot] = OGTargets/2;
    BattleManager.addPhases(2, targets) (Heal!)
}


*/
