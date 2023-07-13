using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGrabThrow : MonoBehaviour
{
    [SerializeField]
    public float throw_force = 500;

    public GameObject grabbed_object = null;

    private Ability_Array _vikings;
    private LastLookedAtDirection _dir;

    private float _orig_shittymovement_speed;
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
            //grab V_axe
           _grab_dude(VIKINGABILITIES.AXE);
        }

    }

    private void _grab_dude(VIKINGABILITIES dude)
    {
        if(!_vikings.viking_abilities[(int)dude])
            return;

        grabbed_object = Instantiate(gameObject, transform);
        grabbed_object.GetComponent<Ability_Array>().clear();
        grabbed_object.GetComponent<Ability_Array>().viking_abilities[(int)dude] = true;
        
        ShittyMovement grabbed_object_ShittyMovement;
        if( grabbed_object.TryGetComponent<ShittyMovement>(out grabbed_object_ShittyMovement)){
            _orig_shittymovement_speed = grabbed_object_ShittyMovement.Speed;
            grabbed_object_ShittyMovement.Speed = 0;
        }

        // Rigidbody grabbed_object_rigid;
        // if( grabbed_object.TryGetComponent<Rigidbody>(out grabbed_object_rigid))
        //     grabbed_object_rigid.enabled = false;

        _vikings.viking_abilities[(int)dude] = false;
    }

    private void _throw(){
        grabbed_object.transform.parent = transform.parent;

        ShittyMovement grabbed_object_ShittyMovement;
        if( grabbed_object.TryGetComponent<ShittyMovement>(out grabbed_object_ShittyMovement)){
            grabbed_object_ShittyMovement.Speed = _orig_shittymovement_speed;
        }

        // Rigidbody grabbed_object_rigid;
        // if( grabbed_object.TryGetComponent<Rigidbody>(out grabbed_object_rigid))
        //     grabbed_object_rigid.enabled = true;

        TemporalProjectileConversion projectile_comp = grabbed_object.AddComponent<TemporalProjectileConversion>();
        projectile_comp.StartingImpulse = (_dir.dir_vector+Vector3.up*0.3f) * throw_force;

        grabbed_object = null;
    }
}
