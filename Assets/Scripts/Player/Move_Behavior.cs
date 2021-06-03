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
    public float jump_double_force;

    //public status
    public bool OnFloor = false;
    public int haveDoubleJump = 0;
    //private status
    
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
        anim.SetFloat("axis x", x);
        
        float moveBy = (slow)
        ? (x * tenacity)
        : (x * speed);
        
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
    }
    public void Jump(){
        if(OnFloor){
            rb.AddForce(new Vector2(jump_force, jump_force), ForceMode2D.Impulse);
            OnFloor = false;
            anim.SetBool("jump", true);
            haveDoubleJump++;
        }else if(haveDoubleJump>0){
            if(rb.velocity[1] > 0.0f){
                rb.AddForce(new Vector2(jump_double_force/1.5f, jump_double_force/1.5f), ForceMode2D.Impulse);
            }else if(rb.velocity[1] < 0.0f && rb.velocity[1] > -3.0f){
                rb.AddForce(new Vector2(jump_double_force, jump_double_force), ForceMode2D.Impulse);
            }else{
                rb.AddForce(new Vector2(jump_double_force*1.5f, jump_double_force*1.5f), ForceMode2D.Impulse);
            }
            anim.SetBool("double_jump", true);
            haveDoubleJump--;
        }
    }
    public void Squat(){
        if(OnFloor){

        }else{
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Floor") return;
        
        haveDoubleJump = 0;
        anim.SetBool("jump",false);
        anim.SetBool("double_jump", false);
        OnFloor = true;
    }
}