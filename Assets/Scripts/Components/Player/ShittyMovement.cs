using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyMovement : MonoBehaviour
{
    [SerializeField]
    float Speed = 1;

    [SerializeField]
    float Cooldown = 0;

    Vector2 _MovementInput = Vector2.zero;
    float _cooldown_counter = 0;

    // Update is called once per frame
    void Update()
    {
        _cooldown_counter -= Time.deltaTime;
        if(_cooldown_counter >= 0.0f)
            return;

        _cooldown_counter = Cooldown;

        _MovementInput = Vector2.zero;
        
        _MovementInput.x = Input.GetAxis("Horizontal");
        if(_MovementInput == Vector2.zero)
            _MovementInput.y = Input.GetAxis("Vertical");
    
        _MovementInput = _MovementInput.normalized;
        transform.position += new Vector3(_MovementInput.x, 0.0f, _MovementInput.y) * Speed;
    }
}
