using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public float threshold;
    public Transform moveTarget;

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(1.5f, 1f, 1.5f);
            moveTarget.position = transform.position;
        }
    }
}
