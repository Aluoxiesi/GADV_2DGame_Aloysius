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
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Wronganswer()
    {
        if (incorrect != null)
        {
            incorrect.gameObject.SetActive(true);
            StartCoroutine(Delay());
            
        }
    }


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
