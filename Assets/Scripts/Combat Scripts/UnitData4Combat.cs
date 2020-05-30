using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData4Combat : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public string Description;
     [SerializeField] EnemyClasses enemydata;
     [SerializeField] PlayableUnit playerUnit;
    private float currentHP;
    private float currentMP;
    private int status = -1;
    private int[] initialStats = new int[7];
    private int[] CurrentStats = new int[7];
    private int[] CurrentStatModifiers = new int[5];
    private int[] CurrentStatModifierCD = new int[5]; //keeps track of each boosted stat.
    private float[] CurrentResistances = new float[5];
    private float[] CurrentElementResistances = new float[4];
    private bool isImmunetoNormal;
    Sprite currentSprite;

    int UnitSide; //negative is enemy side, positive is player side. Set by the game management and shit, used for dynamic camera system.

    int ABTBarCurrent;

    //initialize unit 

    void Awake(){
        if(enemydata!=null){
        initialStats = enemydata.BaseStats;
        currentHP = enemydata.BaseStats[0];
        currentMP = enemydata.BaseStats[1];
        CurrentResistances= enemydata.innateStatusResistance;
        CurrentElementResistances = enemydata.innateElementResistance;
        name = enemydata.EnemyName;
        Description = enemydata.Description;
        }

        else{
            currentHP = playerUnit.getCurrentHP();
            currentMP = playerUnit.getCurrentMP();
            status = playerUnit.getStatus();
            initialStats = playerUnit.getFinalStats();
            CurrentResistances = playerUnit.getFinalStatusResistances();
            CurrentElementResistances = playerUnit.getFinalElemResistances();
            name = playerUnit.getName();
            Description = playerUnit.getDescrition();
        }

        CurrentStats = initialStats;
        



    }

    void boostStat(int stat, int value){
        CurrentStatModifiers[stat] += value;
        CurrentStatModifierCD[stat] = 3;
        
        CurrentStats[stat] = initialStats[stat] + (initialStats[stat]*CurrentStatModifiers[stat]/4); //ex 10+ 10*2/4 = 15
    }

    


//Enemy only Data
    
    void ActiontoTake(){

        //Bunch of if statements;
        //changes the moveToMake;
        //movetoMake will make the move when its the enemy turn.


    }
}
