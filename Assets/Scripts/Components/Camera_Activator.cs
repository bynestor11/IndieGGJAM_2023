using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_Activator : MonoBehaviour
{
    [SerializeField]
    public Camera myCamera;

    // This relies on collision layers to only grab player
    void OnTriggerEnter(Collider collision)
    {
        foreach (Camera c in Camera.allCameras)
        {
            c.enabled = false;
        }
        
        myCamera.enabled = true;

        foreach(GameObject p in GameObject.FindGameObjectsWithTag("Player") )
        {
            p.transform.eulerAngles = new Vector3(0, myCamera.transform.eulerAngles.y, 0);
        }
    }
}
