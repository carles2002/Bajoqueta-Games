using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public float rollDuration = 1f;
    private bool isRolling;
    public Transform pivot;
    public Transform ghostPlayer;

    public InputManager InputManager;
    public LayerMask contactWallLayer;
    public ObjectDetector ObjectDetector;


    private void Awake()
    {
        Initialize();
    }

    //cuando se detecta una tecla, se invoca a roll
    void Initialize()
    {
        InputManager.OnKeyDetected += Roll;
        isRolling = false;
    }


    //Empieza una corutina para mover al personaje a ladirección de la flecha
    private void Roll(InputManager.Direction direction)
    {
        StartCoroutine(RollToDirection(direction));
        Debug.Log("direction: " + direction);
    }

    //Obtiene las direcciones necesarias, mueve y rota el objeto
    private IEnumerator RollToDirection(InputManager.Direction KeyDirection)
    {
        if (!isRolling)
        {
            isRolling = true;

            float angle = 90f;

            // Actualiza la posición del pivote.
            Vector3 axis = GetAxis(KeyDirection);
            Vector3 directionVector = GetDirectionVector(KeyDirection);
            Vector2 pivotOffset = GetPivotOffset(KeyDirection);

            //Relocate the pivot according to offset.
           pivot.position = transform.position + (directionVector * pivotOffset.x) + (Vector3.down * pivotOffset.y);

            //simulate before the action in order to get an ideal result
            CopyTransformData(transform, ghostPlayer);
            ghostPlayer.RotateAround(pivot.position, axis, angle);

            float elapsedTime = 0f;

            while (elapsedTime < rollDuration)
            {
                elapsedTime += Time.deltaTime;

                transform.RotateAround(pivot.position, axis, (angle * (Time.deltaTime / rollDuration)));
                yield return null;
            }

            CopyTransformData(ghostPlayer, transform);
            isRolling = false;
        }
    }

    //Obtiene el axis al cual nos moveremos
    private Vector3 GetAxis(InputManager.Direction direction)
    {
        switch (direction)
        {
            case InputManager.Direction.Left:
                return Vector3.forward;
            case InputManager.Direction.Up:
                return Vector3.right;
            case InputManager.Direction.Right:
                return Vector3.back;
            case InputManager.Direction.Down:
                return Vector3.left;
            default:
                Debug.Log("GetAxis ha fallado)");
                return Vector3.zero;
        }
    }
    
    //Obtiene la direción vector del raycast
    private Vector3 GetDirectionVector(InputManager.Direction direction)
    {
        switch (direction)
        {
            case InputManager.Direction.Left:
                return Vector3.left;
            case InputManager.Direction.Up:
                return Vector3.forward;
            case InputManager.Direction.Right:
                return Vector3.right;
            case InputManager.Direction.Down:
                return Vector3.back;
            default:
                Debug.Log("Dirección ha fallado");
                return Vector3.zero;
        }
    }

    //Obtiene el desplazamiento del pivot con un raycast a las paredes del mapa
    private Vector2 GetPivotOffset(InputManager.Direction direction)
    {
        Vector2 pivotOffset = Vector2.zero;
        Vector2 center = transform.GetComponent<BoxCollider>().size / 2f;

        RaycastHit hit;
        //200f distancia a la que llega el rayo
        if (Physics.Raycast(transform.position, transform.up, out hit, 200f, contactWallLayer))
        {
            switch (hit.collider.name)
            {
                case "X":
                    if (direction == InputManager.Direction.Left || direction == InputManager.Direction.Right)
                    {
                        pivotOffset = new Vector2(center.y, center.x);
                        Debug.Log("X");
                    }
                    else
                        pivotOffset = Vector2.one * center.x;
                    break;
                case "Y":
                    Debug.Log("Y");
                    pivotOffset = center;
                    break;
                case "Z":
                    Debug.Log("Z");
                    if (direction == InputManager.Direction.Up || direction == InputManager.Direction.Down)
                    {
                        pivotOffset = new Vector2(center.y, center.x);
                    }
                    else
                        pivotOffset = Vector2.one * center.x;
                    break;
                default:
                    Debug.Log("Raycast hit: " + hit.collider.name);
                    pivotOffset = Vector2.zero;
                    Debug.Log("Raycast missed");
                 
                    break;

            }
        }
        else
        { 
            pivotOffset = Vector2.zero;
            Debug.Log("Raycast missed");
        }

        //cuando el rayo choca con un objeto(no se mueve)

        return pivotOffset;
    }

    //Copia coordenadas al jugador fantasma para evitar que se salga de la guia
    public void CopyTransformData(Transform source, Transform target)
    {
        target.localPosition = source.localPosition;
        target.localEulerAngles = source.localEulerAngles;
    }
}


