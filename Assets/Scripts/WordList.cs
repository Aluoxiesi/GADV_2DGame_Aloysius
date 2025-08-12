using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordList : MonoBehaviour
{
    public string word = "";
    private List<string> correctwords = new List<string> { "LION" };
    public static WordList instance;
    public TextMeshProUGUI DisplayWords;
    public float WordLength;
    public TextMeshProUGUI WordHint;
    public Button Restart;
    [SerializeField] private AudioClip pickup;
    private AudioSource pick;
    [SerializeField] private AudioClip HintSound;
    private AudioSource Hsound;
    public int Attempts = 0;
    


    // Start is called before the first frame update


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pick = GetComponent<AudioSource>();
        Hsound = GetComponent<AudioSource>();
    }

    void Check()
    {
        foreach (string correct in correctwords)
        {
            if (word == correct)
            {
                Debug.Log($"(Correct!) The word is {word}");
                DisplayWords.text = word;

                
                word = "";
                SceneManager.LoadScene("Complete screen");
                return;
            }


        }
        Debug.Log($"Wrong! {word}");
        DisplayWords.text = word;
        Wrong.instance.Wronganswer();

        StartCoroutine(Hint());
        word = "";
        ResetPos.instance.ResetPosition();
    }

    IEnumerator Hint()
    {
        

        
        Attempts += 1;
        if (Attempts == 2)
        {
            if (WordHint != null)
            {
                WordHint.gameObject.SetActive(true);
                HintNotification();
                yield return new WaitForSeconds(2f);
                WordHint.gameObject.SetActive(false);
            }
            Attempts = 0;
        }

        yield return new WaitForSeconds(0.5f);
        Spawn.instance.SpawnLetters();



    }

    public void Placement()
    {

    }

    public void HintNotification()
    {
        Hsound.clip = HintSound;
        Hsound.Play();
    }

    public void PickUpSound()
    {
        pick.clip = pickup;
        pick.Play();
    }

    public void UpdatedDisplayword()
    {
        string display = "";

        for (int i = 0; i < WordLength; i++)
        {
            if (i < word.Length)
                display += word[i] + "";
            else
                display += "_ ";
        }

        DisplayWords.text = display;
    }
   
    void Update()
    {
        if (word.Length == WordLength)
        {
            Check();
        }
        
    }
}
