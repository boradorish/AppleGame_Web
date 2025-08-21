using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("UI")]
    public RectTransform selectionBox;   // Canvas 안의 SelectionBox
    public Camera cam;                   // 메인 카메라 할당 (없으면 자동)

    void Update()
    {
        if (Mouse.current != null)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();
            Debug.Log("마우스 화면 좌표: " + screenPos);
        }
    }

    
}
