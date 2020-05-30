using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPart2Script : MonoBehaviour
{
   public CharacterSelectUIOW Part1;
   public int unit;

   public GameObject Part1Obj;

   public GameObject thisPart;
   public TextShadingMatcher[] icons = new TextShadingMatcher[26];
   public BarSettingScript[] bars = new BarSettingScript[2];
   public Text Name;
   public Text desc1;
   public Text desc2;

   public Text plusHP1;
   public Text plusHP2;
   public Text plusMP1;
   public Text plusMP2;

   public EquipMenuButtonHighlight[] WeaponButtons = new EquipMenuButtonHighlight[4];

   bool goingforward = false;
   private void OnDisable() {
      if (!goingforward){
      Part1Obj.SetActive(true);
      thisPart.SetActive(false);
      }
   }
   public void goBack(){
      SoundManager.Instance.Play("SFX-Cancel");
      Part1Obj.SetActive(true);
      thisPart.SetActive(false);
   }

   public void EXPButton(){

   }

   public void EquipWeapon(){
      SoundManager.Instance.Play("SFX-Select");
      PartEquipItem.SetActive(true);
      Part1Obj.SetActive(false);
      goingforward= true;
      StatusPartEquipScript.Instance.StartUp(0,unit);
      thisPart.SetActive(false);

   }
   public void EquipHead(){
      SoundManager.Instance.Play("SFX-Select");
      PartEquipItem.SetActive(true);
      Part1Obj.SetActive(false);
      goingforward = true;
      StatusPartEquipScript.Instance.StartUp(1,unit);
      thisPart.SetActive(false);
   }
   public void EquipChest(){
      SoundManager.Instance.Play("SFX-Select");
      PartEquipItem.SetActive(true);
      Part1Obj.SetActive(false);
      goingforward = true;
      StatusPartEquipScript.Instance.StartUp(2,unit);
      thisPart.SetActive(false);

   }
   public void EquipLegs(){
      SoundManager.Instance.Play("SFX-Select");
      PartEquipItem.SetActive(true);
      Part1Obj.SetActive(false);
      goingforward = true;
      StatusPartEquipScript.Instance.StartUp(3,unit);
      thisPart.SetActive(false);

   }


   public GameObject PartEquipItem;
   public GameObject Part3;

   UsableItem Head;
       UsableItem Chest ;
       UsableItem Legs ;     
       UsableItem Weapon ;


   private void OnEnable() {
      goingforward = false;
       unit = Part1.unit;
       Part1.ShutDown();
       Debug.Log(unit);

       icons = thisPart.GetComponentsInChildren<TextShadingMatcher>();

       Name.text = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getName();
       desc1.text = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getDescrition();
       desc2.text = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getDescrition();
        Head = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].GetHead();
      Chest = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].GetChest();
       Legs = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].GetLegs();
       Weapon = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].GetWeapon();

       WeaponButtons[0].SetUp(Weapon, unit);
      WeaponButtons[1].SetUp(Head, unit);
      WeaponButtons[2].SetUp(Chest, unit);
      WeaponButtons[3].SetUp(Legs, unit);
       

       int[] baseStats = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getCurrentStats();
       int[] finalStats = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getFinalStats();
       float[] innateElemResistance = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getBaseElemResistances();
    float[] FinalElemResistance =GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getFinalElemResistances();
    float[] innateStatusResistance = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getBaseElemResistances();
    float[] FinalStatusResistance =GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getFinalStatusResistances();

         int hpboost = (finalStats[0]-baseStats[0]);
         
         if(hpboost>=0){
            plusHP1.text = ("(+"+hpboost+")");
            plusHP2.text = ("(+"+hpboost+")");
         } 
         else {
            plusHP1.text = ("("+hpboost+")");
            plusHP2.text = ("("+hpboost+")");
         }

         int MPboost = (finalStats[1]-baseStats[1]);
         if(MPboost>=0){
            plusMP1.text = ("(+"+MPboost+")");
            plusMP2.text = ("(+"+MPboost+")");
         } 
         else {
            plusMP1.text = ("("+MPboost+")");
            plusMP2.text = ("("+MPboost+")");
         }

         bars[0].setBar( GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getCurrentHP(), finalStats[0]);
         bars[1].setBar( GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getCurrentMP(), finalStats[1]);

        icons[0].SetText(baseStats[2]+"");
        icons[1].SetText(baseStats[3]+"");
        icons[2].SetText(baseStats[4]+"");
        icons[3].SetText(baseStats[5]+"");
        icons[4].SetText(baseStats[6]+"");
        icons[5].SetText(finalStats[2]+"");
        icons[6].SetText(finalStats[3]+"");
        icons[7].SetText(finalStats[4]+"");
        icons[8].SetText(finalStats[5]+"");
        icons[9].SetText(finalStats[6]+"");
        icons[10].SetText(innateElemResistance[0]*100+"%");
        icons[11].SetText(innateElemResistance[1]*100+"%");
        icons[12].SetText(innateElemResistance[2]*100+"%");
        icons[13].SetText(innateElemResistance[3]*100+"%");
        icons[14].SetText(FinalElemResistance[0]*100+"%");
        icons[15].SetText(FinalElemResistance[1]*100+"%");
        icons[16].SetText(FinalElemResistance[2]*100+"%");
        icons[17].SetText(FinalElemResistance[3]*100+"%");
        icons[18].SetText(innateStatusResistance[0]*100+"%");
        icons[19].SetText(innateStatusResistance[1]*100+"%");
        icons[20].SetText(innateStatusResistance[2]*100+"%");
        icons[21].SetText(innateStatusResistance[3]*100+"%");
        icons[22].SetText(FinalStatusResistance[0]*100+"%");
        icons[23].SetText(FinalStatusResistance[1]*100+"%");
        icons[24].SetText(FinalStatusResistance[2]*100+"%");
        icons[25].SetText(FinalStatusResistance[3]*100+"%");
        
        
   }
}
