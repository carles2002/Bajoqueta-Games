using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2 : MonoBehaviour
{
    public float jumpForceY = 10f;
    public float jumpForceX = 0f;
    public float jumpForceZ = -1.9f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.constraints = RigidbodyConstraints.None;
                playerRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
                playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                Vector3 force = new Vector3(jumpForceX, jumpForceY, jumpForceZ);
                playerRigidbody.AddForce(force, ForceMode.Impulse);
            }
        }
    }

}
