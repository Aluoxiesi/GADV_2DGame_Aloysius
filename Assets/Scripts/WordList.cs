using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class WordList : MonoBehaviour
{
    public string word = "";
    private List<string> correctWords = new List<string> { "LION", "ZEBRA" }; //This makes a private list called "correctwords", which will contain the animals' names.
    public static WordList instance; //Creates a static reference for this script
    public float wordLength;

    public TextMeshProUGUI WordHint; 
    public TextMeshProUGUI displayWords;
    

    public int Attempts = 0; //Tracks the attempts of the player

    [SerializeField] private AudioClip pickup; //Sound for picking up letters
    [SerializeField] private AudioClip hintSound; //Sound of hint notification
    [SerializeField] private AudioClip wrongSound; //Sound that plays when the player gets the word wrong
    [SerializeField] private AudioClip levelComplete; //Sound of level completion
    private AudioSource sounds;



    // Start is called before the first frame update


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        sounds = GetComponent<AudioSource>();
    }




    //This function checks the word the player formed against the words in the list(correctWords).
    //If the word matches the word in the list, then the UI will be updated with that new word. 
    //Then, it will add the animal word into a list of animals that were rescued.(In "Animal Manager" script)
    //It resets the word, and runs CompleteLevel() coroutine, which plays a sound effect and loads the next scene.
        void Check() 
    {
        foreach (string correct in correctWords) 
        {
            if (word == correct) 
            {
                Debug.Log($"(Correct!) The word is {word}");
                displayWords.text = word;  //Changes the display to the completed word

                AnimalManager.Instance.AnimalAdd(word); 
                word = ""; 
                StartCoroutine(CompleteLevel()); 
              
                return;
            }
        }
       
        //If the word does not match with the word in the list, then the UI will get updated to the wrong word, and a big wrong image(In the "Wrong" script) pops up on screen, playing the
        //sound effect with it too. The Hint sequence happens, and the word is reset, with the ZooKeeper being sent back to its original position.
        Debug.Log($"Wrong! {word}"); 
        displayWords.text = word;
        Wrong.Instance.Wronganswer();
        PlaySound(wrongSound);


        StartCoroutine(Hint());
        word = "";
        ResetPos.Instance.ResetPosition();
        Spawn.Instance.SpawnLetters(); //Spawns the letters again
    }


    //Coroutine that plays the comeplete level sound effect
    //AFter 1 second, then it loads the "Complete Screen" level
    IEnumerator CompleteLevel()
    {
        PlaySound(levelComplete); 
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Complete screen");
    }

    //A coroutine that displays a hint after the player fails to build the correct word two times
    IEnumerator Hint()
    {
        Attempts += 1; //Increments the attempt by 1
        if (Attempts == 2)
        {
            if (WordHint != null) //Sets the hidden object(Hint notification) to active, then sets it to inactive again after 2 seconds to hide it
            {
                WordHint.gameObject.SetActive(true);
                PlaySound(hintSound);
                yield return new WaitForSeconds(2f);
                WordHint.gameObject.SetActive(false);
            }
            Attempts = 0; //Resets the attempts back to 0
        }

        yield return new WaitForSeconds(0.5f);
        
    }

      public void PickUpSound()
    {
        PlaySound(pickup);
    }
    private void PlaySound(AudioClip clip)
    {
        
            sounds.PlayOneShot(clip);
    }


    //Updates the display word with the current word,
    //it loops through each letter, until it hits the word length,
    //then displays the letter in the position, when the letter is picked up
    //The letters that have not been picked up will show "_" instead
    public void UpdatedDisplayword()
    {
        string display = "";

        for (int i = 0; i < wordLength; i++)
        {
            if (i < word.Length)
                display += word[i] + "";
            else
                display += "_ ";
        }

        displayWords.text = display; //Put this into the display
    }
   
    //Checks continuosly to see if the word has reached the word length needed to run the Check() function.
    void Update() 
    {
        if (word.Length == wordLength)
        {
            Check();
        }
        
    }
}
