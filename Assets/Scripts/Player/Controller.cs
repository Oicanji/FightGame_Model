using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{  
    private ControllerConfig config;

    public Controller(ControllerConfig confignew){
        config = confignew;
    }

    public bool isWalkLeft(){
        return Input.GetKey(config.analog_left) && !Input.GetKey(config.analog_right) && !isAttack();
    }

    public bool isWalkRight(){
        return Input.GetKey(config.analog_right) && !Input.GetKey(config.analog_left) && !isAttack();
    }

    public bool isWalkBack(bool playerInLeft){
        return playerInLeft 
        ? isWalkLeft()
        : isWalkRight();
    }

    public bool isWalkFront(bool playerInLeft){
        return playerInLeft 
        ? isWalkRight()
        : isWalkLeft();
    }
    public bool isSneak(){
        return Input.GetKey(config.analog_down);
    }
    public bool isBlock(){
        return Input.GetKey(config.analog_up) && !isAttack();
    }
    public bool isAttack(){
        return Input.GetKeyDown(config.attack);
    }
    public bool isKick(){
        return Input.GetKeyDown(config.kick);
    }
    public bool isJump(){
        return Input.GetKeyDown(config.jump);
    }
}