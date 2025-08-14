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
    public Button Restart;

    public int Attempts = 0;

    [SerializeField] private AudioClip pickup;
    [SerializeField] private AudioClip hintSound;
    [SerializeField] private AudioClip wrongSound;
    [SerializeField] private AudioClip levelComplete;
    private AudioSource sounds;



    // Start is called before the first frame update


    private void Awake()
    {
        instance = this;
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
                displayWords.text = word; 

                AnimalManager.Instance.Animaladd(word); 
                word = ""; 
                StartCoroutine(CompleteLevel()); 
              
                return;
            }
        }
       
        //If the word does not match with the word in the list, then the UI will get updated to the wrong word, and a big wrong image(In the "Wrong" script) pops up on screen, playing the
        //sound effect with it too. The Hint sequence happens, and the word is reset, with the ZooKeeper being sent back to its original position.
        Debug.Log($"Wrong! {word}"); 
        displayWords.text = word;
        Wrong.instance.Wronganswer();
        PlaySound(wrongSound);


        StartCoroutine(Hint());
        word = "";
        ResetPos.instance.ResetPosition();
    }



    IEnumerator CompleteLevel()
    {
        PlaySound(levelComplete); 
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Complete screen");
    }


    IEnumerator Hint()
    {
        Attempts += 1;
        if (Attempts == 2)
        {
            if (WordHint != null)
            {
                WordHint.gameObject.SetActive(true);
                PlaySound(hintSound);
                yield return new WaitForSeconds(2f);
                WordHint.gameObject.SetActive(false);
            }
            Attempts = 0;
        }

        yield return new WaitForSeconds(0.5f);
        Spawn.instance.SpawnLetters();
    }

      public void PickUpSound()
    {
        PlaySound(pickup);
    }
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && sounds != null)
            sounds.PlayOneShot(clip);
    }

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

        displayWords.text = display;
    }
   
    void Update()
    {
        if (word.Length == wordLength)
        {
            Check();
        }
        
    }
}
