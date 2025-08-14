using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //When the player rescues an animal, the count of rescued animals increases,
    //so if only one animal is rescued, then it loads the next level(Zebra Level),
    //but when 2 animals are rescued, it loads the "End" scene.
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




}
