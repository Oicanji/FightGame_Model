using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Behaviour : MonoBehaviour
{
    public string enemy;
    public Attack_Behavior attack;
    void Start(){
        attack = GetComponentInParent<Attack_Behavior>();
        
        if(attack.player == "Player1"){
            enemy = "Player2";
        }else{
            enemy = "Player";
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemy && attack.inAttack == true){
            attack.inAttack = false;
            attack.appliedDamage();
        }
    }
}