using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraRot : MonoBehaviour
{
    void Update()
    {

        Camera myCamera = Camera.allCameras[0];
        foreach(GameObject p in GameObject.FindGameObjectsWithTag("Player") )
        {
            p.transform.eulerAngles = new Vector3(0, myCamera.transform.eulerAngles.y, 0);
        }
    }
}
