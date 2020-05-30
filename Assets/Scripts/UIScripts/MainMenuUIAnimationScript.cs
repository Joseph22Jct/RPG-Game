using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIAnimationScript : MonoBehaviour
{
    [SerializeField] GameObject BackButton;
    [SerializeField] GameObject OptionSelect;
    [SerializeField] GameObject DescriptionBox;
    [SerializeField] GameObject ManagementBox;
    [SerializeField] float time;
    [SerializeField] OverworldMenuManager theManager;
    [SerializeField] GameObject Background;
    Color colored;
    
  private void Start() {
        colored = Background.GetComponent<Image>().color;
    }
 
    private void OnEnable() {
        

        
        
        
        BackButton.LeanMoveLocalY(115, time).setIgnoreTimeScale(true).setOnComplete(RotateAround);
        
        OptionSelect.LeanMoveLocalX(-120, time).setIgnoreTimeScale(true);
        DescriptionBox.LeanMoveLocalY(120, time).setIgnoreTimeScale(true);
        ManagementBox.LeanMoveLocalY(-32, time).setIgnoreTimeScale(true);
        
    }
    public void SetDisable() {
        
        
        BackButton.LeanMoveLocalY(-280, time).setIgnoreTimeScale(true);
        OptionSelect.LeanMoveLocalX(240, time).setIgnoreTimeScale(true);
        DescriptionBox.LeanMoveLocalY(-240, time).setIgnoreTimeScale(true);
        ManagementBox.LeanMoveLocalY(156, time).setIgnoreTimeScale(true).setOnComplete(theManager.DisableMenus);
        
        
    }

    
    void RotateAround(){
        BackButton.LeanRotateZ(-15,time*2).setOnComplete(RotateAround2).setIgnoreTimeScale(true);
    }
    void RotateAround2(){
        BackButton.LeanRotateZ(15,time*2).setOnComplete(RotateAround).setIgnoreTimeScale(true);
    }
    
}
