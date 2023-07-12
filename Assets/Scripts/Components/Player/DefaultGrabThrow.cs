using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGrabThrow : MonoBehaviour
{
    public GameObject grabbed_object = null;

    private Ability_Array _vikings;
    private LastLookedAtDirection _dir;
    private void Start() {
        _vikings = GetComponent<Ability_Array>();
        _dir = GetComponent<LastLookedAtDirection>();
    }

    void Update() {
        if(Input.GetKeyDown("e")) {
            grab_throw();
        }
    }
    
    public void grab_throw(){
        if(!_vikings.viking_abilities[(int)VIKINGABILITIES.BIG])
            return;
        if(grabbed_object == null){
            _grab();
        }else{
            _throw();
        }
    }

    private void _grab(){
        Debug.Log("Grabbing");
        //v_axe linked to right position
        if(_dir.data == DIRECTIONS.RIGHT){
            //grab V_axe
            grabbed_object = Instantiate(gameObject, transform);
            grabbed_object.transform.position = new Vector3(0, 1, 0);
            grabbed_object.GetComponent<Ability_Array>().clear();
            grabbed_object.GetComponent<Ability_Array>().viking_abilities[(int)VIKINGABILITIES.AXE] = true;
            
            _vikings.viking_abilities[(int)VIKINGABILITIES.AXE] = false;
        }

    }

    private void _throw(){}
}
