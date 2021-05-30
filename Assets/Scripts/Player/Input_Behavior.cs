/*===========input to player 1====================
Editor: Oicanji;

"Class used for all basic character inputs"
==================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Input_Behavior : MonoBehaviour
{
    public int x;
    public Move_Behavior move;
    public int currect_player;
    public Controller controller;
    public ControllerConfig input;
    public virtual  void Start(){
        move = GetComponent<Move_Behavior>();
        controller = new Controller(input);
    }
    void Update(){
        Move_Input();
        Jump_Input();
    }
    //################################ - override functions

    //################################ - movent
    void Move_Input(){
        if(controller.isWalkLeft()){
            if(!move.sprite.flipX){
                x = -1;
            }else{
                x = -2;
            }
        }else if(controller.isWalkRight()){
            if(move.sprite.flipX){
                x = 1;
            }else{
                x = 2;
            }
        }else{
            x = 0;
        }
        Move();
    }
    public void Move(){
        move.Move(x);
    }
    
    public void Jump_Input(){
        if(controller.isJump()) move.Jump();
    }

}