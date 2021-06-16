using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Gui_Behavior : MonoBehaviour
{
    private GameObject player1_gui;
    private GameObject player2_gui;

    private GameObject player1_life_actual;
    private GameObject player2_life_actual;

    void Start() {
        player1_gui = GetComponent<GameObject>();
        player2_gui = GetComponent<GameObject>();

        player1_life_actual = player1_gui.transform.GetChild(0).GetComponent<GameObject>();
        player2_life_actual = player2_gui.transform.GetChild(0).GetComponent<GameObject>();
    }

    public void SetLifeActual(string player, float life, float actual_life){
        // life*actual_life
        if(player == "Player1"){
            player1_life_actual.rectTransform.offsetMax = new Vector2(life*actual_life, player1_life_actual.rectTransform.offsetMax.y);
        }else{
            player2_life_actual.rectTransform.offsetMax = new Vector2(-(life*actual_life), player2_life_actual.rectTransform.offsetMax.y);
        }
    }
}