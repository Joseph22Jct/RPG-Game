using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public delegate void state();
    state currentState;
    public delegate void changeState();
    changeState CcState;

    float ActiveTimeTimer;
    float timeaddmult;

   

    [SerializeField] GameObject playerside;
    [SerializeField] GameObject enemyside;
    [SerializeField] GameObject PlayerSideUnit;
    
    [SerializeField] List<UnitData4Combat> ControllableUnits = new List<UnitData4Combat>();

    [SerializeField] List<UnitData4Combat> EnemyUnits = new List<UnitData4Combat>();
    
    [SerializeField] List<GameObject> PUnits = new List<GameObject>();

    void Awake(){

        SetUpBattle();

    }

    void SetUpBattle(){
        
        
        GameObject PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(-7.5f,0,-12);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(0);
        PO.GetComponentsInChildren<PlayerUnitAnimation>()[0].SetEquipment(0);
        PO.GetComponentsInChildren<PlayerUnitAnimation>()[1].SetEquipment(0);
        PUnits.Add(PO);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(-2.5f,0,-14);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(1);
        PO.GetComponentsInChildren<PlayerUnitAnimation>()[0].SetEquipment(1);
        PO.GetComponentsInChildren<PlayerUnitAnimation>()[1].SetEquipment(1);
        PUnits.Add(PO);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(2.5f,0,-14);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(2);
        PO.GetComponentsInChildren<PlayerUnitAnimation>()[0].SetEquipment(2);
        PO.GetComponentsInChildren<PlayerUnitAnimation>()[1].SetEquipment(2);
        PUnits.Add(PO);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(7.5f,0,-12);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(3);
        PO.GetComponentsInChildren<PlayerUnitAnimation>()[0].SetEquipment(3);
        PO.GetComponentsInChildren<PlayerUnitAnimation>()[1].SetEquipment(3);
        PUnits.Add(PO);
    

    }

}
