using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentExperienceBar : MonoBehaviour
{
    public GameObject Bar;
    public GameObject Maxed;
    public void setEXP(EquipableEXPData data){
        Maxed.SetActive(false);
        if(data==null){
            Bar.transform.localScale = new Vector3(0,1,1 );
        }
        else{
        if(data.EXP!=0){
        Bar.transform.localScale = new Vector3((float) data.EXP/ (float) data.MXP,1,1 );
        if((float)data.EXP/(float)data.MXP >=1){
            Maxed.SetActive(true);
        }
        }
        else{
            Bar.transform.localScale = new Vector3(0,1,1 );
        }
        }
    }
}
