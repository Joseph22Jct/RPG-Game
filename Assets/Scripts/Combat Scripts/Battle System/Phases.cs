using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phases : MonoBehaviour
{

    public int showntype;
    public int[] targets = new int[12];
    public int secondType;//????
    public string TextDisplayed;
    
    

    public Phases(int type, string TextUsed, int[] thetargets){
        showntype = type;
        TextDisplayed = TextUsed;
        targets = thetargets;
    }
}
