using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact_wall : MonoBehaviour
{
    public int speed = 300;
    public Vector3 prismDimensions = new Vector3(1, 1, 2);
    public float wallCheckDistance = 0.6f;
    public LayerMask wallLayer;
    public InputManager InputManager;
    bool isMoving = false;


    void Update()
    {

        bool IsWallInDirection(Vector3 direction)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, wallCheckDistance, wallLayer))
            {
                return true;
            }
            return false;
        }

    }
}
