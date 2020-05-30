using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAnimationScript : MonoBehaviour
{
    [SerializeField]    GameObject TitleText;
    [SerializeField]   GameObject Buttons;
  
    // Start is called before the first frame update
    void Start()
    {   
        TitleText.LeanColor(new Color(1,1,1,1),2);
        TitleText.LeanScaleY(1,2).setOnComplete(buttons);
         // Change 3rd parameter to true for full screen
    }
     

    // Update is called once per frame
    void buttons(){
        
        Buttons.LeanMoveLocalY(-68,1);
        
    }

    public void StartGame(){

        SceneManager.LoadScene("Test_Room");
    }
    public void CloseGame(){
        Application.Quit();
    }
}
