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
        //v_axe linked to right position
        if(_dir.data == DIRECTIONS.RIGHT){
            //grab V_axe
            grabbed_object = Instantiate(gameObject);
        }

    }

    private void _throw(){}
}
