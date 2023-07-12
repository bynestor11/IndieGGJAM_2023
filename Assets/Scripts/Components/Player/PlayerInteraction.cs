using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] string InteractionKey = "E";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyUp(InteractionKey)) {
        GameObject[] objectives = GameObject.FindGameObjectsWithTag("Interactable");
        Vector3 objective = transform.position;
        float minorDistance = float.PositiveInfinity;
        foreach (GameObject interactable in objectives)
        {
          // Distance between this object and cilinder
          float distanceBetween = Vector3.Distance(
            transform.position,
            interactable.transform.position
          );
          if (distanceBetween < minorDistance)
          {
            objective = interactable.transform.position;
            minorDistance = distanceBetween;
          }
        }
        // if we got the viking go ahead
      }
    }

    
}
