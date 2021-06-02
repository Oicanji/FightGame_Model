/*===========input to player 1====================

"Class used for all basic character movements and 
logic to move a player"

==================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Behavior : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public bool slow = false;
    public bool stun = false;

    Input_Behavior input_controller;

    //att
    public float speed;
    public float tenacity;
    public float jump_force;

    //public status
    public bool OnFloor = false;
    
    public SpriteRenderer sprite;
    void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();

        //reference a others scripts
        input_controller = GetComponent<Input_Behavior>();
    }

    public void Move(int x){
        if(stun) return;

        bool isWalk = ( x != 0 );
        anim.SetBool("walk", isWalk);
        
        float moveBy = (slow)
        ? (x * tenacity)
        : (x * speed);
        
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
    }
    public void Jump(){
        if(!OnFloor) return;

        rb.AddForce(new Vector2(jump_force, jump_force), ForceMode2D.Impulse);
        OnFloor = false;
        anim.SetBool("jump", true);
    }
    public void Squat(){
        if(OnFloor){

        }else{
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Floor") return;
            
        anim.SetBool("jump",false);
        OnFloor = true;
    }
}