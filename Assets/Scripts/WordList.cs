using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        yield return new WaitForSeconds(2f);
        Debug.Log("Hint: The word ends in the letter N");
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Check();
        }
        
    }
}
