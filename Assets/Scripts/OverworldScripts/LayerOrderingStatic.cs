using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrderingStatic : MonoBehaviour
{
    void Awake(){
        GetComponent<SpriteRenderer>().sortingOrder = (int)-(transform.position.y *10);
    }
}
