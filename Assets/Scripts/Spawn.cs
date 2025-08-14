using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;
    public GameObject[] letterPrefabs; 
    public Transform[] spawnPoints;


    //Randomly spawns letter prefabs at the spawnpoints.
    //A random letter prefab is chosen randomly from the list of letter prefabs.
    //When a letter is chosen, it is then removed so that there are no duplicates spawning
    public void SpawnLetters()
    {
        //picks a random letter prefab from the letterPrefabs array.
        GameObject letterPrefab = letterPrefabs[Random.Range(0, letterPrefabs.Length)];

        List<GameObject> letters = new List<GameObject>(letterPrefabs);
        List<Transform> points = new List<Transform>(spawnPoints);

        int count = Mathf.Min(letters.Count, points.Count); 

        for (int i = 0; i < count; i++)
        {
            //Picks random letter and spawn point
            int letterIndex = Random.Range(0, letters.Count);
            int pointIndex = Random.Range(0, points.Count);


            //Spawns the letters at the spawnpoints
            Instantiate(letters[letterIndex], points[pointIndex].position, Quaternion.identity);

            //Removes the letters that have already been spawned
            letters.RemoveAt(letterIndex);
            points.RemoveAt(pointIndex);
        }
        

       
        

       
    }
  
    void Start()
    {
        instance = this;
        SpawnLetters();
        
    }

    
}
