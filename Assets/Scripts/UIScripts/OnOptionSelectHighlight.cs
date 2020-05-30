using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnOptionSelectHighlight : MonoBehaviour, IPointerEnterHandler
{
    public string HighlightText;
    
    [SerializeField] GameObject DescriptionTextBox;

    public void OnPointerEnter(PointerEventData eventData)
      {
          
          DescriptionTextBox.GetComponent<OnSimpleDescriptionAwake>().Text = HighlightText;
          if(DescriptionTextBox.activeSelf == false)
          DescriptionTextBox.SetActive(true);
          else{
              DescriptionTextBox.GetComponent<OnSimpleDescriptionAwake>().Refresh();
          }
          
      }


   
      

}
