using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyMovement : MonoBehaviour
{

    [SerializeField]
    public float x_inverter = 1f;
    [SerializeField]
    public float y_inverter = 1f;
    
    [SerializeField]
    public float Speed = 1;

    [SerializeField]
    float Cooldown = 0;

    Vector2 _MovementInput = Vector2.zero;
    float _cooldown_counter = 0;
    // [SerializeField] private Animation anim;
    // [SerializeField] private Animator animator;

    // void Start() {
    //   anim = gameObject.GetComponent<Animation>();
    //   animator = gameObject.GetComponent<Animator>();
    // }

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
        if (_MovementInput.x != 0 || _MovementInput.y != 0) {
        //   animator.SetBool("Run", true);
        } else {
        //   animator.SetBool("Run", false);
        }
        _MovementInput = _MovementInput.normalized;

        _update_last_looked_at_pos(_MovementInput);

        
        // transform.localPosition += 
        transform.Translate(
            new Vector3(_MovementInput.x*x_inverter, 0.0f, _MovementInput.y*y_inverter) 
                    * Speed * Time.deltaTime
        );
    }

    private void _update_last_looked_at_pos(Vector3 MovementInput)
    {
        LastLookedAtDirection dir_obj;
        if(!TryGetComponent<LastLookedAtDirection>(out dir_obj))
        {
            Debug.LogWarning("LastLookedAtDirNotFound");
            return;
        }

        if(MovementInput ==  Vector3.up)
        {
            dir_obj.data = DIRECTIONS.UP;
        }
        if(MovementInput == Vector3.down)
            dir_obj.data = DIRECTIONS.DOWN;
        if(MovementInput == Vector3.right)
            dir_obj.data = DIRECTIONS.LEFT;
        if(MovementInput == Vector3.left)
            dir_obj.data = DIRECTIONS.RIGHT;
    }
}
