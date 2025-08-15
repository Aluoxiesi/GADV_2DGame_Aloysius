using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance;
    public List<string> rescuedAnimals = new List<string>(); //The names of the animals rescued
    

    private void Awake()
    {
        if (Instance == null) //Makes sure that only one AnimalManager exists, and if another one exists, it gets destroyed.
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //Makes it so that the gameobject retains across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AnimalAdd(string animalName)  
    {
        if (!rescuedAnimals.Contains(animalName)) //If the animal name is NOT in the list, then it adds it
        {
            rescuedAnimals.Add(animalName);
        }
    }

    public List<string> AnimalsRescued()
    {
        return rescuedAnimals;
    }
   
}
