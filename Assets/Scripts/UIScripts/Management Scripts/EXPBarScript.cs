using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPBarScript : MonoBehaviour
{
    public GameObject EXPMax;
    public GameObject EXPBar;

    public void setEXPBar(EquipableEXPData data){
        EXPBar.SetActive(true);
        gameObject.SetActive(true);
        EXPBar.transform.localScale = new Vector3((float) data.EXP / (float) data.MXP, 1,1 );
        if(data.EXP/data.MXP >=1){
            EXPMax.SetActive(true);
        }
        
    }

    public void noEXPBar(){
        gameObject.SetActive(false);
        EXPBar.SetActive(false);
        EXPMax.SetActive(false);

    }
}
