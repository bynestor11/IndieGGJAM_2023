using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTree : MonoBehaviour
{
    [SerializeField] public int RequiredViking = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetRequiredViking() { return RequiredViking; }
}
