using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectedUIInstructions : MonoBehaviour
{
   

    public static ItemSelectedUIInstructions Instance;
    List<Inventory_Item> ItemList = new List<Inventory_Item>();
  ItemSlot[] inventorySlots = new ItemSlot[35];
    int itempage = 0;

    [SerializeField] GameObject theInventory;
    bool initialized;
    void Awake(){
        Instance = this;
    }
    

    private void OnEnable() {
        ResetPages();
        UpdateUI();
    }

    public GameObject Useonwhich;

    public void EnableUnitSelection(bool SelectAll){
        
        Useonwhich.SetActive(true);
        ItemPartyMemberPick.Instance.theHighlight.SetActive(SelectAll);
    }
    public void DisableUnitSelection(){
        Useonwhich.SetActive(false);
    }
    
    private void OnDisable() {
        DisableUnitSelection();
    }

    public void UpdateUI(){

        if(!initialized){
            initialized = true;
            inventorySlots = theInventory.GetComponentsInChildren<ItemSlot>();
        }
        ItemList.Clear();

        foreach(KeyValuePair<int,Inventory_Item> i in GameplayPartyManager.Instance.getCurrentItems()){
            ItemList.Add(i.Value);
            
        }
        ItemList.Sort((x, y) => x.item.ID.CompareTo(y.item.ID));
        if(inventorySlots.Length<ItemList.Count){
        for(int i = inventorySlots.Length*itempage; i<inventorySlots.Length;i++){
            inventorySlots[i-(itempage*inventorySlots.Length)].SetItem(ItemList[i]);
        }
        }

        else{
            for(int i = inventorySlots.Length*itempage; i<inventorySlots.Length;i++){
                try{
                    inventorySlots[i-(itempage*inventorySlots.Length)].SetItem(ItemList[i]);
                }catch {
                    inventorySlots[i-(itempage*inventorySlots.Length)].ClearItem();
                }
            
        }
        }
    }

    public void TurnPageRight(){
        ChangePage(1);
    }

    public void TurnPageLeft(){
        ChangePage(-1);
    }
    public void ResetPages(){
        ChangePage(0);
    }

    void ChangePage(int whereto){
        switch(whereto){
            case 0:
            itempage = 0;
            UpdateUI();
            //Go to the first page;
            break;
            case 1:
            if(ItemList.Count > inventorySlots.Length*itempage){
                itempage ++;
                UpdateUI();
            }
            else{
                itempage = 0;
                UpdateUI();
            }
            //Go forward one page
            break;
            case -1:
            if(itempage ==0){
                itempage = (int) ItemList.Count/inventorySlots.Length;
            }
            else{
                itempage--;
                UpdateUI();
            }
            break;
            //Go backward one page
            default:
            break;
        }
    }
}
