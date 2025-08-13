using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextLev()
    {
        SceneManager.LoadScene("Zebra Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
