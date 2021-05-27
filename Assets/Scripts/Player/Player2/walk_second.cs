using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_second : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    public float speed;
    public bool stun = false;
    private int x;
    public string direction_start = "left";

    void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 

        if(direction_start == "right"){
            anim.SetInteger("axis x",1);
        }else{
            anim.SetInteger("axis x",-1);
        }
    }

    void FixedUpdate(){

    }
    void Update(){
        if(!stun){
            //AXIS X 1-
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow)){
                anim.SetInteger("axis x",-1);
            }

            //AXIS X 1+
            if (Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow)){
                anim.SetInteger("axis x",1);
            }
            Move();
        }
    }
    void Move(){
        if(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)){
            x = -1;
        }else if(Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){
            x = 1;
        }else{
            x = 0;
        }
        float moveBy = x * speed;

        
        if(moveBy!=0){
            anim.SetBool("walk",true);
        }else{
            anim.SetBool("walk",false);
        }
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
        
    }
}
