using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] string InteractionKey = "e";
    [SerializeField] int MinimumInteractionDistance = 1;
    // Ability_Array abilities_object = GetComponent<Ability_Array>();
    // Start is called before the first frame update
    void Start()
    {
      GetComponent<Ability_Array>().viking_abilities[1] = true;
    }

    // Update is called once per frame
    void Update()
    {
      InteractWithPuzzle();
      InteractWithViking();
    }
    void InteractWithPuzzle() {
      if (Input.GetKeyUp("e")) {
        GameObject[] objectives = GameObject.FindGameObjectsWithTag("Interactable");
        GameObject objective = objectives[0];
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
            objective = interactable;
            minorDistance = distanceBetween;
          }
        }
        if (minorDistance <= MinimumInteractionDistance) {
          InteractableTree object_component = objective.GetComponent<InteractableTree>();
          Debug.Log(object_component);
        
          InteractableTree Tree = objective.GetComponent<InteractableTree>();
          if(Tree)
          {
            int index = Tree.RequiredViking; 
          
          // if (abilities_object.viking_abilities[objective.GetComponent<InteractableTree>().RequiredViking]) {
            if (GetComponent<Ability_Array>().viking_abilities[index]) {
            // animation that we got it
            Debug.Log("Ability triggered!");
          } else {
            // shrug animation
            Debug.Log("Ability failed!");
          }
          }
        } else {
          Debug.Log("Out of range.");
        }
      }
    }

    void InteractWithViking() {

    }
}
