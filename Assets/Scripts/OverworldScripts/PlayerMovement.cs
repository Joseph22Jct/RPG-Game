using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] float maxspeed;
    [SerializeField]float usedspeed;
    [SerializeField] Vector3 target;
    [SerializeField] Camera cam;
    Vector3 comparepoint;
    Rigidbody2D rb2d;
    Vector3 prevMousePos;
    Vector3 newMousePos;
    bool StopMove;
    SpriteRenderer render;
    PlayerUnitAnimation Anim;
    public WeaponRecolor VisibleWeapons;

     private static PlayerMovement _instance;
    public static PlayerMovement Instance{
        get{
            
            return _instance;
        }
    }
    private void Awake() {
        _instance = this;
    }

    public void StopMoving(){
        target = transform.position;
        StopMove = true;
    }


    void Start()
    {   
        Anim = GetComponent<PlayerUnitAnimation>();
        render = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    
    }

    bool dragisUsed;
    // Update is called once per frame
    void LateUpdate(){

        float xval = target.x - transform.position.x;
        float yval = target.y- transform.position.y;

        Debug.Log(xval);
        Debug.Log(yval);
        if (xval !=0 && yval !=0){

        if(Mathf.Abs(xval) > Mathf.Abs(yval)){
            if(xval >0){
                Anim.WalkEast();
                Debug.Log("East Walking");
            }
            else{
                Anim.WalkWest();
                Debug.Log("west Walking");
            }

        }
        
        else if(Mathf.Abs(xval) < Mathf.Abs(yval)){
            if(yval > 0){
                Anim.WalkNorth();
                Debug.Log("North Walking");
            }
            else{
                Anim.WalkSouth();
                Debug.Log("South Walking");
            }

        }
        }
        if(EventSystem.current.IsPointerOverGameObject()) return;
        /* 
        if (Input.GetMouseButtonUp(0)) {
            usedspeed = speed;
            newMousePos = Input.mousePosition;
            comparepoint = cam.ScreenToWorldPoint(newMousePos);
            comparepoint.z = transform.position.z;
            if(checkWithinRange(newMousePos, new Vector3(prevMousePos.x-0.25f, prevMousePos.y-0.25f, prevMousePos.z), new Vector3(prevMousePos.x+0.25f, prevMousePos.y+0.25f, prevMousePos.z))){ 
                usedspeed = maxspeed;
            }
            prevMousePos = newMousePos;
             target = comparepoint;
             
        }
        */

         
        
        
        if(Input.GetMouseButton(0)){
            
            
            usedspeed =speed;
            newMousePos = Input.mousePosition;
            comparepoint = cam.ScreenToWorldPoint(newMousePos);
           
            comparepoint = new Vector3(comparepoint.x -comparepoint.x%0.03125f,comparepoint.y -comparepoint.y%0.03125f, transform.position.z);
            
             target = comparepoint;
             dragisUsed = true;
             
        }
        if(StopMove) target = transform.position;

        if(!Input.GetMouseButton(0)) StopMove = false;
        if(dragisUsed&&!Input.GetMouseButton(0)){
            dragisUsed = false;
            target = this.transform.position;
        }

        


        

        rb2d.MovePosition( Vector3.MoveTowards(transform.position, target, usedspeed * Time.deltaTime));
       

    }

    

   

    bool checkWithinRange(Vector3 number, Vector3 min, Vector3 max){
        if(number.x>=min.x && number.x<=max.x && number.y>=min.y && number.y<=max.y  ) return true;
        else return false;
    }

    private void OnEnable() {
        Anim = GetComponent<PlayerUnitAnimation>();
        PlayableUnit PU;
        PU = GameplayPartyManager.Instance.PartyMembers[0];
        Anim.SetEquipment(PU.GetWeapon().isEquip, PU.GetHead().isEquip, PU.GetChest().isEquip, PU.GetLegs().isEquip, PU.GetColor(), PU.getSpecies());
    }
}

