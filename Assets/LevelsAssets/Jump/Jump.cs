using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForceY = 10f;
    public float jumpForceX = -3.5f;
    private Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Animator playerAnimator = collision.gameObject.GetComponent<Animator>(); // Obtén el Animator del objeto "Player"
            if (playerRigidbody != null)
            {
                animator = GetComponent<Animator>();
                animator.SetTrigger("jump");

                
                playerRigidbody.constraints = RigidbodyConstraints.None;
                playerRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
                playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                Vector3 force = new Vector3(jumpForceX, jumpForceY, 0f);
                playerRigidbody.AddForce(force, ForceMode.Impulse);
                


            }
        }
    }

}
