using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrderingbyMov : MonoBehaviour
{
    SpriteRenderer render;
    int v;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        v = (int)-(transform.position.y * 10);
        render.sortingOrder = v;
    }
}
