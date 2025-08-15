using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LetterPick : MonoBehaviour
{
    public char letter = ' '; //The letter represents whatever the zookeeper picks up, changeable in the inspector
    public TextMeshProUGUI PickLetter;
    
  
    
    void OnTriggerEnter2D(Collider2D other)
    {

        //When the zookeeper with the "Player" tag collides with the letter object, the letter is collected,
        //and added to the "word" in WordList. The UI gets updated, and a sound effect gets played.
        //Then, the letter is destroyed, so it can't be picked up again.
        if(other.tag == "Player")
        {
            
            Debug.Log("Collected: " + letter);
            WordList.instance.word += letter; //Increments the letter into the "word"
            WordList.instance.UpdatedDisplayword(); //Updates the display with the letter picked up
            WordList.instance.PickUpSound();



            Destroy(gameObject); 
            
        }
        
    }
}
