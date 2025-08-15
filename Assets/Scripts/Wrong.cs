using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Wrong : MonoBehaviour
{
    public TextMeshProUGUI incorrect;
    public static Wrong Instance;
    
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    //Checks if the UI has a textmeshpro
    //Sets the hidden text to visible with (SetActive(true))
    //Starts coroutine to hid the text after a delay
    public void Wronganswer()
    {
        if (incorrect != null)
        {
            incorrect.gameObject.SetActive(true);
            StartCoroutine(Delay());
            
        }
    }


    //Waits 2 seconds
    //Sets the text inactive again, hiding the text
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        incorrect.gameObject.SetActive(false);
    }

    
}
