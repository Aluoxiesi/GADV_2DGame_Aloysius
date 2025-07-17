using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordList : MonoBehaviour
{
    public string word = "";
    private List<string> correctwords = new List<string>{"LION"};
    public static WordList instance;
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
                word = "";
                return;
            }
           
           
        }
        StartCoroutine(Hint());
        word = "";
    }

    IEnumerator Hint()
    {
        Debug.Log($"Wrong! {word}");
        yield return new WaitForSeconds(1f);
        Debug.Log("Hint: The word ends in the letter N");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    // Update is called once per frame
    void Update()
    {
        if (word.Length == 4)
        {
            Check();
        }
        
    }
}
