using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("UI")]
    public RectTransform selectionBox;   // Canvas 안의 SelectionBox
    public Camera cam; 
                      
    GameObject[] apples;
    Vector2 startPos; // 드래그 시작 좌표
    Vector2 endPos; // 드래그 중 좌표
    private bool isDragging = false; 

    void Awake()
    {
        apples = GameObject.FindGameObjectsWithTag("Apple");
    }

    void Update()
    {
        if (Mouse.current == null) return;

        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            startPos = Input.mousePosition;
            isDragging = true;
            // Debug.Log("드래그 시작 좌표: " + startPos);
        }
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endPos = Input.mousePosition;
            isDragging = false;
            // Debug.Log("드래그 끝 좌표: " + endPos);
            if(!isDragging){
                onDragEnd(startPos, endPos);
            }
        }

    }

    void onDragEnd(Vector2 startPos, Vector2 endPos)
    {
        List<Apple> selectedApple = new List<Apple>();
        foreach (GameObject apple in apples)
        {
            if (apple == null) continue; 

            Apple appleComp = apple.GetComponent<Apple>();
            Vector3 appleScreenPos = Camera.main.WorldToScreenPoint(appleComp.transform.position);
            if(appleScreenPos.x >= Mathf.Min(startPos.x, endPos.x) &&
               appleScreenPos.x <= Mathf.Max(startPos.x, endPos.x) &&
               appleScreenPos.y >= Mathf.Min(startPos.y, endPos.y) &&
               appleScreenPos.y <= Mathf.Max(startPos.y, endPos.y))
            {
                
                selectedApple.Add(appleComp);
            }
        }

        int totalValue = 0;
        foreach (Apple apple in selectedApple)
        {
           totalValue += apple.value;
        }

        if(totalValue == 10) {
            foreach (Apple apple in selectedApple)
            {
                apple.GetComponent<Apple>().DestroyApple();
            }
        }
    }

// GameObject apple = GameObject.FindWithTag("Apple");
// if (apple != null)
// {
//     Debug.Log("Apple 월드 좌표: " + apple.transform.position);
// }

    
}
