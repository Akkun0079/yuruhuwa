using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageText : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        text.text = $"ステージ解放まで{gameManager.stageOpen}分";
    }
}
