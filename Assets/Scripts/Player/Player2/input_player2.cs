/*===========input to player 2====================
Editor: Oicanji;

"Class used for all basic character inputs"
==================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_player2 : Input_Behavior
{    
    void Start(){
        currect_player = 2;
    }
    //################################# -variables referring to movement
    public override void Move_Input(){
        if(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)){
            if(!move.sprite.flipX){
                x = -1;
            }else{
                x = -2;
            }
        }else if(Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){
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
    public override void Jump_Input(){
        if(Input.GetKeyDown("o")){
            Jump();
        }
    }
    //################################# -END of variables referring to movement

    //################################# -variables referring to defending
    //################################# -END variables referring to defending

    //################################# -variables referring to attack
    void Jump_Attack(){
        //ataque durante o pulo
    }
    //################################# -END variables referring to attack
}
