using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_player1 : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    public float speed;
    public bool stun = false;
    private int x;
    private SpriteRenderer sprite;

    void Start(){
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 

    }

    void FixedUpdate(){

    }
    void Update(){
        if(!stun){
            Move();
        }
    }

    //################################# -variables referring to movement
    void Move(){
        if(Input.GetKey("a") && !Input.GetKey("d")){
            if(sprite){
                x = -1;
            }else{
                x = -2;
            }
        }else if(Input.GetKey("d") && !Input.GetKey("a")){
            if(!sprite){
                x = 1;
            }else{
                x = 2;
            }
        }else{
            x = 0;
        }
        float moveBy = x * speed;

        bool isWalk = moveBy != 0;        
        anim.SetBool("walk", isWalk);
        
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
        
    }
    void Jump(){
        //pular
    }
    //################################# -END of variables referring to movement

    //ataque
    void Jump_Attack(){
        //ataque durante o pulo
    }
}
