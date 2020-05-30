using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreInfoPanelScript : MonoBehaviour
{
    public static MoreInfoPanelScript Instance;
    //This never gets disabled, just moves in or out!

    public Image icon;
    public Image iIcon;
    public Text NameItem;
    public Text Description;
    public Text NamePlayer;
    public Text PlayerEpitath;
    public BarSettingScript HPBar;
    public BarSettingScript MPBar;
    
    
    public StatIconBehavior[] Stats = new StatIconBehavior[15];
    public GameObject statholders;

    public EXPBarScript eXPBar;

    public GameObject EquipInfo;
    public GameObject Playerinfo;


    private void Awake() {
        Instance=this;
        
        Stats = statholders.GetComponentsInChildren<StatIconBehavior>();
    }

    public void showPlayerStats(PlayableUnit unit){
        LastSeenPlayer = unit;
        EquipInfo.SetActive(false);
        Playerinfo.SetActive(true);
        icon.sprite = unit.getSpecies().icon;
        NamePlayer.text = unit.getName();
        PlayerEpitath.text = unit.getDescrition();
        HPBar.setBar(unit.getCurrentHP(), unit.getFinalStats()[0]);
        MPBar.setBar(unit.getCurrentMP(), unit.getFinalStats()[1]);

        
            for (int i = 0; i<15; i++){
                Stats[i].gameObject.SetActive(true);
            }
        

        
        Stats[0].changeNumber(unit.getFinalStats()[2]+"");
        Stats[1].changeNumber(unit.getFinalStats()[3]+"");
        Stats[2].changeNumber(unit.getFinalStats()[4]+"");
        Stats[3].changeNumber(unit.getFinalStats()[5]+"");
        Stats[4].changeNumber(unit.getFinalStats()[6]+"");
        Stats[5].changeNumber(unit.getFinalStats()[0]+"");
        Stats[6].changeNumber(unit.getFinalStatusResistances()[0]*100+"%");
        Stats[7].changeNumber(unit.getFinalStatusResistances()[1]*100+"%");
        Stats[8].changeNumber(unit.getFinalStatusResistances()[2]*100+"%");
        Stats[9].changeNumber(unit.getFinalStatusResistances()[3]*100+"%");
        Stats[10].changeNumber(unit.getFinalStats()[1]+"");
        Stats[11].changeNumber(unit.getFinalElemResistances()[0]*100+"%");
        Stats[12].changeNumber(unit.getFinalElemResistances()[1]*100+"%");
        Stats[13].changeNumber(unit.getFinalElemResistances()[2]*100+"%");
        Stats[14].changeNumber(unit.getFinalElemResistances()[3]*100+"%");
        

    }
    PlayableUnit LastSeenPlayer;

    public void UpdatePlayerStats(){
        showPlayerStats(LastSeenPlayer);
    }

    public void showItemStats(UsableItem item){
        EquipInfo.SetActive(true);
        Playerinfo.SetActive(false);

        iIcon.sprite = item.icon;
        NameItem.text = item.ClassName;
        Description.text = item.Description;
        eXPBar.noEXPBar();

        if(item.isEquip==null){
            for (int i = 0; i<15; i++){
                Stats[i].gameObject.SetActive(false);
            }
            return;
        }

        else{
            for (int i = 0; i<15; i++){
                Stats[i].gameObject.SetActive(true);
            }
        }

        Stats[0].changeNumber(item.isEquip.boosts[2]+"");
        Stats[1].changeNumber(item.isEquip.boosts[3]+"");
        Stats[2].changeNumber(item.isEquip.boosts[4]+"");
        Stats[3].changeNumber(item.isEquip.boosts[5]+"");
        Stats[4].changeNumber(item.isEquip.boosts[6]+"");
        Stats[5].changeNumber(item.isEquip.boosts[0]+"");
        Stats[6].changeNumber(item.isEquip.resBoosts[0]*100+"%");
        Stats[7].changeNumber(item.isEquip.resBoosts[1]*100+"%");
        Stats[8].changeNumber(item.isEquip.resBoosts[2]*100+"%");
        Stats[9].changeNumber(item.isEquip.resBoosts[3]*100+"%");
        Stats[10].changeNumber(item.isEquip.boosts[1]+"");
        Stats[11].changeNumber(item.isEquip.elementalresBoosts[0]*100+"%");
        Stats[12].changeNumber(item.isEquip.elementalresBoosts[1]*100+"%");
        Stats[13].changeNumber(item.isEquip.elementalresBoosts[2]*100+"%");
        Stats[14].changeNumber(item.isEquip.elementalresBoosts[3]*100+"%");




    }

    public void CompareEquipment(UsableItem item, PlayableUnit unit){

    }
    public void CloseMenu(){
        //Move and disable both
        EquipInfo.SetActive(false);
        Playerinfo.SetActive(false);
    }
}
