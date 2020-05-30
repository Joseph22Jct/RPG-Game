using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName="OverworldActions/HealUnits")]
public class Effect_Heal : OWEffect
{
    
    public override bool Effect(PlayableUnit[] Targets, Consumables item){
        bool wentThrough = false;
        for(int i = 0; i<Targets.Length; i++){
            if(Targets[i].getCurrentHP() < Targets[i].getFinalStats()[0]){
            Targets[i].addCurrentHP(item.healsfor);
            wentThrough = true;
            }
        }
        
        return wentThrough;
    }
}
