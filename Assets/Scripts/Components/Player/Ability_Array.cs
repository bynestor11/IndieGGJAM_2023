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

    public bool[] viking_abilities = new bool[vikings_abilities_array_size];
}
