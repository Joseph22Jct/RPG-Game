using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChestScript : MonoBehaviour
{

    bool onRadius = false;
     [SerializeField] UsableItem item;
     [SerializeField] int itemcount;
    [SerializeField] int ChestID;
    bool isOpen;
    [SerializeField] string ShownText;

     [SerializeField] Text writtenText;
    
     [SerializeField] GameObject UIElement;
     [SerializeField] SpriteRenderer icon;
     [SerializeField] Sprite openChest;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (GameplayPartyManager.Instance.getChestTrigger(ChestID)){
            isOpen = true;
            GetComponent<SpriteRenderer>().sprite = openChest;
        }

        

        
    }

    [SerializeField] SpriteRenderer highlighter;
    // Update is called once per frame
    private void Update() {
        if(onRadius&& !isOpen)
        highlighter.color = new Color(highlighter.color.r,
            highlighter.color.g,highlighter.color.b, 
            Mathf.Sin(Time.time*5 - (Mathf.PI/2)) *0.20f+0.20f);
    }
    

    void PlayChestAnimation(){
        UIElement.SetActive(true);
        icon.sprite = item.icon;
        writtenText.text = ShownText;

    }
    bool highlightchest;
    private void OnTriggerEnter2D(Collider2D other ) {
        if(other.tag == "Player_Trigger"){
            onRadius = true;
            
            highlighter.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder+1;
            
        
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player_Trigger"){
            onRadius = false;
            
            highlighter.color = new Color(highlighter.color.r,
            highlighter.color.g,highlighter.color.b, 
            0);
        
        }
    }
    private void OnMouseDown() {
        if(onRadius&&!isOpen){
            if(GiveItem()){
                PlayerMovement.Instance.StopMoving();
            GameplayPartyManager.Instance.setChestTrigger(ChestID, true);
            isOpen = true;
            Debug.Log("Given an item!");
            PlayChestAnimation();
            GetComponent<SpriteRenderer>().sprite = openChest;
        } 
            else{
                //PopUp that maximum Item has been Reached.
            }
        }
    }

    bool GiveItem(){
        Inventory_Item checkItem =GameplayPartyManager.Instance.getItem(item.ID);

        if(checkItem!=null){
            if(checkItem.Count+ itemcount>=99 - itemcount){
                Debug.Log("Inventory Full");
                //Give message that inventory is full
                return false;
            }
            
            
        }
        GameplayPartyManager.Instance.giveItem(item, itemcount);
        
        return true;
        
    }
}
