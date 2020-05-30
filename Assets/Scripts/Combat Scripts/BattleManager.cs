using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public delegate void state();
    state currentState;
    public delegate void changeState();
    changeState CcState;

    [SerializeField] GameObject playerside;
    [SerializeField] GameObject enemyside;

    [SerializeField] List<UnitData4Combat> AllUnits = new List<UnitData4Combat>();
    

    void Start(){

        SetUpBattle();

    }

    void SetUpBattle(){

    }

}
