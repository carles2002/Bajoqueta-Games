using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform moveTarget;

    private bool isCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        moveTarget.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        isCollider = false;
        transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveTarget.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {

                Collider[] hitColliders = Physics.OverlapSphere(moveTarget.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Obstacle"))
                    {
                        isCollider = true; break;
                    }
                }
                if (!isCollider)
                {
                    moveTarget.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {

                Collider[] hitColliders = Physics.OverlapSphere(moveTarget.position + new Vector3(0f, 0f, Input.GetAxisRaw("Vertical")), .2f);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Obstacle"))
                    {
                        isCollider = true; break;
                    }
                }
                if (!isCollider)
                {
                    moveTarget.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
                }
            }
        }
    }
}
