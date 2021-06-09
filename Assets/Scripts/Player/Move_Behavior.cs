/*===========input to player 1====================

"Class used for all basic character movements and 
logic to move a player"

==================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Behavior : MonoBehaviour
{
    public bool slow = false;
    public bool stun = false;

    //att
    public float speed;
    public float tenacity;
    public float jump_force;
    public float jump_double_force;

    //public status
    public bool OnFloor = false;
    public bool OnBlock = false;
    public bool OnSneak = false;
    public int haveDoubleJump = 0;
    //private status

    private Animator anim;
    private Rigidbody2D rb;
    private Input_Behavior input_controller;
    public SpriteRenderer sprite;
    void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();

        //reference a others scripts
        input_controller = GetComponent<Input_Behavior>();
    }

    public void Move(int x){
        bool isWalk = ( x != 0 );
        anim.SetBool("walk", isWalk);
        anim.SetFloat("axis x", x);
        
        //cancel block and sneak
        if(x!=0){
            Cancel_Block();
            Cancel_Sneak();
        }

        float moveBy = (slow)
        ? (x * tenacity)
        : (x * speed);
        
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
    }
    public void Block(){
        if(rb.velocity[0]!=0) return;
        if(OnSneak && OnFloor){
            anim.SetBool("block", true);
            OnBlock = true;
            //Abaixar e Defender
        }else if(!OnSneak){
            anim.SetBool("block", true);
            OnBlock = true;
            //Defender
        }
    }
    public void Cancel_Block(){
        anim.SetBool("block", false);
        OnBlock = false;
    }
    public void Sneak(){
        if(rb.velocity[0]!=0) return;
        if(OnFloor){
            anim.SetBool("sneak", true);
            OnSneak = true;
        }else{
            OnFloor = true;
            haveDoubleJump = 0;
            anim.SetBool("jump",false);
            anim.SetBool("double_jump", false);
            rb.velocity = new Vector2(0.0f, jump_force*-1.0f);
            //Cancelar o Pulo
        }
    }
    public void Cancel_Sneak(){
        anim.SetBool("sneak", false);
        OnSneak = false;
    }
    public void Jump(){
        Cancel_Block();
        Cancel_Sneak();

        if(OnFloor){
            rb.AddForce(new Vector2(0.0f, jump_force), ForceMode2D.Impulse);
            OnFloor = false;
            anim.SetBool("jump", true);
            haveDoubleJump++;
        }else if(haveDoubleJump>0){
            if(rb.velocity[1] > 0.0f){
                rb.AddForce(new Vector2(0.0f, jump_double_force/1.8f), ForceMode2D.Impulse);
            }else if(rb.velocity[1] < 0.0f && rb.velocity[1] > -3.0f){
                rb.AddForce(new Vector2(0.0f, jump_double_force), ForceMode2D.Impulse);
            }else{
                rb.AddForce(new Vector2(0.0f, jump_double_force*1.8f), ForceMode2D.Impulse);
            }
            anim.SetBool("double_jump", true);
            haveDoubleJump--;
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