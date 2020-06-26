using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StrikeAnim : MonoBehaviour
{

    float time;
    public GameObject target;
    public float TimeMax;
    public GameObject punch;
    public GameObject punchImpact;
    // Start is called before the first frame update
   private void OnEnable() {
       time = 0;

   }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;



        if(time >= TimeMax){
            punch.SetActive(false);
            gameObject.SetActive(false);

        }
    }
}
