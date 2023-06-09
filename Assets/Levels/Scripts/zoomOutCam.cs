using System.Collections;
using UnityEngine;

public class zoomOutCam : MonoBehaviour
{
    public Transform player;
    public Transform targetPoint;
    public float zoomDuration = 5f; // Duraci�n del zoom en segundos
    public float targetOrthoSize = 10f; // Tama�o de objetivo para el zoom

    private Camera cam;
    public float initialOrthoSize = 1;
    private bool iniciado = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if (tutorialScript.camZoom)
        {
 
            cam.transform.LookAt(player);
            StartCoroutine(ZoomOutAndRotate());
        }
    }

    IEnumerator ZoomOutAndRotate()
    {
        iniciado = true;
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint.position - transform.position);

        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / zoomDuration;

            // Zoom
            cam.orthographicSize = Mathf.Lerp(initialOrthoSize, targetOrthoSize, t);

            // Rotaci�n
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);

            yield return null;
        }
    }
}
