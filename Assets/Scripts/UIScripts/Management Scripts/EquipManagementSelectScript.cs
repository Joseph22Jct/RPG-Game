using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManagementSelectScript : MonoBehaviour
{
    public static EquipManagementSelectScript Instance;
    void Awake(){
        Instance = this;
    }
    public GameObject Part1;
    public GameObject Part2;
    EquipManagementUnitSelect[] UnitEquips = new EquipManagementUnitSelect[4];

    public int EquipmentTypeRetrieval;

    private void OnEnable() {
        GoBack();
       
    
    }

    public void GoBack(){
         UnitEquips = Part1.GetComponentsInChildren<EquipManagementUnitSelect>();
        for(int i = 0; i<4; i++){
            UnitEquips[i].thisUnit = i;
        }
        SoundManager.Instance.Play("SFX-Select");
        OnClickActionSelectManager.Instance.CloseAll();
        Part1.SetActive(true);
        Part2.SetActive(false);
        

    }

    public int UnitSelected;
    
    public void EquipUnit(UsableItem equipment){
        GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[UnitSelected]].setEquipment(equipment);
    }
}
