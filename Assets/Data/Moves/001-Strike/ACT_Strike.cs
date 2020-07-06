using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName="Moves/Actions/Strike")]
public class ACT_Strike : Actions
{   

    public override void Effect(){

        List<AnimationStep> AnimationSteps = new List<AnimationStep>();
        AnimationSteps.Add(new AnimationStep().MoveCamera(0, CameraAnchors.Instance.PlayerSide, CameraAnchors.Instance.EnemySide,3,0.1f));

        int[] targets = BattleMediator.Instance.GetTargets();

            string messagestart = BattleManager.Instance.UnitData[BattleMediator.Instance.initiator].Name + " struck...";
            
            

        for(int i = 0; i<12; i++){
            
            if(targets[i]>=0){

                if(Random.Range(0,1) < (float)BattleMediator.Instance.moveAccuracy /100){
                    targets[i] = (int) ((float) 
                    (BattleManager.Instance.UnitData[BattleMediator.Instance.initiator].CurrentStats[2]- BattleManager.Instance.UnitData[i].CurrentStats[3] ) //Attack vs Defense
                    *3  //Damage multiplier
                    * (BattleManager.Instance.UnitData[i].CurrentElementResistances[BattleMediator.Instance.initelement]+100/100)); //Element
                }
                else{
                    targets[i] = -2; //missed
                }

            }
        }

    
        
        Queue<Phases> listOfPhases = new Queue<Phases>();
        listOfPhases.Enqueue(new Phases(0, messagestart, targets));
        listOfPhases.Enqueue(new Phases(1, "", targets));

        BattleManager.Instance.listOfPhases = listOfPhases;
        BattleManager.Instance.Animations = AnimationSteps;
        

        

        
    }
}
