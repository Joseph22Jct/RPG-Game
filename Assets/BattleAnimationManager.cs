using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimationManager : MonoBehaviour
{
    private static BattleAnimationManager _instance;
    public static BattleAnimationManager Instance{
        get{
            
            
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
    }

    public void PlayAnimation(){
        //Play Animation from animation script.

        //Animation Id check, if already played, just use the one that was already spawned, otherwise instanciate it.
    }

    

    
}
