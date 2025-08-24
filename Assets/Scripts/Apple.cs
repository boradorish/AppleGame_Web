using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Apple : MonoBehaviour
{
    // [Header("Apple Settings")]
    public int value; // 1~9 랜덤 숫자
    public TextMeshProUGUI numberText;
    public GameObject effectPrefab; // 파괴 효과

    void Start()
    {
        SetRandomValue();
    }

    public void SetRandomValue()
    {
        value = Random.Range(1, 10); // 1~9
        UpdateText();
    }


    public void UpdateText()
    {
        if (numberText != null)
        {
            numberText.text = value.ToString();
        }
    }


    public void DestroyApple()
    {
        OnDestroy();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(1);
        }
        Destroy(gameObject, 0.5f);
    }

    void OnDestroy()
    {
        if (effectPrefab != null)
        {
            effectPrefab.SetActive(true);
            Destroy(effectPrefab, 0.5f);
        }
    }
}

