using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName="Moves/Actions/Strike")]
public class ACT_Strike : Actions
{   

    public override void Effect(){
        int[] targets = BattleMediator.Instance.GetTargets();

            string messagestart = BattleManager.Instance.UnitData[BattleMediator.Instance.initiator].Name + " struck...";
            
            

        for(int i = 0; i<12; i++){
            
            if(targets[i]!= -1){

                if(Random.Range(0,1) < (float)BattleMediator.Instance.moveAccuracy /100){
                    targets[i] = (BattleManager.Instance.UnitData[BattleMediator.Instance.initiator].CurrentStats[2]- BattleManager.Instance.UnitData[i].CurrentStats[3] ) *3;
                }
                else{
                    targets[i] = -2; //missed
                }

            }
        }
        
        Queue<Phases> listOfPhases = new Queue<Phases>();
        listOfPhases.Enqueue(new Phases(1, messagestart, targets));

        BattleManager.Instance.listOfPhases = listOfPhases;
        

        

        
    }
}
