using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rampa_Final : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.constraints = RigidbodyConstraints.FreezePositionX;
                playerRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
                playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;


            }
        }
    }

}
