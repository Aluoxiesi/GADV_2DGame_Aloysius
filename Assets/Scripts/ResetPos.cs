using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public Transform Zookeeper;
    private Vector3 initialPosition;
    public static ResetPos instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        initialPosition = Zookeeper.position;
    }

    public void ResetPosition()
    {
        Zookeeper.position = initialPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
