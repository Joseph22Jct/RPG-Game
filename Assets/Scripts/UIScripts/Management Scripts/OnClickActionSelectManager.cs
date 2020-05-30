using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickActionSelectManager : MonoBehaviour
{

    public static OnClickActionSelectManager Instance;

    public GameObject UseButton;
    public GameObject EquipButton;
    public GameObject DropButton;
    public GameObject BackButton;
    public Vector3 Offset;
    void Awake(){
        Instance = this;
    }

    public void EnableUse(){
        UseButton.SetActive(true);
    }

    public void EnableEquip(){
        EquipButton.SetActive(true);
    }

    public void EnableDrop(){
        DropButton.SetActive(true);
    }

    public void EnableBack(){
        BackButton.SetActive(true);
    }

    public void CloseAll(){
        UseButton.SetActive(false);
        EquipButton.SetActive(false);
        DropButton.SetActive(false);
        BackButton.SetActive(false);
        TheUseButton.onClick.RemoveAllListeners();
        TheEquipButton.onClick.RemoveAllListeners();
        TheDropButton.onClick.RemoveAllListeners();
        
    }

    public void BackButtonCall(){
        SoundManager.Instance.Play("SFX-Cancel");
        UseButton.SetActive(false);
        EquipButton.SetActive(false);
        DropButton.SetActive(false);
        BackButton.SetActive(false);
        TheUseButton.onClick.RemoveAllListeners();
        TheEquipButton.onClick.RemoveAllListeners();
        TheDropButton.onClick.RemoveAllListeners();
    }

    public Button TheUseButton;
    public Button TheEquipButton;
    public Button TheDropButton;
    

    public void setPosition(Vector3 thepos){
        transform.position = thepos +Offset;
    }


}
