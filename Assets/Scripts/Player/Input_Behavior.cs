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
    public SpriteRenderer sprite;
    void Start(){
        move = GetComponent<Move_Behavior>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update(){
        Move_Input();
        Jump_Input();
    }
    //################################ - override functions

    //################################ - movent
    public virtual void Move_Input(){
        //set a differents inputs
    }
    public void Move(){
        move.Move(x);
    }
    public virtual void Jump_Input(){
    }
    public void Jump(){
        move.Jump();
    }
}