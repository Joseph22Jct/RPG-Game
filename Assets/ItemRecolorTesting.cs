using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class ItemRecolorTesting : MonoBehaviour
{ 
 
    public UsableEquipment currentEquip;
    // Start is called before the first frame update
    Material shader;
    SpriteRenderer SprRen;

    public float timer;
    // Start is called before the first frame update
    private void Start() {
        SprRen = GetComponent<SpriteRenderer>();
        shader = SprRen.material;
    }

    private void Update() {
        SetWeapon(currentEquip);  
    }

    public void SetWeapon(UsableEquipment equip){
        timer += Time.deltaTime;
        if(timer >= 7) timer = 0;
        SprRen = GetComponent<SpriteRenderer>();
        shader = SprRen.material;
        currentEquip = equip;

        SprRen.sprite = currentEquip.SouthWalking[0];
        if (timer >= 0.5f && currentEquip.SouthWalking[1] != null) SprRen.sprite = currentEquip.SouthWalking[1];
        if (timer >= 1f&& currentEquip.SouthWalking[2] != null) SprRen.sprite = currentEquip.SouthWalking[2];
        if (timer >= 1.5f&& currentEquip.NorthWalking[0] != null) SprRen.sprite = currentEquip.NorthWalking[0];
        if (timer >= 2f&& currentEquip.NorthWalking[1] != null) SprRen.sprite = currentEquip.NorthWalking[1];
        if (timer >= 2.5f&& currentEquip.NorthWalking[2] != null) SprRen.sprite = currentEquip.NorthWalking[2];
        if (timer >= 3f&& currentEquip.EastWalking[0] != null) SprRen.sprite = currentEquip.EastWalking[0];
        if (timer >= 3.5f&& currentEquip.EastWalking[1] != null) SprRen.sprite = currentEquip.EastWalking[1];
        if (timer >= 4f&& currentEquip.EastWalking[2] != null) SprRen.sprite = currentEquip.EastWalking[2];
        if (timer >= 4.5f&& currentEquip.WestWalking[0] != null) SprRen.sprite = currentEquip.WestWalking[0];
        if (timer >= 5f&& currentEquip.WestWalking[1] != null) SprRen.sprite = currentEquip.WestWalking[1];
        if (timer >= 5.5f&& currentEquip.WestWalking[2] != null) SprRen.sprite = currentEquip.WestWalking[2];
        if (timer >= 6f&& currentEquip.PrepAttack[0] != null) SprRen.sprite = currentEquip.PrepAttack[0];
        if (timer >= 6.5f&& currentEquip.PrepAttack[1] != null) SprRen.sprite = currentEquip.PrepAttack[1];


        

        shader.SetColor("_Color1",currentEquip.colors[0]);
        shader.SetColor("_Color2",currentEquip.colors[1]);
        shader.SetColor("_Color3",currentEquip.colors[2]);
        shader.SetColor("_Color4",currentEquip.colors[3]);
        shader.SetColor("_Color5",currentEquip.colors[4]);
        shader.SetColor("_Color6",currentEquip.colors[5]);
        shader.SetColor("_Color7",currentEquip.colors[6]);
        shader.SetColor("_Color8",currentEquip.colors[7]);
    }
}
