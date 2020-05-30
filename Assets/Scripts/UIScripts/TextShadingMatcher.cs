using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShadingMatcher : MonoBehaviour
{
    public Text text;
    public Text text2;

    public void SetText(string textt){
        text.text = textt;
        text2.text = textt;
    }
}
