using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIPButton : MonoBehaviour
{
    public void onClick(){
        SceneManager.LoadScene("Test_Room");
    }
}
