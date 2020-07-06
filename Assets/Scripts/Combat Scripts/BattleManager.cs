using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleManager : MonoBehaviour
{
    public delegate void state();
    state currentState;
    public delegate void changeState();
    changeState CcState;

    float ActiveTimeTimer;
    float timeaddmult;

    private static BattleManager _instance;
    public static BattleManager Instance{
        get{
            
            return _instance;
        }
    }
    private void Awake() {
        _instance = this;
    }

    public BattleUnitDataUI[] BUI = new BattleUnitDataUI[4];

    public Queue<BattleEvents> BattleQueue = new Queue<BattleEvents>();

   

    [SerializeField] GameObject playerside;
    [SerializeField] GameObject enemyside;
    [SerializeField] GameObject PlayerSideUnit;
    [SerializeField] GameObject EnemySideUnit;
    
    [SerializeField] List<UnitData4Combat> ControllableUnits = new List<UnitData4Combat>();

    [SerializeField] List<UnitData4Combat> EnemyUnits = new List<UnitData4Combat>();
    
    [SerializeField] public List<GameObject> PUnits = new List<GameObject>();

    public List<UnitData4Combat> UnitData = new List<UnitData4Combat>();

     public Queue<Phases> listOfPhases = new Queue<Phases>();

    void OnEnable(){
       

        currentState = SetUpBattle;

    }

    private void Update() {
        currentState();
    }
    public float MaxABT = 1;

    void SetUpBattle(){
        
        
        GameObject PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(-7.5f,0,-12);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(0);
        PO.GetComponent<UnitData4Combat>().slot = 0;
        UnitData.Add(PO.GetComponent<UnitData4Combat>());
        PO.GetComponent<PlayerBattleAnimation>().SetEquipment(0);
        PUnits.Add(PO);
        BUI[0].InitializeHero(UnitData[0]);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(-2.5f,0,-14);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(1);
        PO.GetComponent<UnitData4Combat>().slot = 1;
        UnitData.Add(PO.GetComponent<UnitData4Combat>());
        PO.GetComponent<PlayerBattleAnimation>().SetEquipment(1);
        PUnits.Add(PO);
        BUI[1].InitializeHero(UnitData[1]);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(2.5f,0,-14);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(2);
        PO.GetComponent<UnitData4Combat>().slot = 2;
        UnitData.Add(PO.GetComponent<UnitData4Combat>());
        PO.GetComponent<PlayerBattleAnimation>().SetEquipment(2);
        PUnits.Add(PO);
        BUI[2].InitializeHero(UnitData[2]);
        PO = Instantiate(PlayerSideUnit);
        PO.transform.position = new Vector3(7.5f,0,-12);
        PO.transform.parent = playerside.transform;
        PO.GetComponent<UnitData4Combat>().InitializeHero(3);
        PO.GetComponent<UnitData4Combat>().slot = 3;
        UnitData.Add(PO.GetComponent<UnitData4Combat>());
        PO.GetComponent<PlayerBattleAnimation>().SetEquipment(3);
        PUnits.Add(PO);
        BUI[3].InitializeHero(UnitData[3]);

        EnemyGroup EGroup = GameplayPartyManager.Instance.CurrentFight;

        for (int i = 0; i< EGroup.Enemies.Length; i++){
            PO = Instantiate(EnemySideUnit);
            PO.transform.parent = enemyside.transform;
            PO.transform.position = new Vector3(Mathf.Sin(( 90 + 180*i) * Mathf.Deg2Rad) * ((int) (i+1)/2) * 6 ,0,12);

            PO.GetComponent<UnitData4Combat>().slot = i +4;
            UnitData.Add(PO.GetComponent<UnitData4Combat>());
            PO.GetComponent<UnitData4Combat>().InitializeEnemy(EGroup.Enemies[i]);
            PO.GetComponent<BattleEnemyAnimations>().InitializeEnemy(EGroup.Enemies[i]);
            PUnits.Add(PO);
            

        }

        int maxSpeed =UnitData[0].initialStats[6]; //speed
        int minSpeed = UnitData[0].initialStats[6];
        for(int i = 1; i<UnitData.Count; i++){    
            int checkspeed = UnitData[i].initialStats[6];
            if(maxSpeed < checkspeed){
                maxSpeed = checkspeed;
            }
            if(minSpeed > checkspeed){
                minSpeed = checkspeed;
            }
        }

        float compare;
        for(int i = 0; i<UnitData.Count; i++){
            
            compare = UnitData[i].initialStats[6]/maxSpeed;
            if(compare >0.2) //5 seconds
            UnitData[i].ABTRate = UnitData[i].initialStats[6]/maxSpeed;
            else{
                UnitData[i].ABTRate = 0.2f;
            }
            UnitData[i].maxABTBar = MaxABT;
            UnitData[i].ABTBarCurrent = MaxABT/2;

        }

        currentState = BattleIntro;
    

    }

    public void BattleIntro(){

        currentState = BattlePrep;
    }

    public void BattlePrep(){
        for(int i = 0; i< UnitData.Count; i++){
            UnitData[i].ChargeABTAllowed = true;
        }

        currentState = BattleWait;
    }

    public void BattleWait(){
        if(BattleQueue.Count!=0){
            //Register battle.
            currentState = ExecuteEvent;
        }

        
    }

    BattleEvents CurrentEvent;
    Phases CurrentPhase;
    public void ExecuteEvent(){
        if(CurrentEvent == null)
        CurrentEvent = BattleQueue.Dequeue();
        CurrentEvent.thisMove.BattleAction.Effect();
        if(listOfPhases.Count >0){
        CurrentPhase = listOfPhases.Dequeue();
        switch(CurrentPhase.showntype){
            case 0: //Animation
            AnimCount = 0;
            AnimTime = 0;
            CurrentAnim = Animations[0];
            currentState = AnimationPhase;

            break;
            case 1: //Attack
            currentState = DamageDealt;

            break;
            case 2: //Heal
            break; 
            case 3: //Status Recover
            break;
            case 4: //Inflict Status
            break;
            case 5: //Resurrect
            break;

            //Add the rest.
            default: break;

        }
        }
        else{
            CurrentEvent = null;
            currentState = BattleWait;
        }
    }

    public List<AnimationStep> Animations = new List<AnimationStep>();
    public AnimationStep CurrentAnim;
    int AnimCount;
    float AnimTime;
    public void AnimationPhase(){
        AnimTime+= Time.deltaTime;
        

        if (AnimTime>= CurrentAnim.Timer){ // Execute when timer hits
        

        switch(CurrentAnim.typeOfAnimation){
            case 0: //MoveCamera
            BattleCamera.Instance.MoveCamera(CurrentAnim.TargetT.position, CurrentAnim.speed, CurrentAnim.ObjLookAt.transform.position);

            break;
            case 1: //Movechar
            break;
            case 2: //PlayParticleEffect
            break; 
            case 3: //Change Frame
            break;

            case -1: //End
            currentState = ExecuteEvent;
            break;
            

            //Add the rest.
            default: break;

        }
        AnimCount++;
        CurrentAnim = Animations[AnimCount];
        
            
        }
        

    }

    public void DamageDealt(){

        for (int i = 0; i<PUnits.Count; i++){

            if(CurrentPhase.targets[i] > 0)
            PUnits[i].transform.DOLocalMoveX(PUnits[i].transform.position.x, 1).SetEase(Ease.InOutSine);

        }

        currentState = ExecuteEvent;

    }




//Set up Finite State Machine
}
