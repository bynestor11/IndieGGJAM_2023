using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] string InteractionKey = "e";
    [SerializeField] int MinimumInteractionDistance = 1;
    [SerializeField] bool HoldingRock = false;
    [SerializeField] private Animator animator;
    RockInteractable RockBeingHeld;
    // Ability_Array abilities_object = GetComponent<Ability_Array>();
    // Start is called before the first frame update
    void Start()
    {
      GetComponent<Ability_Array>().viking_abilities[1] = true;
      animator = gameObject.GetComponent<Animator>();
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
      if (Input.GetKeyUp(InteractionKey)) {
        
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
              if (Tree is InteractableTree) {
                animator.SetBool("Swing", true);
              }
            if (Tree is RockInteractable) {
              HoldingRock = true;
              RockBeingHeld = (RockInteractable)Tree;
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
