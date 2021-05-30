using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{  
    private ControllerConfig config;

    public Controller(ControllerConfig new_config){
        config = new_config;
    }

    public bool isWalkLeft(){
        return Input.GetKey(config.analog_left) && !Input.GetKey(config.analog_right);
    }

    public bool isWalkRight(){
        return Input.GetKey(config.analog_right) && !Input.GetKey(config.analog_left);
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

    public bool isJump(){
        return Input.GetKeyDown(config.jump);
    }
}