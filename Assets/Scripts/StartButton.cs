using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    //When the start button is pressed,
    //Loads the first level of the game using Unity's scenemanager.
    public void StartGame()
    {
        SceneManager.LoadScene("Lion Level");
    }
    
    
}
