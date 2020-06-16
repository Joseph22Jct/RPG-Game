using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleCameraMovements : MonoBehaviour
{

    public delegate void state();
    state currentState;
    public delegate void changeState();
    changeState CcState;

    
    [SerializeField] float Targetrotation;
    [SerializeField] float playersideYpos;
    [SerializeField] float enemysideYpos;
    [SerializeField] float playersidescale;
    [SerializeField] float enemysidescale;
    [SerializeField] Transform playerside;
    [SerializeField] Transform enemyside;
    Transform selfT;
    [SerializeField] GameObject floor;
    

    void Start(){
        selfT = GetComponent<Transform>();
        currentState = DoNothing;
        CcState = CDoNothing;
    }

    void FixedUpdate(){
        currentState();
        CcState();

        //To delete; theres param on the functions below so use ctrl+f

        


    }

    void DoNothing(){

    }
    void CDoNothing(){

    }
   
    public void RotateConstantlyright(){
        selfT.Rotate(new Vector3(0,-1f,0), Space.Self);//Maybe have every child always lookat camera?
        floor.transform.Rotate(new Vector3(0,0,1f), Space.Self);
        //instead of input parameter, have a global parameter
        
    }
    public void RotateConstantlyleft(){
        selfT.Rotate(new Vector3(0,1f,0), Space.Self);//Maybe have every child always lookat camera?
        //instead of input parameter, have a global parameter
        
    }

    
}
