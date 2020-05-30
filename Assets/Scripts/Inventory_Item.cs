using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Item : MonoBehaviour
{
    public UsableItem item;
    public int Count;
    public int ID;
    int isConsumable = -1; //consumable types, battle consumables, healing HP consumables, Mana consumables, tents
    int isEquip = -1;
    public void GiveorTake(int i){
        Count+=i;

        

    }


    public Inventory_Item newEntry(UsableItem itemnew, int countnew){
        item = itemnew;
        Count = countnew;
        ID = itemnew.ID;
        if(item.isConsumable!=null){
            
        }
        else if(item.isEquip !=null){
            isEquip = item.isEquip.EquipmentType;
            
        }
        return this;
    }
}
