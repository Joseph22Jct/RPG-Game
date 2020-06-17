using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        

        
        BackButton.transform.DOLocalMoveY(115, time).OnStepComplete(RotateAround).SetUpdate(true);
        OptionSelect.transform.DOLocalMoveX(-120, time).SetUpdate(true);
        DescriptionBox.transform.DOLocalMoveY(120, time).SetUpdate(true);
        ManagementBox.transform.DOLocalMoveY(-32, time).SetUpdate(true);

        /*
        BackButton.LeanMoveLocalY(115, time).setIgnoreTimeScale(true).setOnComplete(RotateAround);
        
        OptionSelect.LeanMoveLocalX(-120, time).setIgnoreTimeScale(true);
        DescriptionBox.LeanMoveLocalY(120, time).setIgnoreTimeScale(true);
        ManagementBox.LeanMoveLocalY(-32, time).setIgnoreTimeScale(true);
        */
        
    }
    public void SetDisable() {

        BackButton.transform.DOLocalMoveY(-280, time).SetUpdate(true);
        OptionSelect.transform.DOLocalMoveX(240, time).SetUpdate(true);
        DescriptionBox.transform.DOLocalMoveY(-240, time).SetUpdate(true);
        ManagementBox.transform.DOLocalMoveY(156, time).SetUpdate(true).OnStepComplete(theManager.DisableMenus);
        
        /*
        BackButton.LeanMoveLocalY(-280, time).setIgnoreTimeScale(true);
        OptionSelect.LeanMoveLocalX(240, time).setIgnoreTimeScale(true);
        DescriptionBox.LeanMoveLocalY(-240, time).setIgnoreTimeScale(true);
        ManagementBox.LeanMoveLocalY(156, time).setIgnoreTimeScale(true).setOnComplete(theManager.DisableMenus);
        */
        
    }

    
    void RotateAround(){
        BackButton.transform.DORotate(new Vector3(0,0,-15), time*2).OnStepComplete(RotateAround2);
        //BackButton.LeanRotateZ(-15,time*2).setOnComplete(RotateAround2).setIgnoreTimeScale(true);
    }
    void RotateAround2(){
        BackButton.transform.DORotate(new Vector3(0,0,15), time*2).OnStepComplete(RotateAround);
        //BackButton.LeanRotateZ(15,time*2).setOnComplete(RotateAround).setIgnoreTimeScale(true);
    }
    
}
