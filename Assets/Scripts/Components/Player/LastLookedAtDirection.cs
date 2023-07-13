using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTIONS {
    UP,
    RIGHT,
    DOWN,
    LEFT
}

public class LastLookedAtDirection : MonoBehaviour
{
    [SerializeField]
    public  DIRECTIONS data;

    public Vector3 dir_vector 
    {
        get { 
            switch (data)
            { 
                case DIRECTIONS.UP:
                    return Vector3.up;
                case DIRECTIONS.RIGHT:
                    return Vector3.right;
                case DIRECTIONS.DOWN:  
                    return Vector3.down;
                case DIRECTIONS.LEFT:
                    return Vector3.left;
                default:
                    break;
            }
            return Vector3.zero;
        }
    }
}
