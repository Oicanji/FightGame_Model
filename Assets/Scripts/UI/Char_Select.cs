using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Char_Select : MonoBehaviour
{
    public GameObject model;
    public List<CharacterConfig> characters = new List<CharacterConfig>();
    void Start()
    {
        foreach (var character in characters){  
            GameObject newFrame = Instantiate(model, new Vector3(0, 0, 0), Quaternion.identity);

            newFrame.GetComponent<Image> ().sprite = character.sprite;

            newFrame.transform.SetParent(this.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
