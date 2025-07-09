using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPick : MonoBehaviour
{
    public char letter = 'L';
    
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            Debug.Log("Collected: " + letter);
            WordList.instance.word += letter;
            Destroy(gameObject);
            
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
