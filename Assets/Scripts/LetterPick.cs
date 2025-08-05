using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LetterPick : MonoBehaviour
{
    public char letter = 'L';
    public TextMeshProUGUI PickLetter;
    
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            Debug.Log("Collected: " + letter);
            WordList.instance.word += letter;
            if (PickLetter != null)
            {
                PickLetter.gameObject.SetActive(true);
                PickLetter.text = $"Picked up {letter}";
                StartCoroutine(HideText());
            }


        }
        
    }

    IEnumerator HideText()
    {
        Debug.Log("Starting Couritne");
        yield return new WaitForSeconds(0.5f);
        PickLetter.gameObject.SetActive(false);
        Debug.Log("Hiding the text now");
        Destroy(gameObject);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
