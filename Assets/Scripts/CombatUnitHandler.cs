using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitHandler : MonoBehaviour
{
    public Transform Camera;
    private void Update() {
        transform.forward = -Camera.forward;
    }
}
