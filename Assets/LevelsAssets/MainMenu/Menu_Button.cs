using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Menu_Button : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    private void OnMouseUpAsButton() {
        unityEvent.Invoke();
    }
}
