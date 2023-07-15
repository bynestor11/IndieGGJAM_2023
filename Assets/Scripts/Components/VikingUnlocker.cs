using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingUnlocker : MonoBehaviour
{
    [SerializeField]
    public VIKINGABILITIES viking_unlocked;
    void OnTriggerEnter(Collider col)
    {
        Ability_Array arr = col.transform.parent.GetComponent<Ability_Array>();
        arr.viking_abilities[(int)viking_unlocked] = true;

        Destroy(gameObject);
    }
}
