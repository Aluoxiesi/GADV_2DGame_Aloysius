using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    [SerializeField] private Transform animal;
    private Transform currentTarget;
    [SerializeField] private AudioClip animalSound;
    private AudioSource animalRoar;
    public float minX, maxX;
    public float minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        animalRoar = GetComponent<AudioSource>();
        currentTarget = animal;
        offset = transform.position - target.position;
        transform.position = currentTarget.position + offset;
        RoarSound();
        StartCoroutine(Switch());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = currentTarget.position + offset;
        if (currentTarget == target)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        
        
    }

    public void RoarSound()
    {
        animalRoar.clip = animalSound;
        animalRoar.Play();
    }

    

    IEnumerator Switch()
    {
        yield return new WaitForSeconds(2f);
        currentTarget = target;
    }
}
