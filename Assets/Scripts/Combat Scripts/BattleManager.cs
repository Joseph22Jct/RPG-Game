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
    [SerializeField] GameObject EnemySideUnit;
    
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
        PO.GetComponent<UnitData4Combat>().slot = 0;
        PO.GetComponent<PlayerBattleAnimation>().SetEquipment(0);
        PUnits.Add(PO);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(-2.5f,0,-14);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(1);
        PO.GetComponent<UnitData4Combat>().slot = 1;
        PO.GetComponent<PlayerBattleAnimation>().SetEquipment(1);
        PUnits.Add(PO);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(2.5f,0,-14);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(2);
        PO.GetComponent<UnitData4Combat>().slot = 2;
        PO.GetComponent<PlayerBattleAnimation>().SetEquipment(2);
        PUnits.Add(PO);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(7.5f,0,-12);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(3);
        PO.GetComponent<UnitData4Combat>().slot = 3;
        PO.GetComponent<PlayerBattleAnimation>().SetEquipment(3);
        PUnits.Add(PO);

        EnemyGroup EGroup = GameplayPartyManager.Instance.CurrentFight;

        for (int i = 0; i< EGroup.Enemies.Length; i++){
            PO = Instantiate(EnemySideUnit);
            PO.transform.parent = enemyside.transform;
            PO.transform.position = new Vector3(Mathf.Sin(( 90 + 180*i) * Mathf.Deg2Rad) * ((int) (i+1)/2) * 6 ,0,12);

            PO.GetComponent<UnitData4Combat>().slot = i +4;
            PO.GetComponent<UnitData4Combat>().InitializeEnemy(EGroup.Enemies[i]);
            PO.GetComponent<BattleEnemyAnimations>().InitializeEnemy(EGroup.Enemies[i]);
            PUnits.Add(PO);
            

        }
    

    }


//Set up Finite State Machine
}
