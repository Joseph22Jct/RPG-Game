using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColoringForShader : MonoBehaviour
{

    public int headType;
    public Color Colorpick;
    
    SpriteRenderer thisSR;
    public Material shader;

    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    [SerializeField] Color color4;
    [SerializeField] Color color5;
    [SerializeField] Color color6;
    // Start is called before the first frame update
    private void OnEnable() {
        
        thisSR = GetComponent<SpriteRenderer>();
        shader = thisSR.material;
        SetColors();
        
    }

    public void SetColors(){

        

         color1 = new Color(Colorpick.r/3, Colorpick.g /3 - 0.1f, Colorpick.b /3,Colorpick.a); // Dark Outline
         color2 = new Color(Colorpick.r/2.5f+0.05f , Colorpick.g/2.5f, Colorpick.b /2.5f +0.05f,Colorpick.a); // Bright Outline
        color3 = new Color(Colorpick.r, Colorpick.g, Colorpick.b,Colorpick.a); //Main Body

        if(Colorpick.r>=Colorpick.g && Colorpick.r >= Colorpick.b){
            color4 = new Color(Colorpick.r, Colorpick.g+(Colorpick.r*0.3f), Colorpick.b+(Colorpick.r*0.3f),Colorpick.a); // Secondary Color
            color5 = new Color(1, Colorpick.g+Colorpick.r/2, Colorpick.b+Colorpick.r/2,Colorpick.a); //Highlights
        }

        else if(Colorpick.b>=Colorpick.r && Colorpick.b >= Colorpick.g){
            color4 = new Color(Colorpick.r+(Colorpick.b*0.3f), Colorpick.g+(Colorpick.b*0.3f), Colorpick.b,Colorpick.a); 
            color5 = new Color(Colorpick.b+Colorpick.r/2, Colorpick.g+Colorpick.b/2, 1,Colorpick.a);
        }
        else if (Colorpick.g>=Colorpick.r && Colorpick.g >= Colorpick.b){
            color4 = new Color(Colorpick.r+(Colorpick.g*0.3f), Colorpick.g, Colorpick.b+(Colorpick.g*0.3f),Colorpick.a); 
            color5 = new Color(Colorpick.g+Colorpick.r/2, 1, Colorpick.b+Colorpick.g/2,Colorpick.a);
        }


         
         color6 = new Color(0.9f, 0.9f, 0.9f,Colorpick.a); //eye whites

        shader.SetColor("_Color1",color1);
        shader.SetColor("_Color2",color2);
        shader.SetColor("_Color3",color3);
        shader.SetColor("_Color4",color4);
        shader.SetColor("_Color5",color5);
        shader.SetColor("_Color6",color6);

        Debug.Log("Color Updated");

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
