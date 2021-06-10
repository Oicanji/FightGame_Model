using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Behavior : MonoBehaviour
{
    //att
    public float damage;
    public float attack_speed;

    //others vars
    public bool inAttack = false;

    //Reference Vars
    private Animator anim;
    private Rigidbody2D rb;
    public SpriteRenderer sprite;
    private Input_Behavior input_controller;
    private BoxCollider2D collider_attack;
    void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();

        //reference a others scripts
        input_controller = GetComponent<Input_Behavior>();
        collider_attack = transform.GetChild(1).GetComponent<BoxCollider2D>();
    }

    IEnumerator AttackCountdown(string variable_animator, float strong){ 
        yield return new WaitForSeconds(attack_speed/3.777f);
        inAttack = false;
        anim.SetFloat(variable_animator, 0.0f);
    }
    public void Attack(){
        inAttack = true;
        
        anim.SetFloat("attack", 1.0f);
        Vector2 S = sprite.bounds.size;
            collider_attack.size = S/16;
            collider_attack.offset = new Vector2 (S.y/18f, S.y/6f);   

        StartCoroutine(AttackCountdown("attack",1.0f)); 
    }
    public void Kick(){
        inAttack = true;
        
        anim.SetFloat("attack", 2.0f);
        StartCoroutine(AttackCountdown("attack",1.5f));
    }


}