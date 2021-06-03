using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Character", menuName = "Logic/Player/New Character")]
public class CharacterConfig : ScriptableObject
{
    [Header("Character Information")]
    public int id;
    public string name;
    public Sprite sprite;
    public AnimatorOverrideController anim;
    //alternative color if a players are exist other player with a character
    private Color color_alternative;

    [Header("Attributes Move")]
    public float weight;
    public bool flight;
    public float speed;
    public float tenacity;
    public float jump_force;
    public float jump_double_force;

    [Header("Attributes Move")]
    public float life;
    public float thoughness;

    [Header("Attributes Move")]
    public float attack_speed;
    public float damage;
    //in working ...
    [Header("Attributes Sound")]
    public AudioClip hurt;
    
    public List<ComboConfig> combo_list = new List<ComboConfig>();

}
