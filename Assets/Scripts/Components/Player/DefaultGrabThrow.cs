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

        if(grabbed_object != null) {
            Rigidbody grabbed_object_rigid;
            if( grabbed_object.TryGetComponent<Rigidbody>(out grabbed_object_rigid))
                grabbed_object_rigid.Sleep ();

            grabbed_object.transform.localPosition = new Vector3(0, 0.5f, 0);
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
        //v_axe linked to right position
        if(_dir.data == DIRECTIONS.RIGHT){
           _grab_dude(VIKINGABILITIES.AXE);
        }

    }

    private void _grab_dude(VIKINGABILITIES dude)
    {
        //grab V_axe
        grabbed_object = Instantiate(gameObject, transform);
        grabbed_object.GetComponent<Ability_Array>().clear();
        grabbed_object.GetComponent<Ability_Array>().viking_abilities[(int)dude] = true;
        
        ShittyMovement grabbed_object_ShittyMovement;
        if( grabbed_object.TryGetComponent<ShittyMovement>(out grabbed_object_ShittyMovement))
            grabbed_object_ShittyMovement.Speed = 0;

        // Rigidbody grabbed_object_rigid;
        // if( grabbed_object.TryGetComponent<Rigidbody>(out grabbed_object_rigid))
        //     grabbed_object_ShittyMovement.enabled = false;

        _vikings.viking_abilities[(int)dude] = false;
    }

    private void _throw(){
    }
}
