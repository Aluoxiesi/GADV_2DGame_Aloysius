using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordList : MonoBehaviour
{
    public string word = "";
    private List<string> correctwords = new List<string>{"LION"};
    public static WordList instance;
    public TextMeshProUGUI DisplayWords;
    public float WordLength = 4;
    public TextMeshProUGUI WordHint;
    public TextMeshProUGUI Restart;
    // Start is called before the first frame update


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
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
        StartCoroutine(Hint());
        word = "";
    }

    IEnumerator Hint()
    {
        Debug.Log($"Wrong! {word}");
        DisplayWords.text = word;
        yield return new WaitForSeconds(1f);
        Debug.Log("Hint: The word ends in the letter N");
        if(WordHint != null)
        {
            WordHint.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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
