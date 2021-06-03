/*=========== Player controller ====================

"Class for all fuctions presents in player GameObj"

==================================================*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Controller : MonoBehaviour
{
    //get all behaviors scripts presents in player
    private Life_Behavior life;
    private Attack_Behavior attack;
    private Move_Behavior move;
    private Input_Behavior input;

    //get a this game objects references
    private Rigidbody2D rb;
    private Animator anim;
    protected AnimatorOverrideController animatorOverrideController;
    private SpriteRenderer sprite;

    //Variable preset to Player
    [Header("Character Select")]
    public CharacterConfig character;

    //others vars
    private bool ini = false;

    void Start() {
            life = GetComponent<Life_Behavior>();
            attack = GetComponent<Attack_Behavior>();
            move = GetComponent<Move_Behavior>();
            input = GetComponent<Input_Behavior>();

            
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>(); 
            sprite = GetComponent<SpriteRenderer>();

            CharSet();
    }
    public void CharSet(){
        //set names and others importants params

        //set graphics params

        animatorOverrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = character.anim;

        //set attributes
        //set a life skills
        life.life_max = character.life;
        life.SetIniGame();

        //set a movement skills

        //set a attack skills

        //set a movement skills
        rb.mass = character.weight;

        if(character.flight){
            //"simulated" a char be fly
            rb.gravityScale = 0.9f;
        }else{
            //as char no fly
            rb.gravityScale = 3.0f;
        }

        move.speed = character.speed;
        move.tenacity = character.tenacity;
        move.jump_force = character.jump_force;
        move.jump_double_force = character.jump_double_force;

        //set audio params

        //set a game start
        ini = true;
    }
    void Update(){
        if(ini){
            if(life.life_actual > 0){
                input.Move_Input();
                input.Jump_Input();
            }
        }
    }

}