using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMediator : MonoBehaviour 
{

    private static BattleMediator _instance;
    public static BattleMediator Instance{
        get{
            
            
            return _instance;
        }
    }

    private void Awake() {
        if(_instance == null)
        _instance = this;
        else{
            Destroy(this.gameObject);
            return;
        }
        
    }

    public int[] targets = new int[12];
    public int initiator;

    public int initelement;

    public int moveAccuracy;

    public int[] GetTargets(){
        return targets;
    }

    BattleEvents currentEvent;
    
}
