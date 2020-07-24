using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnchorAI : MonoBehaviour
{
    [SerializeField] int type;
    [SerializeField] float speed;

    // Update is called once per frame
    void Start()
    {
        switch(type){
            case 0:
            gameObject.transform.DOLocalRotate(new Vector3(0,360,0),speed,RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
            break;

            default:
            break;

        }
    }
}
