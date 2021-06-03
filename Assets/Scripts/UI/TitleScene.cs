using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScene : MonoBehaviour
{
    public void Enter(){
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        Application.Quit();
    }
}
