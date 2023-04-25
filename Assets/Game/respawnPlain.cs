using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class respawnPlain : MonoBehaviour
{
    public Transform cube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = cube.position;
        }
    }
}
