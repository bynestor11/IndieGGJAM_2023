using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    [SerializeField]
    public string NextLevelPath;

    // This relies on collision layers to only grab player
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(NextLevelPath);
        SceneManager.LoadScene(NextLevelPath, LoadSceneMode.Single);
    }
}
