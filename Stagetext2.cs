using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stagetext2 : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        text.text = $"ステージ解放まで{gameManager.stageOpen2}分";
    }
}