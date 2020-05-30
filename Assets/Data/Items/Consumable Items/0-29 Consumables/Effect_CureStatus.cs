using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName="OverworldActions/CureStatus")]
public class Effect_CureStatus : OWEffect
{
    
    public override bool Effect(PlayableUnit[] Targets, Consumables item){
        bool wentThrough = false;
        for(int i = 0; i<Targets.Length; i++){
            if(Targets[i].getStatus() == item.restoresWhichStatus || item.restoresWhichStatus == -1) {
            Targets[i].setStatus(-1);
            wentThrough = true;
            }
        }
        
        return wentThrough;
    }
}
