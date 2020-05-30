using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAnimationSequence : MonoBehaviour
{
    int state = 0;
    public float maxtime;
    float timepassed;
    // Start is called before the first frame update
    private void Awake() {
        LeanTween.rotate(this.gameObject, new Vector3(0,0,0), 0.5f);
    }

    // Update is called once per frame
    
    LTDescr animatio;
    private void OnMouseDown() {
        finish();
   
    }

    void Update(){
        timepassed+=Time.deltaTime;
        if(timepassed>maxtime){
            finish();
            timepassed = -20;
        }
    }
    void finish(){
        LeanTween.rotate(this.gameObject, new Vector3(0,90,0),0.5f).setOnComplete(end);
        PlayerMovement.Instance.StopMoving();
    }
    void end(){
        this.gameObject.SetActive(false);
    }
}
