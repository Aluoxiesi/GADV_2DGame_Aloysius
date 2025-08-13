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

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = animal;
        offset = transform.position - target.position;
        transform.position = currentTarget.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = currentTarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        StartCoroutine(Switch());
    }

    IEnumerator Switch()
    {
        yield return new WaitForSeconds(2f);
        currentTarget = target;
    }
}
