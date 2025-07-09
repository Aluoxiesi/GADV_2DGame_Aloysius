using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPick : MonoBehaviour
{
    private char letter = 'L';
    
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Collected: " + letter);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
