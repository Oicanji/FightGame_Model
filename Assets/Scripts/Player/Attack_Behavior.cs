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

    IEnumerator AttackCountdown(string variable_animator, float delay, float att_range){ 
        inAttack = true;
        yield return new WaitForSeconds(attack_speed/(4.5f*delay));

        Vector2 S = sprite.bounds.size;
        collider_attack.size = S/16;
        float X = (sprite.flipX) ? -1 : 1;
        collider_attack.offset = new Vector2 (((S.x*0.1f)*att_range)*X, S.y/6f);   

        yield return new WaitForSeconds(attack_speed/27.7f);
        inAttack = false;
        anim.SetFloat(variable_animator, 0.0f);
    }
    public void Attack(){
        anim.SetFloat("attack", 1.0f);
        StartCoroutine(AttackCountdown("attack",1.0f,1f)); 
    }
    public void Kick(){
        anim.SetFloat("attack", 2.0f);
        StartCoroutine(AttackCountdown("attack",0.75f,1.2f));
    }
    public void appliedDamage(){
        Debug.Log("bati em alguém");
    }
}