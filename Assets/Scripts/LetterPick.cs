using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LetterPick : MonoBehaviour
{
    public char letter = 'L';
    public TextMeshProUGUI PickLetter;
    public AudioSource pick;
    // Start is called before the first frame update


    void Start()
    {
        pick = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            Debug.Log("Collected: " + letter);
            WordList.instance.word += letter;
            WordList.instance.UpdatedDisplayword();
            Debug.Log("Audio should play");
            pick.Play();


            Destroy(gameObject);
            
        }
        
    }


    
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
