﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnitDataUI : MonoBehaviour
{
    Image thisImage;
    Material shader;
    int thisslot;
    public BattleUnitDataUIText[] BUIT = new BattleUnitDataUIText[4];
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color Colorpick;
    UnitData4Combat thisUnit;
    
    public void InitializeHero(UnitData4Combat unit){
        thisImage = GetComponent<Image>();
        shader = thisImage.material;
        thisslot = unit.slot;
        thisUnit = unit;
        Colorpick = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[thisslot]].GetColor();

        color1 = new Color(Colorpick.r/3, Colorpick.g /3 - 0.1f, Colorpick.b /3,Colorpick.a); // Dark Outline
         color2 = new Color(Colorpick.r/2.5f+0.05f , Colorpick.g/2.5f, Colorpick.b /2.5f +0.05f,Colorpick.a); // Bright Outline
        color3 = new Color(Colorpick.r, Colorpick.g, Colorpick.b,Colorpick.a); //Main Body

        if(Colorpick.r>=Colorpick.g && Colorpick.r >= Colorpick.b){
            color4 = new Color(Colorpick.r, Colorpick.g+(Colorpick.r*0.3f), Colorpick.b+(Colorpick.r*0.3f),Colorpick.a); // Secondary Color
            color5 = new Color(1, Colorpick.g+Colorpick.r/2, Colorpick.b+Colorpick.r/2,Colorpick.a); //Highlights
        }

        else if(Colorpick.b>=Colorpick.r && Colorpick.b >= Colorpick.g){
            color4 = new Color(Colorpick.r+(Colorpick.b*0.3f), Colorpick.g+(Colorpick.b*0.3f), Colorpick.b,Colorpick.a); 
            color5 = new Color(Colorpick.b+Colorpick.r/2, Colorpick.g+Colorpick.b/2, 1,Colorpick.a);
        }
        else if (Colorpick.g>=Colorpick.r && Colorpick.g >= Colorpick.b){
            color4 = new Color(Colorpick.r+(Colorpick.g*0.3f), Colorpick.g, Colorpick.b+(Colorpick.g*0.3f),Colorpick.a); 
            color5 = new Color(Colorpick.g+Colorpick.r/2, 1, Colorpick.b+Colorpick.g/2,Colorpick.a);
        }


         
         color6 = new Color(0.9f, 0.9f, 0.9f,Colorpick.a); //eye whites

        shader.SetColor("_Color1",color1);
        shader.SetColor("_Color2",color2);
        shader.SetColor("_Color3",color3);
        shader.SetColor("_Color4",color4);
        shader.SetColor("_Color5",color5);
        shader.SetColor("_Color6",color6);
        Debug.Log("UIColor Updated");

        BUIT[0].UpdateName(unit.Name);
        BUIT[1].UpdateBar(unit.currentHP, unit.initialStats[0]);
        BUIT[2].UpdateBar(unit.currentMP, unit.initialStats[1]);
        BUIT[3].UpdateBarOnly(0,1);

        
    }

    public void UpdateHP(){
        BUIT[1].UpdateBar(thisUnit.currentHP, thisUnit.CurrentStats[0]);
    }
    public void UpdateMP(){
        BUIT[2].UpdateBar(thisUnit.currentMP, thisUnit.CurrentStats[1]);
    }
    public void UpdateABT(){
        BUIT[3].UpdateBarOnly(thisUnit.ABTBarCurrent, thisUnit.maxABTBar);
    }
}
