using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "AI", menuName = "Enemies/AI")]
public abstract class AI : ScriptableObject
{
    public abstract void Effect();
}
