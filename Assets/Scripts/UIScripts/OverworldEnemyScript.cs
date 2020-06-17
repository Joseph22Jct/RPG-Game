using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class OverworldEnemyScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject Player;

    public EnemyGroup theGroup;
    private void OnTriggerEnter2D(Collider2D other) {
        
        transform.DOMove(Player.transform.position, 4);
        //gameObject.transform.move(gameObject, Player.transform.position, 4);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        transform.position = new Vector3(-6,-2,0);
        GameplayPartyManager.Instance.StartCombat(theGroup);
        
    }
}
