using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSettingScript : MonoBehaviour
{

    public Text text1;
    public Text text2;
    public GameObject bar;
    public void setBar(int CHP, int MHP){
        bar.transform.localScale = new Vector3((float)CHP/(float)MHP, 1,1);
        text1.text = CHP+"/"+MHP;
        text2.text = CHP+"/"+MHP;
    }
}
