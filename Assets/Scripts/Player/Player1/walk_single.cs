using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_single : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {

    }
    void Update()
    {
        //AXIS X 1-
        if (Input.GetKeyDown(KeyCode.A)){
            anim.SetInteger("axis x",-1);
        }

        //AXIS X 1+
        if (Input.GetKeyDown(KeyCode.D)){
            anim.SetInteger("axis x",1);
        }

    }
}
