using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooAnimals : MonoBehaviour
{
    
    [SerializeField] private Transform zooParent; 
    [SerializeField] private GameObject lionPrefab;
    [SerializeField] private GameObject zebraPrefab;
    

    //This script puts the rescued animals into the zoo scene(Comeplete Screen).
    //It gets the list of rescued animals, then checks if the prefab matches with the names.
    //When theres a match, that animal prefab is instantiated into the scene.

    void Start()
    {
        List<string> animals = AnimalManager.Instance.AnimalsRescued(); //The list of the animals that were rescued from the AnimalManager script

        foreach (string animal in animals)
        {
            GameObject animalPrefab = null;

            //Checks if the prefab matches with the animal name
            switch (animal)
            {
                case "LION": animalPrefab = lionPrefab; break;
                case "ZEBRA": animalPrefab = zebraPrefab; break;
                    
            }

            //If a match is found, then the prefab is instantiated
            if (animalPrefab != null)
            {
                Instantiate(animalPrefab, zooParent);
            }
        }
    }
}

