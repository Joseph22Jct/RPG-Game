using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemyAnimations : MonoBehaviour
{
    public SpriteRenderer BackSR;
    SpriteRenderer SRThis;
    Material shader;
    Material backShader;
    public Material ColorReplacementMat;
    public void InitializeEnemy(EnemyClasses enemyClass){
        SRThis = GetComponent<SpriteRenderer>();
        SRThis.sprite = enemyClass.enemySprites[0];
        BackSR.sprite = enemyClass.enemySprites[3];
        

        if(enemyClass.replaceColors){

            shader = SRThis.material;
        backShader = BackSR.material;
        shader = ColorReplacementMat;
        backShader = ColorReplacementMat;
        shader.SetColor("_Color1",enemyClass.colors[0]);
        shader.SetColor("_Color2",enemyClass.colors[1]);
        shader.SetColor("_Color3",enemyClass.colors[2]);
        shader.SetColor("_Color4",enemyClass.colors[3]);
        shader.SetColor("_Color5",enemyClass.colors[4]);
        shader.SetColor("_Color6",enemyClass.colors[5]);
        shader.SetColor("_Color7",enemyClass.colors[6]);
        shader.SetColor("_Color8",enemyClass.colors[7]);
        backShader.SetColor("_Color1",enemyClass.colors[0]);
        backShader.SetColor("_Color2",enemyClass.colors[1]);
        backShader.SetColor("_Color3",enemyClass.colors[2]);
        backShader.SetColor("_Color4",enemyClass.colors[3]);
        backShader.SetColor("_Color5",enemyClass.colors[4]);
        backShader.SetColor("_Color6",enemyClass.colors[5]);
        backShader.SetColor("_Color7",enemyClass.colors[6]);
        backShader.SetColor("_Color8",enemyClass.colors[7]);
        }
        
    }
}
