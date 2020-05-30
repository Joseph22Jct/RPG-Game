using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerIconHighlightForInfo : MonoBehaviour, IPointerEnterHandler
{
    public int spot;
    public void OnPointerEnter(PointerEventData eventData)
      {
          MoreInfoPanelScript.Instance.showPlayerStats(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[spot]]);
          
          
      }
}
