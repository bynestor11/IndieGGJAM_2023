using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Base_Ability : MonoBehaviour
{
    public readonly VIKINGABILITIES ability_id;

    public abstract void Do_Ability();
}
