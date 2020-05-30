using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Descriptor1;
    [SerializeField] GameObject Descriptor2;

    public void Disable(){
        Descriptor1.SetActive(false);
        Descriptor2.SetActive(false);
    }
    
}
