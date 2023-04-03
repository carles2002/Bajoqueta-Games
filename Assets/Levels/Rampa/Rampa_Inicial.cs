using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rampa_Inicial : MonoBehaviour
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
                playerRigidbody.constraints = RigidbodyConstraints.FreezePositionX;
                playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;



                Vector3 force = new Vector3(0, 2f, 2.3f);
                playerRigidbody.AddForce(force, ForceMode.Impulse);

            }
        }
    }

}
