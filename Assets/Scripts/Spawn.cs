using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;
    public GameObject[] letterPrefabs; 
    public Transform[] spawnPoints;
    public void SpawnLetters()
    {

        GameObject letterPrefab = letterPrefabs[Random.Range(0, letterPrefabs.Length)];

        List<GameObject> letters = new List<GameObject>(letterPrefabs);
        List<Transform> points = new List<Transform>(spawnPoints);

        int count = Mathf.Min(letters.Count, points.Count); 

        for (int i = 0; i < count; i++)
        {
            int letterIndex = Random.Range(0, letters.Count);
            int pointIndex = Random.Range(0, points.Count);

            Instantiate(letters[letterIndex], points[pointIndex].position, Quaternion.identity);

            letters.RemoveAt(letterIndex);
            points.RemoveAt(pointIndex);
        }
        

       
        

       
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SpawnLetters();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
