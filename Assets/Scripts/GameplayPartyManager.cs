using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameplayPartyManager : MonoBehaviour
{
    private static GameplayPartyManager _instance;
    public static GameplayPartyManager Instance{
        get{
            
            
            return _instance;
        }
    }

    public Moves defaultMoves;
    

    public Species defaultSpecies;

    public UsableItem[] DefaultItems = new UsableItem[4];

    void Awake(){
        if(_instance == null)
        _instance = this;
        else{
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        

         PlayableUnit newUnit = new PlayableUnit().MakeNewUnit();
        newUnit.setDefaultEquips(DefaultItems);
        newUnit.setName("Cyan");
        newUnit.setDescription("The Azure warrior of legend");
        newUnit.SetSpecies(defaultSpecies);
        newUnit.setColor(0.5f, 0.6f,0.7f);
        newUnit.setStatsAfterEquipment();
        newUnit.giveMove(defaultMoves);
        
        PartyMembers.Add(newUnit);
        
        newUnit = new PlayableUnit().MakeNewUnit();
        newUnit.setDefaultEquips(DefaultItems);
        newUnit.setName("Roux");
        newUnit.setDescription("The Crimson knight of death");
        newUnit.setColor(0.7f, 0.3f,0.3f);
        newUnit.SetSpecies(defaultSpecies);
        newUnit.setStatsAfterEquipment();
        newUnit.giveMove(defaultMoves);
        PartyMembers.Add(newUnit);
        

        newUnit = new PlayableUnit().MakeNewUnit();

        newUnit.setDefaultEquips(DefaultItems);

        
        
        newUnit.setName("Gelb");
        newUnit.setDescription("The golden bishop of hope");
        newUnit.setColor(0.7f, 0.7f,0.2f);
        newUnit.SetSpecies(defaultSpecies);
        newUnit.setStatsAfterEquipment();
        newUnit.addCurrentHP(-5);
        newUnit.giveMove(defaultMoves);
        PartyMembers.Add(newUnit);

        newUnit = new PlayableUnit().MakeNewUnit();

        newUnit.setDefaultEquips(DefaultItems);
        
        newUnit.setName("Zelen");
        newUnit.setDescription("The green bard of the wind");
        newUnit.setColor(0.1f, 0.7f,0.2f);
        newUnit.SetSpecies(defaultSpecies);
        newUnit.setStatsAfterEquipment();
        newUnit.giveMove(defaultMoves);
        PartyMembers.Add(newUnit);

        CurrentParty[0] = 0;
        CurrentParty[1] = 1;
        CurrentParty[2] = 2;
        CurrentParty[3] = 3;
    }

    [SerializeField] int Gold = 3000;

    public  List<PlayableUnit> PartyMembers = new List<PlayableUnit>();
    public int[] CurrentParty = new int[4];
    
    
    [SerializeField] Dictionary<int, Inventory_Item> CurrentItems = new Dictionary<int, Inventory_Item>();
    [SerializeField] bool[] triggerList = new bool[200];
    [SerializeField] bool[] chestTriggerList = new bool[200];

    public EnemyGroup CurrentFight;
    
   

private void Update() {
    //if(Input.GetButton("Debug_Button")) DebugInventory();

}
    public void StartCombat(EnemyGroup group){
        CurrentFight = group;

        SceneManager.LoadScene("CombatScene");
    }
    
    

    public bool getChestTrigger(int ID){
        return chestTriggerList[ID];
    }
    public void setChestTrigger(int ID, bool value){
        chestTriggerList[ID] = value;
    }

    public void giveItem(UsableItem givenItem, int count){
        // use this for sorting foreach()
        Inventory_Item newInvent= new Inventory_Item().newEntry(givenItem,count);
        
       
        if(CurrentItems.ContainsKey(givenItem.ID)){
            CurrentItems[givenItem.ID].GiveorTake(count);
            Debug.Log("Count Increased!");
        }
        
        
        else{
            CurrentItems.Add(givenItem.ID,newInvent);    
            Debug.Log("Created new entry!");
        }

        //DebugInventory();

    }
    public void loseItem(int ID, int count){

        CurrentItems[ID].Count-=count;
        if(CurrentItems[ID].Count <1){
            CurrentItems.Remove(ID);
        }
    }
    public Inventory_Item getItem(int ID){
        if(CurrentItems.ContainsKey(ID))
        return CurrentItems[ID];
        else{
            return null;
        }
        
    }

    public void DebugInventory(){
        foreach (KeyValuePair<int,Inventory_Item> i in CurrentItems){
            Debug.Log(i.Value.item.ClassName);
            Debug.Log(i.Value.Count);
        }
    }
    public Dictionary<int, Inventory_Item> getCurrentItems(){
        return CurrentItems;
    }

}
