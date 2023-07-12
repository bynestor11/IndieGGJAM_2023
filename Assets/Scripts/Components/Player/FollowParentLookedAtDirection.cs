using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParentLookedAtDirection : MonoBehaviour
{
    void Update()
    {
        DIRECTIONS dir = GetComponentInParent<LastLookedAtDirection>().data;

        switch (dir)
        {
            case DIRECTIONS.UP:
                transform.localEulerAngles = new Vector3(0, 0, 0);
                break;
            case DIRECTIONS.DOWN:
                transform.localEulerAngles = new Vector3(0, 180, 0);
                break;
            case DIRECTIONS.LEFT:
                transform.localEulerAngles = new Vector3(0, 90, 0);
                break;
            case DIRECTIONS.RIGHT:
                transform.localEulerAngles = new Vector3(0, -90, 0);
                break;
            default:
                break;
        } 
    }
}
