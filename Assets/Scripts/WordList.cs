using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    public string word = "";
    public List<string> correctwords = new List<string>{"lion"};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Check()
    {
        foreach (string correct in correctwords)
        {
            if (word == correct)
            {
                Debug.Log("Correct!" + word);
                word = "";
                return;
            }
           
           
        }
        Debug.Log("Wrong" + word);
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
