using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LetterPick : MonoBehaviour
{
    public char letter = 'L';
    public TextMeshProUGUI PickLetter;
    
    // Start is called before the first frame update


    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            Debug.Log("Collected: " + letter);
            WordList.instance.word += letter;
            WordList.instance.UpdatedDisplayword();
            WordList.instance.PickUpSound();



            Destroy(gameObject);
            
        }
        
    }


    
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
