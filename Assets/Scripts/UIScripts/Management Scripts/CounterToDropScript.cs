using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterToDropScript : MonoBehaviour
{
      public static CounterToDropScript Instance;
      void Awake(){
        Instance = this;
    }

    public Text LDigit;
    public Text LDigit2;
    public Text RDigit;
    public Text RDigit2;
    public UsableItem item;

     int Count;
    public int MaxCount;
    public GameObject Holder;

    public void EnableDrop() {
        Holder.SetActive(true);
        Count = 1;
        DisplayCounter();

    }

    public void LeftDigitUp(){
        if(Count == MaxCount){
            Count = 1;
        }
        else
        Count+=10;
        if(Count > MaxCount){
            Count = MaxCount;
        }
        DisplayCounter();
    }
    public void LeftDigitDown(){
         if(Count == 1){
            Count = MaxCount;
        }
        else
        Count-=10;
        if(Count < 1){
            Count = 1;
        }
        DisplayCounter();
    }

    public void RightDigitUp(){
         if(Count == MaxCount){
            Count = 1;
        }
        else
        Count++;
        if(Count > MaxCount){
            Count = MaxCount;
        }
        DisplayCounter();
    }
    public void RightDigitdown(){
        if(Count == 1){
            Count = MaxCount;
        }
        else
        Count--;
        if(Count < 1){
            Count = 1;
        }
        DisplayCounter();

    }

    void DisplayCounter(){
        LDigit.text = ""+ (int) (Count/10);
        LDigit2.text = ""+ (int) (Count/10);
        RDigit.text = "" + Count%10;
         RDigit2.text = "" + Count%10;

    }
    public void DropButton(){
        GameplayPartyManager.Instance.loseItem(item.ID, Count);
        try{
        ItemSelectedUIInstructions.Instance.UpdateUI();
        
        }
        catch{
        EquipMenuUIInventoryScript.Instance.UpdateUI();
        }
        try{
        EquipMenuUIInventoryScript.Instance.UpdateUI();
        
        }
        catch{
        ItemSelectedUIInstructions.Instance.UpdateUI();
        }
        SoundManager.Instance.Play("SFX-Confirm");
        Holder.SetActive(false);
    }
    public void BackButton(){
        SoundManager.Instance.Play("SFX-Cancel");
        Holder.SetActive(false);
    }
}
