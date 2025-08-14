using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Wrong : MonoBehaviour
{
    public TextMeshProUGUI incorrect;
    public static Wrong instance;
    
    void Start()
    {
        instance = this;
    }

    //Makes the hidden "WRONG" text show up after the SetActive becomes true
    public void Wronganswer()
    {
        if (incorrect != null)
        {
            incorrect.gameObject.SetActive(true);
            StartCoroutine(Delay());
            
        }
    }


    //Hides the gameobject/text of the "WRONG" popup because of the false SetActive
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        incorrect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
