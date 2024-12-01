using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    // Level number to determine which scene to open
    public int level;

    // Update is called once per frame
    public void OpenScene()
    {
        // Generate scene name based on level number
        string sceneName = "Dialog " + level;

        // Load the scene with the generated name
        SceneManager.LoadScene(sceneName);
    }
}
