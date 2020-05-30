using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName="OverworldActions/ChangeStats")]
public class Effect_ChangeStats : OWEffect
{
    
    public override bool Effect(PlayableUnit[] Targets, Consumables item){
        bool wentThrough = false;
        for(int i = 0; i<Targets.Length; i++){

            for(int e = 0; e<item.StatModifiers.Length ; e++){
                
                if(Targets[i].getCurrentStats()[e] >= 0 && Targets[i].getCurrentStats()[e] <= 999 ){
                    Targets[i].setCurrentStats(e,item.StatModifiers[e]);
                    if(Targets[i].getCurrentStats()[e] >999){
                        Targets[i].setCurrentStats(e,999);
                    }
                    if(Targets[i].getCurrentStats()[e] <0){
                        Targets[i].setCurrentStats(e,0);
                    }
                    wentThrough = true;
                }
            }

            
            
        }
        
        return wentThrough;
    }
}
