using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public Action<Direction> OnKeyDetected;

    public enum Direction { Left, Up, Right, Down, None }

    Direction direction;

    private void Awake()
    {
        direction = Direction.None;
    }

    //Cada vez que se pulsa una tecla, se obtiene su dirección
    private void Update()
    {
        direction = GetKeyboardDirection();
       
        if (direction != Direction.None)
        {
            OnKeyDetected.Invoke(direction);
            // Do something with this direction data.
            Debug.Log("direction: " + direction);
           
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    //obtiene la dirección de la flecha pulsada
    private Direction GetKeyboardDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //A swipe is detected
            return Direction.Down;
        }   
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return Direction.Right;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            return Direction.Left;
        }
        else
        {
            return Direction.None;
        }
    }
 
}
