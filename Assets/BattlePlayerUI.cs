using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePlayerUI : MonoBehaviour
{

    private static BattlePlayerUI _instance;
    public static BattlePlayerUI Instance{
        get{
            return _instance;
        }
    }
    private void Awake() {
        _instance = this;
    }

    public bool[] PlayerTurnReady = new bool[4];
    public int[] CurrentBuildUps = new int[4];

    int Currentslot = -1;
    public bool ActiveMenu;

    [SerializeField] GameObject FirstMenu;
    [SerializeField] GameObject FightMenu;
    [SerializeField] GameObject ItemMenu;
    [SerializeField] GameObject TargetMenu;

    private void Update() {
        if(ActiveMenu ==true && Currentslot == -1){
        for (int i =0; i< PlayerTurnReady.Length; i++){
            if(PlayerTurnReady[i] ==true){
            FirstMenu.SetActive(true);
            Currentslot = i;
            
            break;
            }
        }
        }
        
        
    }

    Moves[] availableMoves = new Moves[8];
    public Moves selectedMove;
    UsableItem[] items = new UsableItem[8];
    public UsableItem selectedItem;


    public void FightButton(){
        FightMenu.SetActive(true);
        ItemMenu.SetActive(false);
        TargetMenu.SetActive(false);
        FightBattleMenuCommand[] commands = FightMenu.GetComponentsInChildren<FightBattleMenuCommand>();
        availableMoves = GameplayPartyManager.Instance.PartyMembers[GameplayPartyManager.Instance.CurrentParty[Currentslot]].GetEquippedMoves();
        for(int i = 0; i<commands.Length; i++){
            if(availableMoves[i] !=null){
                commands[i].gameObject.SetActive(true);
                commands[i].SkillName[0].text = availableMoves[i].Name;
                commands[i].SkillName[1].text = availableMoves[i].Name;
                commands[i].icon.sprite = availableMoves[i].Icon;
                if(availableMoves[i].HPCost !=0){
                commands[i].HPCost.gameObject.SetActive(true);
                commands[i].ManaCost.gameObject.SetActive(false);
                commands[i].HPCost.text = "-" + availableMoves[i].HPCost;
                }
                else if(availableMoves[i].MPCost !=0){
                commands[i].HPCost.gameObject.SetActive(false);
                commands[i].ManaCost.gameObject.SetActive(true);
                commands[i].HPCost.text = "-" + availableMoves[i].MPCost;
                }
                
            }
            else{
                commands[i].gameObject.SetActive(false);
            }
        }
        
    }

    public void ItemButton(){
        
    }
    
    TargetButtonInformationScript[] targets = new TargetButtonInformationScript[12];
    TargetButtonInformationScript selectedTarget = new TargetButtonInformationScript();
    public void OpenTargetMenu(){
        targetopen = true;
        FightMenu.SetActive(false);
        ItemMenu.SetActive(false);
        TargetMenu.SetActive(true);

        targets = TargetMenu.GetComponentsInChildren<TargetButtonInformationScript>();
        for(int i = 0; i<targets.Length; i++){
            try{
                targets[i].gameObject.SetActive(true);
                targets[i].slot = i;
            
            
            }catch{
                targets[i].gameObject.SetActive(false);
            }
        }
    }

    bool targetopen = false;

    public int selected = -1;
    Button[] TargetButtons = new Button[12];

    int[] TargetstoSend = new int[12];

    public GameObject ConfirmButton;


    public void UpdateTargetUI(){

        targets[selected].thisButton.image.color = new Color(1,0.9f,0.9f);
        int targetcenter = 0;
        for(int i = 0; i<targets.Length; i++){
            if(selectedMove.targets[i] ==i){
                targetcenter = i;
                break;
                
            }
        }
        if(selected >=4){
        for (int i = 0; i<TargetstoSend.Length;i++){
            try{
                if(selected-targetcenter+i >=4)
            TargetstoSend[selected-targetcenter + i] = selectedMove.targets[i];
            }
            catch{};
        }
        }
        else{
            for (int i = 0; i<TargetstoSend.Length;i++){
            try{
                if(selected-targetcenter+i <=3)
            TargetstoSend[selected-targetcenter + i] = selectedMove.targets[i];
            }
            catch{};
        }

        }

        for(int i = 0; i<targets.Length; i++){
            if(TargetstoSend[i] == 0)
            targets[i].thisButton.image.color = new Color(0.9f,0.9f,0.9f);
            else if(TargetstoSend[i] == 1)
            targets[i].thisButton.image.color = new Color(1f,0.9f,0.9f);
            else if(TargetstoSend[i] == 2)
            targets[i].thisButton.image.color = new Color(1,1,1);
        }

        ConfirmButton.SetActive(true);
    }
    

    public void ConfirmActive(){
        ConfirmButton.SetActive(false);
        TargetMenu.SetActive(false);
        FirstMenu.SetActive(false);
        BattleEvents enque = new BattleEvents();
        enque.targets = TargetstoSend;
        enque.Caster = Currentslot;
        enque.thisMove = selectedMove;
        BattleManager.Instance.BattleQueue.Enqueue(enque);
    }


}
