using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleUnitDataUIText : MonoBehaviour
{

    public Text[] texts = new Text[5];
    public GameObject bar;
    public void UpdateName(string text){
        for(int i = 0; i<texts.Length; i++){
            texts[i].text = text;
        }
    }
    public void UpdateBar(int number, int max){
        for(int i = 0; i<texts.Length; i++){
            texts[i].text = number + "/" + max;
        }
        bar.transform.localScale = new Vector3((float)number/max, 1,1);
    }
    public void UpdateBarOnly(float number, float max){
        bar.transform.localScale = new Vector3(number/max, 1,1);
    }
}
