using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance;
    public List<string> rescuedAnimals = new List<string>();
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Animaladd(string animalName)
    {
        if (!rescuedAnimals.Contains(animalName))
        {
            rescuedAnimals.Add(animalName);
        }
    }

    public List<string> AnimalsRescued()
    {
        return rescuedAnimals;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
