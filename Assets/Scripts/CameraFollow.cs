using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset; //Distance of camera and target
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target; //The player that the camera follows
    [SerializeField] private Transform animal;//The animal that the camera follows
    private Transform currentTarget; //The target the camera is currently focused on
    [SerializeField] private AudioClip animalSound; //Sound effect for the specific animal's roar/cry
    private AudioSource animalRoar;
    public float minX, maxX; //The horizontal and vertical limits to set a boundary for the camera, so that they dont go out of bounds, changeable in inspector
    public float minY, maxY;
   
    //This script makes the camera follow the lion at the start for 2 seconds, then switches to follow the player.
    //As the camera follows the player, it will smoothly follow by making use of SmoothDamp.
    //The x and y postions are also clamped, so that the camera cannot go out of bounds.


    //https://www.youtube.com/watch?v=ZBj3LBA2vUY


    
    void Start()
    {
        animalRoar = GetComponent<AudioSource>();
        currentTarget = animal; //Follows the animal first
        offset = transform.position - target.position; //Calculates the distance of camera from the players
        transform.position = currentTarget.position + offset; //Puts the camera onto the animal when the game starts
        RoarSound();
        StartCoroutine(Switch()); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = currentTarget.position + offset;
        if (currentTarget == target) //If the camera is following the player, then the position of the camera will clamp
        {
            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        //Makes it so that the camera is smoothly moving instead of instant
        
        
    }

    public void RoarSound()
    {
        animalRoar.clip = animalSound;
        animalRoar.Play();
    }

    
    //After 2 seconds, switches target from animal to player/ZooKeeper 
    IEnumerator Switch()
    {
        yield return new WaitForSeconds(2f);
        currentTarget = target;
    }
}
