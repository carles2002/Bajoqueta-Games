using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump1 : MonoBehaviour
{
    public float jumpForce = 10f;

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
                Vector3 force = new Vector3(-1f, 0f, 0f);
                playerRigidbody.AddForce(force, ForceMode.Impulse);
            }
        }
    }

}
