using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightBattleMenuCommand : MonoBehaviour
{

    public Text[] SkillName = new Text[2];
    public Image icon;
    public Text ManaCost;
    public Text HPCost;
    public Button button;
    public int slot;
    public Moves thisMove;
    public void Selected(){
        BattlePlayerUI.Instance.selectedMove = thisMove;
        BattlePlayerUI.Instance.OpenTargetMenu();
    }
    
}
