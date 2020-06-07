using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMenuManager : MonoBehaviour
{

    [SerializeField] GameObject OpenMenuButton;
    [SerializeField] GameObject BackButton;
    [SerializeField] List<GameObject> OptionList = new List<GameObject>();

    [SerializeField] GameObject Menu;
    [SerializeField] GameObject InventoryWindow;
    [SerializeField] MainMenuUIAnimationScript menuUI;
    

    bool InventoryOpen;
    bool menuOpen = false;
    
    [SerializeField] PlayerUnitAnimation OWPlayer;
 

    public void openMenu(){
        menuOpen = true;
        Time.timeScale = 0;
        Menu.SetActive(menuOpen);
        OpenMenuButton.SetActive(!menuOpen);
        PlayerMovement.Instance.StopMoving();
        SoundManager.Instance.Play("SFX-Select");


    }
    public void closeMenu(){
        SoundManager.Instance.Play("SFX-Cancel");
        
        menuOpen = false;

        
        menuUI.SetDisable();
        
         //unsure why this makes everything nnot work
        
         

        
    }

    public void DisableMenus(){
        Menu.SetActive(false);
        OpenMenuButton.SetActive(!menuOpen);
        Time.timeScale = 1;
         PlayerMovement.Instance.StopMoving();
        OWPlayer.SetEquipment(0);
        OWPlayer.StandStill(0);
          descman.Disable();
         menuSelectManager.closeAll();

         

    }

    [SerializeField] DescriptionManager descman;
    [SerializeField] OnMenuOptionSelectScript menuSelectManager;
    
}
