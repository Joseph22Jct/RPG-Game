using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableUnit
{
    string Unitname;
    string Description;

    Species specie;
    Color UnitColor;

    int[] BaseStats = new int[7]; //In order: HP, MP, Atk, Def, S Atk, S Def, Spd

    int[] FinalStats = new int[7];

    float[] innateStatusResistance = new float[4]; //Carries percentage resistance to status effects.
    float[] FinalStatusResistance = new float[4];
    float[] innateElementRes = new float[4]; //Carries percentage resistance to status effects.
    float[] FinalElementRes = new float[4];

    Moves[] EquippedMoves = new Moves[8];

    [SerializeField] Dictionary<int, Moves> CurrentMoves = new Dictionary<int, Moves>();

    public void giveMove(Moves move){
        
        
       
        if(!CurrentMoves.ContainsKey(move.ID)){
             CurrentMoves.Add(move.ID, move);
              Debug.Log("Given Move: " + move.Name);  

              for(int i = 0; i<EquippedMoves.Length; i++){
                  if(EquippedMoves[i] = null){
                      EquippedMoves[i] = move;
                      break;
                  }
              }
        }
        
    

        //DebugInventory();

    }

    public void EquipMove(int slot, Moves move){
        EquippedMoves[slot] = move;
    }

    public void UnequipMove(int slot){

        EquippedMoves[slot] = null;
        for(int i = slot; i<EquippedMoves.Length; i++){
            if(EquippedMoves[i+1] == null){
                break;
            }
            else{
                EquippedMoves[i] = EquippedMoves[i+1];
            }
        }
    }

    int CurrentHP;
    int CurrentMP;
    int Status = -1; //0 = Poison, 1 = Silence, 2 = Sleep, 3= Blind. 4=Burn -1 is no status effect. -2 = Dead
    EquipableEXPData[] EquipmentEXP= new EquipableEXPData[200]; //First 0-39 Weapons, 40-79 Head, 80-119 Chest, 120-159 Arms, 160-199 Legs


    

    UsableItem Weapon;
    UsableItem Head;
    UsableItem Chest;
    UsableItem Legs;


    //Coloring Data
    //Sprites used - Front, Back, Physical and Magical Front and Back



    

   

    public PlayableUnit MakeNewUnit(){
        
        BaseStats[0] = 10;
        BaseStats[1] = 5;
        BaseStats[2] = 2;
        BaseStats[3] = 2;
        BaseStats[4] = 2;
        BaseStats[5] = 2;
        BaseStats[6] = 2;
        innateStatusResistance[0] = 0;
        innateStatusResistance[1] = 0;
        innateStatusResistance[2] = 0;
        innateStatusResistance[3] = 0;
        innateElementRes[0] = 0;
        innateElementRes[1] = 0;
        innateElementRes[2] = 0;
        innateElementRes[3] = 0;
       
        
        CurrentMP = BaseStats[1];
        CurrentHP = BaseStats[0];

        
        //Add Attack: Strike - TODO
        return this;


    }

    public Moves[] GetEquippedMoves(){
        return EquippedMoves;
    }

    public Dictionary<int, Moves> GetAllMoves(){
        return CurrentMoves;
    }

    public Color GetColor(){
        return UnitColor;
    }

    public Species getSpecies(){
        return specie;
    }

    public int getCurrentHP(){
        return CurrentHP;
    }
    public int getCurrentMP(){
        return CurrentMP;
    }
    public int getStatus(){
        return Status;
    }

    public int[] getFinalStats(){
        return FinalStats;
    }
    public float[] getBaseStatusResistances(){
        return innateStatusResistance;
    }
    public float[] getFinalStatusResistances(){
        return FinalStatusResistance;
    }
    public float[] getFinalElemResistances(){
        return FinalElementRes;
    }
    public float[] getBaseElemResistances(){
        return innateElementRes;
    }
    public string getName(){
        return Unitname;
    }
    public string getDescrition(){
        return Description;
    }

    public EquipableEXPData[] getEquipEXP(){
        return EquipmentEXP;
    }

    public void addCurrentHP(int value){
        CurrentHP += value;
        if (CurrentHP>FinalStats[0]){CurrentHP = FinalStats[0];}
    }
    public void addCurrentMP(int value){
        CurrentMP += value;
        if (CurrentMP>FinalStats[1]){CurrentMP = FinalStats[1];}
    }
    public void setCurrentStats(int valuespot, int value){
        FinalStats[valuespot] -=BaseStats[valuespot]; //Take out from the final stats to not modify other equipment.
        BaseStats[valuespot] += value; //increase base stats
        FinalStats[valuespot] += BaseStats[valuespot]; //put it back up with the updated stats
        
    }
    public int[] getCurrentStats(){
        return BaseStats;
    }

    public void setStatsAfterEquipment(){ //Call this every time yoou change equipments.
        for(int i = 0; i<FinalStats.Length; i++){
        FinalStats[i] = BaseStats[i]+Weapon.isEquip.boosts[i] + Head.isEquip.boosts[i]+
                        Chest.isEquip.boosts[i]+ Legs.isEquip.boosts[i];

        
        }
        for(int i = 0; i<FinalStatusResistance.Length; i++){
        FinalStatusResistance[i] = innateStatusResistance[i]+Weapon.isEquip.resBoosts[i] + Head.isEquip.resBoosts[i]+
                        Chest.isEquip.resBoosts[i]+ Legs.isEquip.resBoosts[i];

        
        }
        for(int i = 0; i<FinalElementRes.Length; i++){
        FinalElementRes[i] = innateElementRes[i]+Weapon.isEquip.elementalresBoosts[i] + Head.isEquip.elementalresBoosts[i]+
                        Chest.isEquip.elementalresBoosts[i]+ Legs.isEquip.elementalresBoosts[i];

        
        }
        onHealthChange();
        
    }
    public void SetSpecies(Species value){
        specie = value;
    }

    void onHealthChange(){
        if (FinalStats[0]<CurrentHP){
            CurrentHP=FinalStats[0];
        }
    }

    public void setName(string name){
        Unitname = name;
    }

    public void setColor(float colorR, float colorG, float colorB){
        UnitColor[0] = colorR;
        UnitColor[1] = colorG;
        UnitColor[2] = colorB;
        UnitColor[3] = 1;
    }

    public void setEquipmentEXP(UsableItem EID, int EXP){
        if(EquipmentEXP[EID.ID].EXP == 0){
            EquipmentEXP[EID.ID].EquipName = EID.ClassName;
            EquipmentEXP[EID.ID].Esprite = EID.icon;
            EquipmentEXP[EID.ID].MXP = EID.isEquip.maxEXP;
        }

        EquipmentEXP[EID.ID].EXP +=EXP; //Call an if if maxed later.
    }

    public void UnequipItem(int EquipType){ //TODO set this up
        switch(EquipType){
            case 0: //Weapon
            if(!Weapon.isEmptyEquip)
            GameplayPartyManager.Instance.giveItem(Weapon, 1);
            Weapon = DefaultItems[0];

            break;
            case 1: //Head
            if(!Head.isEmptyEquip)
            GameplayPartyManager.Instance.giveItem(Head, 1);
            Head = DefaultItems[1];

            break;
            case 2: //Chest
            if(!Chest.isEmptyEquip)
            GameplayPartyManager.Instance.giveItem(Chest, 1);
            Chest = DefaultItems[2];

            break;
            case 3: //Legs
            if(!Legs.isEmptyEquip)
            GameplayPartyManager.Instance.giveItem(Legs, 1);
            Legs = DefaultItems[3];

            break;
            default:
            break;
        }
    }
    public UsableItem[] DefaultItems = new UsableItem[4];

    public UsableItem GetWeapon(){
        return Weapon;
    }
    public UsableItem GetHead(){
        return Head;
    }
    public UsableItem GetChest(){
        return Chest;
    }
    public UsableItem GetLegs(){
        return Legs;
    }

    public void setDefaultEquips(UsableItem[] defItems){
        DefaultItems = defItems;
        Weapon = defItems[0];
        Head = defItems[1];
        Chest = defItems[2];
        Legs = defItems[3];
    }

    public void setEquipment(UsableItem item){

        switch(item.isEquip.EquipmentType){
            case 0: //Weapon
            if(!Weapon.isEmptyEquip)
            GameplayPartyManager.Instance.giveItem(Weapon, 1);
            Weapon = item;
            GameplayPartyManager.Instance.loseItem(item.ID,1);

            break;
            case 1: //Head
            if(!Head.isEmptyEquip)
            GameplayPartyManager.Instance.giveItem(Head, 1);
            Head = item;
            
            GameplayPartyManager.Instance.loseItem(item.ID,1);

            break;
            case 2: //Chest
            if(!Chest.isEmptyEquip)
            GameplayPartyManager.Instance.giveItem(Chest, 1);
            Chest = item;
            GameplayPartyManager.Instance.loseItem(item.ID,1);

            break;
            case 3: //Legs
            if(!Legs.isEmptyEquip)
            GameplayPartyManager.Instance.giveItem(Legs, 1);
            Legs = item;
            GameplayPartyManager.Instance.loseItem(item.ID,1);

            break;
            default:
            break;
        }
        setStatsAfterEquipment();
    }

    public bool isHealthAtMax(){
        if(CurrentHP==FinalStats[0]) return true;
        return false;
    }
    public bool isManaAtMax(){
        if(CurrentMP==FinalStats[1]) return true;
        return false;
    }
    public void setStatus(int value){
        Status = value;
    }

    public void setDescription(string value){
        Description = value;
    }


}
