using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TimeController : MonoBehaviour
{
    [Header("타임 바")]
    public Image timeBarFill; 
    public float duration = 10f;

    [Header("캐릭터 이동")]
    public Transform character; 
    public Transform startPoint; 
    public Transform endPoint;  

    private float timer = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        // 타이머 진행
        timer += Time.deltaTime;
        float progress = Mathf.Clamp01(timer / duration);

        // 타임바 색 채우기
        if (timeBarFill != null)
            timeBarFill.fillAmount = progress;

        // 캐릭터 이동
        if (character != null && startPoint != null && endPoint != null)
            character.position = Vector3.Lerp(startPoint.position, endPoint.position, progress);

        // 완료 시 정지
        if (progress >= 1f)
            isRunning = false;
    }
}
