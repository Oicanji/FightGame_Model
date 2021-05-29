using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_player1 : Input_Behavior
{
    //################################# -variables referring to movement
    public override void Move_Input(){
        if(Input.GetKey("a") && !Input.GetKey("d")){
            if(!move.sprite.flipX){
                x = -1;
            }else{
                x = -2;
            }
        }else if(Input.GetKey("d") && !Input.GetKey("a")){
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
        if(Input.GetKeyDown("g")){
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
