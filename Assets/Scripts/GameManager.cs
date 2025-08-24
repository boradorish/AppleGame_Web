using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("타임 바")]
    public Image timeBarFill; 
    public float duration = 10f;

    [Header("캐릭터 이동")]
    public Transform character; 
    public Transform startPoint; 
    public Transform endPoint;  

    [Header("점수")]
    public TextMeshProUGUI scoreText;  

    private int score = 0;
    private float timer = 0f;
    private bool isRunning = true;

     void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;
        float progress = Mathf.Clamp01(timer / duration);

        if (timeBarFill != null)
            timeBarFill.fillAmount = progress;

        if (character != null && startPoint != null && endPoint != null)
            character.position = Vector3.Lerp(startPoint.position, endPoint.position, progress);

        if (progress >= 1f)
            isRunning = false;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
