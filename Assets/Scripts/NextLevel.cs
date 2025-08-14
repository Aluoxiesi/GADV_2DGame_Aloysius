using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextLev()
    {
        int count = AnimalManager.Instance.rescuedAnimals.Count;
        if (count == 1)
        {
            SceneManager.LoadScene("Zebra Level");
        }
        else if (count == 2)
        {
            SceneManager.LoadScene("End");
        }
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
