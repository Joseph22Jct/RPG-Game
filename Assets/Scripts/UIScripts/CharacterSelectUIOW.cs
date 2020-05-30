using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUIOW : MonoBehaviour
{
    public GameObject Part2;
    public GameObject ThisPart;

    public TextShadingMatcher name0;
    public TextShadingMatcher name1;
    public TextShadingMatcher name2;
    public TextShadingMatcher name3;

    public BarSettingScript HPBar0;
    public BarSettingScript HPBar1;
    public BarSettingScript HPBar2;
    public BarSettingScript HPBar3;
    public BarSettingScript MPBar0;
    public BarSettingScript MPBar1;
    public BarSettingScript MPBar2;
    public BarSettingScript MPBar3;

    public int unit;

    private void OnEnable() {
        name0.SetText(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].getName());
        name1.SetText(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]].getName());
        name2.SetText(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]].getName());
        name3.SetText(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]].getName());

        HPBar0.setBar(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].getCurrentHP(), 
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].getFinalStats()[0]);
        HPBar1.setBar(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]].getCurrentHP(), 
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]].getFinalStats()[0]);
        HPBar2.setBar(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]].getCurrentHP(), 
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]].getFinalStats()[0]);
        HPBar3.setBar(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]].getCurrentHP(), 
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]].getFinalStats()[0]);

        MPBar0.setBar(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].getCurrentMP(), 
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].getFinalStats()[1]);
        MPBar1.setBar(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]].getCurrentMP(), 
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[1]].getFinalStats()[1]);
        MPBar2.setBar(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]].getCurrentMP(), 
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[2]].getFinalStats()[1]);
        MPBar3.setBar(GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]].getCurrentMP(), 
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[3]].getFinalStats()[1]);
    }

    public void Unit0Selected(){
        unit = 0;
        SoundManager.Instance.Play("SFX-Select");
        Part2.SetActive(true);
        
        
        
    }
    public void Unit1Selected(){
        unit = 1;
        SoundManager.Instance.Play("SFX-Select");
        Part2.SetActive(true);
        
    }
    public void Unit2Selected(){
        unit = 2;
        SoundManager.Instance.Play("SFX-Select");
        
        Part2.SetActive(true);
        
    }
    public void Unit3Selected(){
        unit = 3;
        SoundManager.Instance.Play("SFX-Select");
        Part2.SetActive(true);
        
    }

    public void ShutDown(){
        ThisPart.SetActive(false);
    }

}
