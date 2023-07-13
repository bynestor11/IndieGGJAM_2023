using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalProjectileConversion : MonoBehaviour
{

    [SerializeField]
    public Vector3 StartingImpulse;
    
    private Rigidbody _rb;
    private bool _rb_created = false;
    private Quaternion orig_rot;

    // Start is called before the first frame update
    void Start()
    {
        orig_rot = transform.rotation;
        if(!TryGetComponent<Rigidbody>(out _rb))
        {
            _rb_created = true;
            _rb = gameObject.AddComponent<Rigidbody>();
        }

        _rb.excludeLayers = LayerMask.GetMask("Player");
        _rb.AddForce(StartingImpulse);
    }

    void Update() {
        if(_rb.IsSleeping())
        {
            on_rb_sleep();
        }
    }


    private void on_rb_sleep()
    {
        _rb.excludeLayers = new LayerMask();
        if(_rb_created){
            Destroy(_rb);
            transform.rotation = orig_rot;
        }

        Destroy(this);        
    }
}
