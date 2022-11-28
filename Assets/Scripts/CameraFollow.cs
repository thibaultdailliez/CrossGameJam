using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position;
        
    }
    public void Speed ()
    {
        GetComponent<Camera>().fieldOfView = 65;
    }
    public void Normal()
    {
        GetComponent<Camera>().fieldOfView = 60;
    }

    private void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
