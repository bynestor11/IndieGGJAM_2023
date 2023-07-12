using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VIKINGABILITIES {
    BIG = 0,
    AXE = 1
}



public class Ability_Array : MonoBehaviour
{
    public const int vikings_abilities_array_size = 2;

    [SerializeField]
    public bool[] viking_abilities = new bool[vikings_abilities_array_size];

    [SerializeField]
    public GameObject[] viking_visualizers = new GameObject[vikings_abilities_array_size];

    private void Update() {
        _update_vikings_visuals();
    }

    public void clear(){
        for(int i = 0; i < vikings_abilities_array_size; i++ ){
            viking_abilities[i]=false;
        }
    }

    private void _update_vikings_visuals()
    {
        for(int i = 0; i < vikings_abilities_array_size; i++){
            viking_visualizers[i].SetActive(viking_abilities[i]);
        }
    }
}
