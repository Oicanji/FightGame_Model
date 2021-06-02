using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Behavior : MonoBehaviour
{
    public float life_max;
    public float life_actual;
    public float thoughness;
    public int tier = 0;


    void Start() {
        life_actual = life_max;
    }
    void Update(){
        
    }
    public void tier_break(){

    }
}
