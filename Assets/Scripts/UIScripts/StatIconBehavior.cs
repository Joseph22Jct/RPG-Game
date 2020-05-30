using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
public class StatIconBehavior : MonoBehaviour
{
 
    public GameObject iconnumbers;
    public GameObject thisIcon;
   

   


    public void Switch(bool value){
        iconnumbers.SetActive(value);
        thisIcon.SetActive(!value);
    }

    float time;
    float maxtime = 1;
    bool change;
    public void SwitchBetweenIandS(){
        
        time += Time.unscaledDeltaTime;
        if (time>maxtime){
            time = 0;
            change = !change;
            Switch(change);
            
        }
    }
    private void Update() {
        
        SwitchBetweenIandS();
        
    }

    public void HighlightNumber(bool isPos){
        if(isPos)
        text1.color = Color.green;
        else text1.color = Color.red;
    }

    public void changeNumber(string value){
        numbers = value;
        text1.text = numbers;
        text2.text = numbers;

    }

      public string numbers;
    public Text text1;
    public Text text2;
      

}
