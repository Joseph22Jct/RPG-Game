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
    public WeaponRecolor[] Equips = new WeaponRecolor[4];
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

    Color UnitColor;

    public BodyColoringForShader[] BodyColors = new BodyColoringForShader[2];

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

    public void SetEquipment(UsableEquipment WeaponE, UsableEquipment HeadE, UsableEquipment ChestE, UsableEquipment LegsE, Color assignedColor, Species PSpe){
        Weapon = WeaponE;
        Equips[0].SetWeapon(Weapon);
        Headgear = HeadE;
        Equips[1].SetWeapon(Headgear);
        Chest = ChestE;
        Equips[2].SetWeapon(Chest);
        Legs = LegsE;
        Equips[3].SetWeapon(Legs);
        UnitColor = assignedColor;

        playerSpecies = PSpe;
        

        BodyColors[0].Colorpick = assignedColor;
        BodyColors[1].Colorpick = assignedColor;

    }

    public void WalkSouth(){
        time+= Time.deltaTime;
        time %= val;
        Vector3 HeadPos =new Vector3(0,0.5f,0);
        if(time < val/4){
            CoordinateSprites(0,0);
            HeadGO.transform.localPosition = HeadPos;
        }
        else if(time < val/2){
           CoordinateSprites(0,1);
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }
        else if(time < val*3/4){
            CoordinateSprites(0,0);
            HeadGO.transform.localPosition = HeadPos;
        }
        else{
            CoordinateSprites(0,2);
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }

    }

    public void WalkNorth(){
        time+= Time.deltaTime;
        time %= val;
        Vector3 HeadPos =new Vector3(0,0.5f,0);
        if(time < val/4){
            CoordinateSprites(1,0);
            HeadGO.transform.localPosition = HeadPos;
        }
        else if(time < val/2){
           CoordinateSprites(1,1);
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }
        else if(time < val*3/4){
            CoordinateSprites(1,0);
            HeadGO.transform.localPosition = HeadPos;
        }
        else{
            CoordinateSprites(1,2);
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }

    }
    public void WalkEast(){
        time+= Time.deltaTime;
        time %= val;
        Vector3 HeadPos =new Vector3(0,0.5f,0);
        if(time < val/4){
            CoordinateSprites(2,0);
            HeadGO.transform.localPosition = HeadPos;
        }
        else if(time < val/2){
           CoordinateSprites(2,1);
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }
        else if(time < val*3/4){
            CoordinateSprites(2,0);
            HeadGO.transform.localPosition = HeadPos;
        }
        else{
            CoordinateSprites(2,2);
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }

    }
    public void WalkWest(){
        time+= Time.deltaTime;
        time %= val;
        Vector3 HeadPos =new Vector3(0,0.5f,0);
        if(time < val/4){
            CoordinateSprites(3,0);
            HeadGO.transform.localPosition = HeadPos;
        }
        else if(time < val/2){
           CoordinateSprites(3,1);
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }
        else if(time < val*3/4){
            CoordinateSprites(3,0);
            HeadGO.transform.localPosition = HeadPos;
        }
        else{
            CoordinateSprites(3,2);
            HeadGO.transform.localPosition = new Vector3(HeadPos.x, HeadPos.y-0.05f, HeadPos.z);
        }

    }

    public void CoordinateSprites(int Direction, int slot){
        switch(Direction){
            case 0: //South

                Body.sprite = SouthWalking[slot];
                HeadgearHolder.sprite = Headgear.SouthWalking[0];
                ChestHolder.sprite = Chest.SouthWalking[slot];
                LegsHolder.sprite = Legs.SouthWalking[slot];
                Head.sprite = playerSpecies.HeadSprites[0];
            break;

            case 1: //North

                Body.sprite = NorthWalking[slot];
                HeadgearHolder.sprite = Headgear.NorthWalking[0];
                ChestHolder.sprite = Chest.NorthWalking[slot];
                LegsHolder.sprite = Legs.NorthWalking[slot];
                Head.sprite = playerSpecies.HeadSprites[1];
            break;
            case 2: //West

                Body.sprite = WestWalking[slot];
                HeadgearHolder.sprite = Headgear.WestWalking[0];
                ChestHolder.sprite = Chest.WestWalking[slot];
                LegsHolder.sprite = Legs.WestWalking[slot];
                Head.sprite = playerSpecies.HeadSprites[2];
            break;
            case 3: //East

                Body.sprite = EastWalking[slot];
                HeadgearHolder.sprite = Headgear.EastWalking[0];
                ChestHolder.sprite = Chest.EastWalking[slot];
                LegsHolder.sprite = Legs.EastWalking[slot];
                Head.sprite = playerSpecies.HeadSprites[3];
            break;
            

            default:
            break;
            
        }

    }

    


}
