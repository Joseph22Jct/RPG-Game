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

    [SerializeField] Vector3 ObjecttoLookat;
    public Vector3 placetobeat;
    float speed;

    private void Update() { 
        CamRB.DOMove(placetobeat, speed);
        gameObject.transform.DOLookAt(ObjecttoLookat, speed);
    }


    public void MoveCamera(Vector3 endplace, float duration, Vector3 Lookat){
        placetobeat = endplace;
        speed = duration;
        ObjecttoLookat = Lookat;
        

    }
}
