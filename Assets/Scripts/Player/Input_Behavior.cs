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
    //################################ - override functions

    //################################ - movent
    public void Move_Input(){
        bool playerInLeft = !move.sprite.flipX;
        int speedFront = (playerInLeft) ? 1 : -1;
        int speedBack = speedFront * -1;

        if(controller.isWalkFront(playerInLeft)){
            x = speedFront * 2;
        } else if(controller.isWalkBack(playerInLeft)){
            x = speedBack * 1;
        } else {
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