using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Load(string level)
    {
        // Load the scene by its name
        SceneManager.LoadScene(level);
    }

        public void LoadSceneAdditively(string sceneName)
        {
            // Load the scene by its name additively
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    public void UnloadSceneAdditively(string sceneName)
    {
        // Unload the scene by its name additively
        SceneManager.UnloadSceneAsync(sceneName);
    }
}

