using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionAnimation : MonoBehaviour
{
   
    public float timeRequired;
    public float time;

    private void Update() {
        time +=Time.deltaTime;
        if(time == timeRequired){
            //Alert Mediator
        }
    }
}
