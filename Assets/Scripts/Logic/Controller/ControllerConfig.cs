using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Controller", menuName = "Logic/New Controller")]
public class ControllerConfig : ScriptableObject
{
    [Header("Controller Information")]
    public int Id;
    public string analog_left;
    public string analog_right;
    public string analog_up;
    public string analog_down;
    public string jump;

}
