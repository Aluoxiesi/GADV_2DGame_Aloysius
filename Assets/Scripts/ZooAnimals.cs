using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooAnimals : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform zooParent; // Where animals will be placed
    [SerializeField] private GameObject lionPrefab;
    [SerializeField] private GameObject zebraPrefab;
    



    void Start()
    {
        List<string> animals = AnimalManager.Instance.AnimalsRescued();

        foreach (string animal in animals)
        {
            GameObject animalPrefab = null;

            switch (animal)
            {
                case "LION": animalPrefab = lionPrefab; break;
                case "ZEBRA": animalPrefab = zebraPrefab; break;
                    // Add more cases here
            }

            if (animalPrefab != null)
            {
                Instantiate(animalPrefab, zooParent);
            }
        }
    }
}

