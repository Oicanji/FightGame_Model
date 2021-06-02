using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Behavior : MonoBehaviour
{
    public float life_max;
    public float life_actual;
    public float thoughness;
    public int tier = 0;


    public void SetIniGame() {
        life_actual = life_max;
    }
    public void tier_break(){

    }
}
