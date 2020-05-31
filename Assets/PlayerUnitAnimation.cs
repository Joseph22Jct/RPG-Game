using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitAnimation : MonoBehaviour
{   
    int depth;
    public SpriteRenderer Body;
    public GameObject HeadGO;
    public SpriteRenderer Head;
    
    public SpriteRenderer HeadgearHolder;
    public SpriteRenderer ChestHolder;
    public SpriteRenderer LegsHolder;
    public UsableEquipment Weapon;
    public UsableEquipment Headgear;
    
    public UsableEquipment Chest;
    public UsableEquipment Legs;

    public Species playerSpecies;

    

    public Sprite[] SouthWalking = new Sprite[3];
    public Sprite[] NorthWalking = new Sprite[3];
    public Sprite[] EastWalking = new Sprite[3];
    public Sprite[] WestWalking = new Sprite[3];
    public Sprite[] PrepAttack = new Sprite[2];

    private void Update() {
        depth = (int)-(transform.position.y * 10);
        //render.sortingOrder = v;
    }

    private void Start() {
        Weapon = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].GetWeapon().isEquip;
        Headgear = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].GetHead().isEquip;
        Chest = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].GetChest().isEquip;
        Legs = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[0]].GetLegs().isEquip;
    }

    float time;
    public float val = 0.3f;

    public void SetEquipment(UsableEquipment WeaponE, UsableEquipment HeadE, UsableEquipment ChestE, UsableEquipment LegsE, Color assignedColor){
        Weapon = WeaponE;
        Headgear = HeadE;
        Chest = ChestE;
        Legs = LegsE;
    }

    public void WalkSouth(){
        time+= Time.deltaTime;
        time %= val;
        Vector3 HeadPos =new Vector3(0,0.5f,0);
        if(time < val/4){
            Body.sprite = SouthWalking[0];
            HeadGO.transform.localPosition = HeadPos;
        }
        else if(time < val/2){
            Body.sprite = SouthWalking[1];
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }
        else if(time < val*3/4){
            Body.sprite = SouthWalking[0];
            HeadGO.transform.localPosition = HeadPos;
        }
        else{
            Body.sprite = SouthWalking[2];
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }

    }

    


}
