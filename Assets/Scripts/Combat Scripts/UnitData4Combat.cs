using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData4Combat : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public string Description;
    private float currentHP;
    private float currentMP;
    private int status = -1;
    private int[] initialStats = new int[7];
    private int[] CurrentStats = new int[7];
    private float[] initialstatusResistances = new float[4];
    private float[] CurrentstatusResistances = new float[4];
    private float[] initialElementResistances = new float[4];
    private float[] CurrentElementResistances = new float[4];

    private int[] CurrentStatModifiers = new int[13];
    private int[] CurrentStatModifiersCD = new int[13];
    private bool isImmunetoNormal;
    Sprite currentSprite;

    int UnitSide; //negative is enemy side, positive is player side. Set by the game management and shit, used for dynamic camera system.

    int ABTBarCurrent;

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
