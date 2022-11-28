using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    PlayerMovement plyrMvmt;

    private void Awake()
    {
        plyrMvmt = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            
            plyrMvmt.AddScore();
            
        }
    }
}
