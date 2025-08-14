using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public Transform Zookeeper;
    private Vector3 initialPosition;
    public static ResetPos instance;

    // Creates a static instance so this script can be accessed from other scripts
    private void Awake()
    {
        instance = this;
    }

    //Stores the first position of the zookeeper at the start of the game
    void Start()
    {
        initialPosition = Zookeeper.position;
    }


    //Resets the position back to the first position that was stored at the start
    public void ResetPosition()
    {
        Zookeeper.position = initialPosition;

    }
}
