using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

    public string SceneName;
    public void play()
    {
        SceneManager.LoadScene(SceneName);  
    }
}
