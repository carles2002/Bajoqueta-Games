using UnityEngine;

public class DetectorScript : MonoBehaviour
{
    public Jump jumpScript; // Referencia al script 'Jump'

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto en colisi�n es el player
        if (other.gameObject == jumpScript.player)
        {
            jumpScript.PlayerDetected();
        }
    }
}
