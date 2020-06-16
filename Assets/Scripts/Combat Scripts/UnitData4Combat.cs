using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData4Combat : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public string Description;
    public int currentHP;
    public int currentMP;
    public int status = -1;
    public int[] initialStats = new int[7];
    public int[] CurrentStats = new int[7];
    public float[] initialstatusResistances = new float[4];
    public float[] CurrentstatusResistances = new float[4];
    public float[] initialElementResistances = new float[4];
    public float[] CurrentElementResistances = new float[4];

    private int[] CurrentStatModifiers = new int[13];
    private int[] CurrentStatModifiersCD = new int[13];
    private bool isImmunetoNormal;
    Sprite currentSprite;
    public bool ChargeABTAllowed = false;

    private void Update() {
        if(ChargeABTAllowed&& ABTBarCurrent<maxABTBar ){

        }
    }
    

    int UnitSide; //negative is enemy side, positive is player side. Set by the game management and shit, used for dynamic camera system.
    public int slot;

    public float ABTBarCurrent;
    public float ABTRate;
    public float maxABTBar;
    private Moves[] ThisMoves = new Moves[1];

    //initialize unit 



    public UnitData4Combat InitializeHero(int slot){

        PlayableUnit Unit = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[slot]];
        currentHP = Unit.getCurrentHP();
        currentMP = Unit.getCurrentMP();
        status = Unit.getStatus();
        initialStats = Unit.getFinalStats();
        initialstatusResistances = Unit.getFinalStatusResistances();
        initialElementResistances = Unit.getFinalElemResistances();
        name = Unit.getName();
        Name = Unit.getName();
        Description = Unit.getDescrition();

        ThisMoves = Unit.GetMoves();

        CurrentStats = initialStats;
        CurrentElementResistances = initialElementResistances;
        CurrentstatusResistances = initialstatusResistances;



        return this;
    }

    public UnitData4Combat InitializeEnemy(EnemyClasses enemydata){
        initialStats = enemydata.BaseStats;
        currentHP = enemydata.BaseStats[0];
        currentMP = enemydata.BaseStats[1];
        initialstatusResistances= enemydata.innateStatusResistance;
        initialElementResistances = enemydata.innateElementResistance;
        name = enemydata.EnemyName;
        Name = enemydata.EnemyName;
        Description = enemydata.Description;

        CurrentStats = initialStats;
        CurrentElementResistances = initialElementResistances;
        CurrentstatusResistances = initialstatusResistances;
        ThisMoves= enemydata.availableMoves;


        return this;
    }


    void boostStat(int stat, int value){
        CurrentStatModifiers[stat] += value;
        CurrentStatModifiersCD[stat] = 3;
        
        CurrentStats[stat] = initialStats[stat] + (initialStats[stat]*CurrentStatModifiers[stat]/4); //ex 10+ 10*2/4 = 15
    }

    public void DecreaseBoostsperTurn(){ //Call this after every action

    }
    


//Enemy only Data
    
    void ActiontoTake(){

        //Bunch of if statements;
        //changes the moveToMake;
        //movetoMake will make the move when its the enemy turn.


    }
}
