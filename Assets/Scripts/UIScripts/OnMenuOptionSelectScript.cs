using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMenuOptionSelectScript : MonoBehaviour


{
    

    [SerializeField] GameObject ItemManagement;
    public GameObject DropCounter;
    
    public void ItemOption(){
        SoundManager.Instance.Play("SFX-Select");

        ItemManagement.SetActive(true);
        EquipManagement.SetActive(false);
        MagicManagement.SetActive(false);
        StatusManagement.SetActive(false);
        CustomizeManagement.SetActive(false);
        ConfigManagement.SetActive(false);
        SaveManagement.SetActive(false);
        DropCounter.SetActive(false);
        OnClickActionSelectManager.Instance.CloseAll();
        
    }
    [SerializeField] GameObject EquipManagement;
    
    public void EquipOption(){
        SoundManager.Instance.Play("SFX-Select");


        ItemManagement.SetActive(false);
        EquipManagement.SetActive(true);
        MagicManagement.SetActive(false);
        StatusManagement.SetActive(false);
        CustomizeManagement.SetActive(false);
        ConfigManagement.SetActive(false);
        SaveManagement.SetActive(false);
         DropCounter.SetActive(false);
        OnClickActionSelectManager.Instance.CloseAll();

       
    }

    [SerializeField] GameObject MagicManagement;
    
    public void MagicOption(){

        SoundManager.Instance.Play("SFX-Select");


        ItemManagement.SetActive(false);
        EquipManagement.SetActive(false);
        MagicManagement.SetActive(true);
        StatusManagement.SetActive(false);
        CustomizeManagement.SetActive(false);
        ConfigManagement.SetActive(false);
        SaveManagement.SetActive(false);
         DropCounter.SetActive(false);
        OnClickActionSelectManager.Instance.CloseAll();
    }

    [SerializeField] GameObject StatusManagement;
    
    public void StatusOption(){

        SoundManager.Instance.Play("SFX-Select");


        ItemManagement.SetActive(false);
        EquipManagement.SetActive(false);
        MagicManagement.SetActive(false);
        StatusManagement.SetActive(true);
        CustomizeManagement.SetActive(false);
        ConfigManagement.SetActive(false);
        SaveManagement.SetActive(false);
         DropCounter.SetActive(false);
        OnClickActionSelectManager.Instance.CloseAll();
    }

    [SerializeField] GameObject CustomizeManagement;
    
    public void CustomizeOption(){

        SoundManager.Instance.Play("SFX-Select");


        ItemManagement.SetActive(false);
        EquipManagement.SetActive(false);
        MagicManagement.SetActive(false);
        StatusManagement.SetActive(false);
        CustomizeManagement.SetActive(true);
        ConfigManagement.SetActive(false);
        SaveManagement.SetActive(false);
         DropCounter.SetActive(false);
        OnClickActionSelectManager.Instance.CloseAll();
    }

    [SerializeField] GameObject ConfigManagement;
    
    public void ConfigOption(){

        SoundManager.Instance.Play("SFX-Select");


        ItemManagement.SetActive(false);
        EquipManagement.SetActive(false);
        MagicManagement.SetActive(false);
        StatusManagement.SetActive(false);
        CustomizeManagement.SetActive(false);
        ConfigManagement.SetActive(true);
        SaveManagement.SetActive(false);
         DropCounter.SetActive(false);
        OnClickActionSelectManager.Instance.CloseAll();
    }
    [SerializeField] GameObject SaveManagement;
    
    public void SaveOption(){
        
        SoundManager.Instance.Play("SFX-Select");
        
        ItemManagement.SetActive(false);
        EquipManagement.SetActive(false);
        MagicManagement.SetActive(false);
        StatusManagement.SetActive(false);
        CustomizeManagement.SetActive(false);
        ConfigManagement.SetActive(false);
        SaveManagement.SetActive(true);
         DropCounter.SetActive(false);
        OnClickActionSelectManager.Instance.CloseAll();
    }

    public void closeAll(){
        
        
        ItemManagement.SetActive(false);
        EquipManagement.SetActive(false);
        MagicManagement.SetActive(false);
        StatusManagement.SetActive(false);
        CustomizeManagement.SetActive(false);
        ConfigManagement.SetActive(false);
        SaveManagement.SetActive(false);
         DropCounter.SetActive(false);
        OnClickActionSelectManager.Instance.CloseAll();
    }
}
