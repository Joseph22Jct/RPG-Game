using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName="OverworldActions/ManaGains")]
public class Effect_ManaGain : OWEffect
{
    
    public override bool Effect(PlayableUnit[] Targets, Consumables item){
        bool wentThrough = false;
        
        for(int i = 0; i<Targets.Length; i++){
            if(Targets[i].getCurrentMP() < Targets[i].getFinalStats()[1]){
            Targets[i].addCurrentMP(item.managains);
            wentThrough = true;
            }
        }
        return wentThrough;
    }
}
