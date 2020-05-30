using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData eventData)
      {
          if(HeldItem !=null){

          
          MoreInfoPanelScript.Instance.showItemStats(thisItem.item);
          }
          
          
      }
    

     UsableItem HeldItem;

     Inventory_Item thisItem;
     public GameObject icon;

public GameObject counter;
public Text numberCounter;

    

     int HeldCount;

    public void OnItemSlotClick(){

        //TODO GO TO ONCLICACTIONSELECTMANAGER AND PASS THE VALUES FOR ACTIONS.

        if(HeldItem==null){
            OnClickActionSelectManager.Instance.setPosition(new Vector3(1500,1500,0));
            return;
        } 
        else{
            SoundManager.Instance.Play("SFX-Select");
            OnClickActionSelectManager.Instance.setPosition(transform.position);
            if(HeldItem.isConsumable!=null){
                OnClickActionSelectManager.Instance.TheUseButton.onClick.AddListener(OnUse);
                OnClickActionSelectManager.Instance.EnableUse();
            }
            if(HeldItem.isEquip != null){
                OnClickActionSelectManager.Instance.TheEquipButton.onClick.AddListener(OnEquip);
                OnClickActionSelectManager.Instance.EnableEquip(); //Find a way to add functions to buttons through code
            }
            if(!HeldItem.isKeyItem){
                OnClickActionSelectManager.Instance.TheDropButton.onClick.AddListener(OnDrop);
                OnClickActionSelectManager.Instance.EnableDrop();
            }
            OnClickActionSelectManager.Instance.EnableBack();
            
        }
    }

    public void SetItem( Inventory_Item item){
        HeldItem = item.item;
        HeldCount = item.Count;
        thisItem = item;

        
        

        icon.GetComponent<Image>().sprite = HeldItem.icon;
        numberCounter.text = HeldCount+"";
        if(HeldCount>1)
        counter.SetActive(true);
        else{
            counter.SetActive(false);
        }
        icon.SetActive(true);

    }
    public void ClearItem(){
        HeldItem = null;
        HeldCount = 0;
        counter.SetActive(false);
        icon.SetActive(false);

    }

    public bool StatusUse;

    public bool equipmentUse;
    public int unitUsed;

    int currentUnit = 0;

    public void OnUse(){
        Debug.Log(thisItem.item.isConsumable.multitarget);

        ItemSelectedUIInstructions.Instance.EnableUnitSelection(thisItem.item.isConsumable.multitarget);
        
        if(thisItem.item.isConsumable.multitarget){
        ItemPartyMemberPick.Instance.Unit0Button.onClick.AddListener(UseAll);
        ItemPartyMemberPick.Instance.Unit1Button.onClick.AddListener(UseAll);
        ItemPartyMemberPick.Instance.Unit2Button.onClick.AddListener(UseAll);
        ItemPartyMemberPick.Instance.Unit3Button.onClick.AddListener(UseAll);
        }
        else{
        ItemPartyMemberPick.Instance.Unit0Button.onClick.AddListener(UseOnUnit0);
        ItemPartyMemberPick.Instance.Unit1Button.onClick.AddListener(UseOnUnit1);
        ItemPartyMemberPick.Instance.Unit2Button.onClick.AddListener(UseOnUnit2);
        ItemPartyMemberPick.Instance.Unit3Button.onClick.AddListener(UseOnUnit3);
        }


        
        
        OnClickActionSelectManager.Instance.CloseAll();
        SoundManager.Instance.Play("SFX-Select");
    }
    public void OnEquip(){

        if(StatusUse){
            GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unitUsed]].setEquipment(HeldItem);
            StatusPartEquipScript.Instance.Part2.SetActive(true);
            StatusPartEquipScript.Instance.thisPart.SetActive(false);
            OnClickActionSelectManager.Instance.CloseAll();
            SoundManager.Instance.Play("SFX-Select");
        }
        else if(equipmentUse){
            EquipManagementSelectScript.Instance.EquipUnit(thisItem.item);

            EquipManagementSelectScript.Instance.Part1.SetActive(true);
            EquipManagementSelectScript.Instance.Part2.SetActive(false);
            OnClickActionSelectManager.Instance.CloseAll();
        SoundManager.Instance.Play("SFX-Select");
        }

        else{
            ItemSelectedUIInstructions.Instance.EnableUnitSelection(false);

        ItemPartyMemberPick.Instance.Unit0Button.onClick.AddListener(EquipWeapon0);
        ItemPartyMemberPick.Instance.Unit1Button.onClick.AddListener(EquipWeapon1);
        ItemPartyMemberPick.Instance.Unit2Button.onClick.AddListener(EquipWeapon2);
        ItemPartyMemberPick.Instance.Unit3Button.onClick.AddListener(EquipWeapon3);
        OnClickActionSelectManager.Instance.CloseAll();
        SoundManager.Instance.Play("SFX-Select");
        }
    }

    public void OnDrop(){

        //Make Popup
        CounterToDropScript.Instance.EnableDrop();
        CounterToDropScript.Instance.item = thisItem.item;
        CounterToDropScript.Instance.MaxCount = thisItem.Count;
        OnClickActionSelectManager.Instance.CloseAll();
        SoundManager.Instance.Play("SFX-Select");

    }
    public void EquipWeapon0(){
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].setEquipment(thisItem.item);
        ItemSelectedUIInstructions.Instance.UpdateUI();
            SoundManager.Instance.Play("SFX-Confirm");
            ItemPartyMemberPick.go.SetActive(false);
    }
    public void EquipWeapon1(){
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]].setEquipment(thisItem.item);
        ItemSelectedUIInstructions.Instance.UpdateUI();
            SoundManager.Instance.Play("SFX-Confirm");
            ItemPartyMemberPick.go.SetActive(false);
    }
    public void EquipWeapon2(){
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]].setEquipment(thisItem.item);
        ItemSelectedUIInstructions.Instance.UpdateUI();
            SoundManager.Instance.Play("SFX-Confirm");
            ItemPartyMemberPick.go.SetActive(false);
    }
    public void EquipWeapon3(){
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]].setEquipment(thisItem.item);
        ItemSelectedUIInstructions.Instance.UpdateUI();
            SoundManager.Instance.Play("SFX-Confirm");
            ItemPartyMemberPick.go.SetActive(false);
    }

    public void UseAll(){

        bool wentthrough = false;

        PlayableUnit[] thisUnits = new PlayableUnit[4];
        thisUnits[0] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]];
        thisUnits[1] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]];
        thisUnits[2] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]];
        thisUnits[3] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]];


        

        for (int i = 0; i< thisItem.item.isConsumable.effect.Length; i++){
            wentthrough = thisItem.item.isConsumable.effect[i].Effect(thisUnits, thisItem.item.isConsumable);
        }
        
        if(wentthrough){
            MoreInfoPanelScript.Instance.UpdatePlayerStats();
            GameplayPartyManager.Instance.loseItem(thisItem.item.ID,1);
            ItemSelectedUIInstructions.Instance.UpdateUI();
            SoundManager.Instance.Play("SFX-Confirm");
            
            ItemPartyMemberPick.go.SetActive(false);
            
        }
        else{
            SoundManager.Instance.Play("SFX-Cancel");
        }
        

    }

    public void UseOnUnit0(){
        
        bool wentthrough = false;

        PlayableUnit[] thisUnits = new PlayableUnit[1];
        thisUnits[0] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]];
        for (int i = 0; i< thisItem.item.isConsumable.effect.Length; i++){
            wentthrough = thisItem.item.isConsumable.effect[i].Effect(thisUnits, thisItem.item.isConsumable);
        }
        
        if(wentthrough){
            MoreInfoPanelScript.Instance.UpdatePlayerStats();
            GameplayPartyManager.Instance.loseItem(thisItem.item.ID,1);
            ItemSelectedUIInstructions.Instance.UpdateUI();
            SoundManager.Instance.Play("SFX-Confirm");
            ItemPartyMemberPick.go.SetActive(false);
            
        }
        else{
            SoundManager.Instance.Play("SFX-Cancel");
        }
        

    }

    public void UseOnUnit1(){
        bool wentthrough = false;

        PlayableUnit[] thisUnits = new PlayableUnit[1];
        thisUnits[0] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]];
        for (int i = 0; i< thisItem.item.isConsumable.effect.Length; i++){
            wentthrough = thisItem.item.isConsumable.effect[i].Effect(thisUnits, thisItem.item.isConsumable);
        }
        
        if(wentthrough){
            MoreInfoPanelScript.Instance.UpdatePlayerStats();
            GameplayPartyManager.Instance.loseItem(thisItem.item.ID,1);
            ItemSelectedUIInstructions.Instance.UpdateUI();
            SoundManager.Instance.Play("SFX-Confirm");
            ItemPartyMemberPick.go.SetActive(false);
            
        }
        else{
            SoundManager.Instance.Play("SFX-Cancel");
        }
        

    }
    public void UseOnUnit2(){
        bool wentthrough = false;

        PlayableUnit[] thisUnits = new PlayableUnit[1];
        thisUnits[0] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]];
        for (int i = 0; i< thisItem.item.isConsumable.effect.Length; i++){
            wentthrough = thisItem.item.isConsumable.effect[i].Effect(thisUnits, thisItem.item.isConsumable);
        }
        
        if(wentthrough){
            MoreInfoPanelScript.Instance.UpdatePlayerStats();
            GameplayPartyManager.Instance.loseItem(thisItem.item.ID,1);
            ItemSelectedUIInstructions.Instance.UpdateUI();
            SoundManager.Instance.Play("SFX-Confirm");
            ItemPartyMemberPick.go.SetActive(false);
            
        }
        else{
            SoundManager.Instance.Play("SFX-Cancel");
        }
        

    }
    public void UseOnUnit3(){
        bool wentthrough = false;

        PlayableUnit[] thisUnits = new PlayableUnit[1];
        thisUnits[0] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]];
        for (int i = 0; i< thisItem.item.isConsumable.effect.Length; i++){
            wentthrough = thisItem.item.isConsumable.effect[i].Effect(thisUnits, thisItem.item.isConsumable);
        }
        
        if(wentthrough){
            MoreInfoPanelScript.Instance.UpdatePlayerStats();
            GameplayPartyManager.Instance.loseItem(thisItem.item.ID,1);
            ItemSelectedUIInstructions.Instance.UpdateUI();

            SoundManager.Instance.Play("SFX-Confirm");
            ItemPartyMemberPick.go.SetActive(false);
            
        }
        else{
            SoundManager.Instance.Play("SFX-Cancel");
        }
        

    }

  
    
}
