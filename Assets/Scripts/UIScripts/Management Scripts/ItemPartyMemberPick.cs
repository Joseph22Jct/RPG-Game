using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPartyMemberPick : MonoBehaviour
{
    public static ItemPartyMemberPick Instance;
    public static GameObject go;

    private void Awake() {
        Instance = this;
        go = gameObject;

    }

    public bool HighlightAll;
    public GameObject theHighlight;

    

    private void OnEnable() {
        unitIcon0.sprite = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].getSpecies().icon;
        unitIcon1.sprite = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]].getSpecies().icon;
        unitIcon2.sprite = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]].getSpecies().icon;
        unitIcon3.sprite = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]].getSpecies().icon;
        
    }
    private void OnDisable() {
        Unit0Button.onClick.RemoveAllListeners();
         Unit1Button.onClick.RemoveAllListeners();
          Unit2Button.onClick.RemoveAllListeners();
           Unit3Button.onClick.RemoveAllListeners();
    }

    public void BackButtonCall(){
        SoundManager.Instance.Play("SFX-Select");
        gameObject.SetActive(false);
    }
    

    public Image unitIcon0;
    public Image unitIcon1;
    public Image unitIcon2;
    public Image unitIcon3;
    

    public Button Unit0Button;
    public Button Unit1Button;
    public Button Unit2Button;
    public Button Unit3Button;

    }
