using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetButtonInformationScript : MonoBehaviour
{
    public Button thisButton;

    public int slot;

    public void Selected(){
        BattlePlayerUI.Instance.selected = slot;
        BattlePlayerUI.Instance.UpdateTargetUI();
    }
    
    
}
