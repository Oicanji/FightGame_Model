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
    public int currect_player;

    //Reference to Actions Inputs
    public Move_Behavior move;
    public Attack_Behavior attack;
    
    //Others References
    public Controller controller;
    public ControllerConfig input;
    public virtual  void Start(){
        move = GetComponent<Move_Behavior>();
        attack = GetComponent<Attack_Behavior>();

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
    public void Block_Input(){
        if(controller.isBlock()){
            move.Block();
        }else{
            move.Cancel_Block();
        }
    }
    public void Sneak_Input(){
        if(controller.isSneak()){
            move.Sneak();
        }else{
            move.Cancel_Sneak();
        }
    }
    public void Jump_Input(){
        if(controller.isJump()){
            move.Jump();
        }
    }
    //############################### attack
    public void Attack_Input(){
        if(controller.isAttack()){
            attack.Attack();
        }
    }
    public void Kick_Input(){
        if(controller.isKick()){
            attack.Kick();
        }
    }
}