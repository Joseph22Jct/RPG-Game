using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleCamera : MonoBehaviour
{
    private static BattleCamera _instance;
    public static BattleCamera Instance{
        get{
            
            return _instance;
        }
    }
    private void Awake() {
        _instance = this;

        CamRB = GetComponent<Rigidbody>();
    }
   
    Rigidbody CamRB;

    [SerializeField] GameObject ObjecttoLookat;
    [SerializeField] GameObject placetobeat;
    float speed;

    [SerializeField] GameObject[] Anchors;

    private void Start() {
        placetobeat = Anchors[0];
        ObjecttoLookat = Anchors[1];
        speed = 10;

    }

    private void FixedUpdate() { 
       
        Vector3 smoothedPosition= Vector3.Lerp(transform.position, placetobeat.transform.position, speed/100);
        
        //Vector3 newPosition = new Vector3(smoothedPosition.x - (smoothedPosition.x%0.03125f ),smoothedPosition.y - (smoothedPosition.x%0.03125f ), transform.position.z );
        transform.position = smoothedPosition;
        transform.LookAt(ObjecttoLookat.transform.position);
        
    }
    BattleEvents eventt;

    public void MoveCamera(int type, float thisspeed, BattleEvents thisEvent){
        speed = thisspeed;
        eventt = thisEvent;
        switch(type){
            case 0: //Pan out to view all characters
                PanOutCamera();
            break;
            default:
            break;
        }

    }

    public void PanOutCamera(){
        placetobeat = Anchors[0];
        ObjecttoLookat = Anchors[1];

        
    }
}
