using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSimpleDescriptionAwake : MonoBehaviour
{

    public string Text;
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    // Start is called before the first frame update


    void Awake(){
        text1.text = Text;
        text2.text = Text;
    }
    public void Refresh(){
        text1.text = Text;
        text2.text = Text;
    }
    private void OnDisable() {
        Text = "";
    }
    
}
