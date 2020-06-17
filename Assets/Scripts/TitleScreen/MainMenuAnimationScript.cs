using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenuAnimationScript : MonoBehaviour
{
    [SerializeField]    GameObject TitleText;
    [SerializeField]    GameObject TitleText2;
    [SerializeField]   GameObject Buttons;
  
    // Start is called before the first frame update
    void Start()
    {   
        TitleText.GetComponent<Text>().DOColor(Color.black, 5);
        TitleText2.GetComponent<Text>().DOColor(Color.red, 5);
        TitleText.transform.DOScaleY(1,2).OnStepComplete(buttons);
        TitleText2.transform.DOScaleY(1,2);
        //TitleText.LeanColor(new Color(1,1,1,1),2);
        //TitleText.LeanScaleY(1,2).setOnComplete(buttons);
         // Change 3rd parameter to true for full screen
    }
     

    // Update is called once per frame
    void buttons(){

        Buttons.transform.DOLocalMoveY(-68,2);
        
        //Buttons.LeanMoveLocalY(-68,1);
        
    }

    public void StartGame(){

        SceneManager.LoadScene("Test_Room");
    }
    public void CloseGame(){
        Application.Quit();
    }
}
