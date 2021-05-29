using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public int position_player;
    private SpriteRenderer sprite_player1;
    private SpriteRenderer sprite_player2;

    void Start() {
        sprite_player1 = player1.GetComponent<SpriteRenderer>();
        sprite_player2 = player2.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if((player1.transform.position.x-player2.transform.position.x) < 0){
            sprite_player1.flipX = false;
            sprite_player2.flipX = true;
            position_player =  1;
        }else{
            sprite_player1.flipX = true;
            sprite_player2.flipX = false;
            position_player = -1;
        }
    }
}
