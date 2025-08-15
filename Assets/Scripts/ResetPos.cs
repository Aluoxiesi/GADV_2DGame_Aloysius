using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public Transform zooKeeper;
    private Vector3 initialPosition;
    public static ResetPos Instance;

    // Creates a static instance so this script can be accessed from other scripts
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    //Stores the first position of the zookeeper at the start of the game
    void Start()
    {
        initialPosition = zooKeeper.position;
    }


    //Resets the position back to the first position that was stored at the start
    public void ResetPosition()
    {
        zooKeeper.position = initialPosition;

    }
}
