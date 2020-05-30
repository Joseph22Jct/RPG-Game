using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EquipMenuButtonHighlight : MonoBehaviour, IPointerEnterHandler
{
    public UsableItem HeldItem;
    public Image icon;
    public EquipmentExperienceBar bar;

    public void SetUp(UsableItem item, int unit){
        HeldItem = item;
        icon.sprite = item.icon;
        EquipableEXPData data = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[unit]].getEquipEXP()[item.ID-100];
        bar.setEXP(data);

    }

    public void SelectEquip(){
        
    }
    public void OnPointerEnter(PointerEventData eventData)
      {
          if(HeldItem !=null){

          
          MoreInfoPanelScript.Instance.showItemStats(HeldItem);
          }
          
          
      }
}
