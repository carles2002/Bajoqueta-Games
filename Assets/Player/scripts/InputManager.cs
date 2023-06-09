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

    private float timer = 0f;
    public float delay = 0.5f; // retraso antes de que se procese la entrada

    private void Awake()
    {
        direction = Direction.None;
    }

    private void Update()
    {
        // incrementar el contador de tiempo
        timer += Time.deltaTime;

        // si ha pasado suficiente tiempo, procesar las entradas
        if (timer >= delay)
        {
            direction = GetKeyboardDirection();

            if (direction != Direction.None)
            {
                OnKeyDetected.Invoke(direction);
                timer = 0f; // resetea el temporizador después de que se detecta una entrada
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && timer >= delay)
        {
            PlayerPrefs.SetInt("TutorialCompleted1", 0);
            PlayerPrefs.SetInt("TutorialCompleted2", 0);
            PlayerPrefs.SetInt("TutorialCompleted3", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            timer = 0f; // resetea el temporizador después de que se detecta una entrada
           
        }
    }

    private Direction GetKeyboardDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
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
