using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManagementUnitSelect : MonoBehaviour
{
    
    
    public int thisUnit;

    public Image[] Icons = new Image[4];
    public Text NameField;
    public Text NameField2;
    EquipmentExperienceBar[] EXPBars = new EquipmentExperienceBar[4];
    EquipMenuButtonHighlight[] EquipHL = new EquipMenuButtonHighlight[4];
 
    private void OnEnable() {
        EXPBars = GetComponentsInChildren<EquipmentExperienceBar>();
        EquipHL = GetComponentsInChildren<EquipMenuButtonHighlight>();

        UsableItem[] items = new UsableItem[4];
        items[0] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].GetWeapon();
        items[1] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].GetHead();
        items[2] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].GetChest();
        items[3] = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].GetLegs();

        EquipHL[0].HeldItem = items[0];
        EquipHL[1].HeldItem = items[1];
        EquipHL[2].HeldItem = items[2];
        EquipHL[3].HeldItem = items[3];

        EXPBars[0].setEXP(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].getEquipEXP()[items[0].ID-100]);
        EXPBars[1].setEXP(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].getEquipEXP()[items[1].ID-100]);
        EXPBars[2].setEXP(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].getEquipEXP()[items[2].ID-100]);
        EXPBars[3].setEXP(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].getEquipEXP()[items[3].ID-100]);

        try{
        NameField.text =  GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].getName();
        NameField2.text = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisUnit]].getName();
        }
        catch{};
        Icons[0].sprite = items[0].icon;
        Icons[1].sprite = items[1].icon;
        Icons[2].sprite = items[2].icon;
        Icons[3].sprite = items[3].icon;
    }

    public void ClickWeaponButton(){
        EquipManagementSelectScript.Instance.UnitSelected = thisUnit;
        EquipManagementSelectScript.Instance.EquipmentTypeRetrieval = 0;
        EquipManagementSelectScript.Instance.Part1.SetActive(false);
        EquipManagementSelectScript.Instance.Part2.SetActive(true);
    }
    public void ClickHeadButton(){
        EquipManagementSelectScript.Instance.UnitSelected = thisUnit;
        EquipManagementSelectScript.Instance.EquipmentTypeRetrieval = 1;
        EquipManagementSelectScript.Instance.Part1.SetActive(false);
        EquipManagementSelectScript.Instance.Part2.SetActive(true);
    }
    public void ClickChestButton(){
        EquipManagementSelectScript.Instance.UnitSelected = thisUnit;
        EquipManagementSelectScript.Instance.EquipmentTypeRetrieval = 2;
        EquipManagementSelectScript.Instance.Part1.SetActive(false);
        EquipManagementSelectScript.Instance.Part2.SetActive(true);
    }
    public void ClickLegsButton(){
        EquipManagementSelectScript.Instance.UnitSelected = thisUnit;
        EquipManagementSelectScript.Instance.EquipmentTypeRetrieval = 3;
        EquipManagementSelectScript.Instance.Part1.SetActive(false);
        EquipManagementSelectScript.Instance.Part2.SetActive(true);
    }



}
