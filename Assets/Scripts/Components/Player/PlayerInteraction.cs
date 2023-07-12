using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] string InteractionKey = "e";
    [SerializeField] int MinimumInteractionDistance = 1;
    [SerializeField] bool HoldingRock = false;
    RockInteractable RockBeingHeld;
    // Ability_Array abilities_object = GetComponent<Ability_Array>();
    // Start is called before the first frame update
    void Start()
    {
      GetComponent<Ability_Array>().viking_abilities[1] = true;
    }

    // Update is called once per frame
    void Update()
    {
      if (HoldingRock) {
        ReleaseRock();
      }
      InteractWithPuzzle();
      InteractWithViking();
    }
    void InteractWithPuzzle() {
      if (Input.GetKeyUp("e")) {
        if (HoldingRock) {
          RockInteractable Actually_a_rock = Tree;
          // align the viking to the red line in Unity
          switch(transform.rotation) {
            case 0:
              Actually_a_rock.DirectionMovement = new Vector3(0,0,1);
              Actually_a_rock.KeepMoving;
              break;
            case 90:
              
              break;
            case 180:

              break;
            case -90:

              break;
            default:
              
          }
        }
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
            if (Tree is RockInteractable) {
              HoldingRock = true;
              RockBeingHeld = Tree;
            }
          } else {
            // shrug animation
          }
          }
        } else {
        }
      }
    }

    void InteractWithViking() {

    }
    // checks if the player pressed E then releases rock. Otherwise, does nothing
    void ReleaseRock() {

    }
}
