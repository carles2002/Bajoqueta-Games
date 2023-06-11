using UnityEngine;

public class DetectorScript : MonoBehaviour
{
    public Jump jumpScript;

    private GameObject player;
    private void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto en colisi�n es el player Y si player est� tocando 'Jump'
        if (other.gameObject == player)
        {
            jumpScript.PlayerDetected();
        }
    }
}
