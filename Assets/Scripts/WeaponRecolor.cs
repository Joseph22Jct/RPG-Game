using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecolor : MonoBehaviour
{
    public UsableEquipment currentEquip;
    Material shader;
    SpriteRenderer SprRen;
    // Start is called before the first frame update
    private void OnEnable() {
        SprRen = GetComponent<SpriteRenderer>();
        shader = SprRen.material;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SetWeapon(UsableEquipment equip){
        SprRen = GetComponent<SpriteRenderer>();
        shader = SprRen.material;
        currentEquip = equip;
        

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
