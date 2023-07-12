using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInteractable : InteractableTree
{
    [SerializeField] public int RequiredViking = 0;
    public bool KeepMoving = false;
    [SerializeField] public (int x, int y, int z) DirectionMovement;
    [SerializeField] public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      if (KeepMoving) {
        if (DirectionMovement) {
          transform.position += Vector3(DirectionMovement.x * Speed, DirectionMovement * y, DirectionMovement * z); // is not expected to move upwards or downwards
        } else {
          Debug.Log("No direction movement for the rock");
          KeepMoving = false;
        }
      }
    }
    // If the rock crashes onto something, it stops
    private void OnCollisionEnter(Collision other) {
      if (KeepMoving) {
        KeepMoving = false;
        //force_factor.velocity = new Vector3(0,0,0);
      }
    }

    public void StopMoving() {
      KeepMoving = false;
      //force_factor.velocity = new Vector3(0,0,0);
    }
}
