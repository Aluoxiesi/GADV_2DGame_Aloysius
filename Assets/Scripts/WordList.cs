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
        Debug.Log($"Wrong! {word}");
        word = "";
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
