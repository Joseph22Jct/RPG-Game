using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchors : MonoBehaviour
{   
    public static CameraAnchors _instance;
    public static CameraAnchors Instance{
        get{
        return _instance;
        }
    }

    private void Awake() {
        _instance = this;
    }

    public Transform PlayerSide;
    public Transform EnemySide;

    public Vector3 GetPositionOfUnit(int slot){
        Transform t = BattleManager.Instance.PUnits[slot].GetComponent<Transform>();
        return t.position;
    }
}
