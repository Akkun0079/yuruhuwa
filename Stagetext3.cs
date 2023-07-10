using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stagetext3 : MonoBehaviour
{
   public TextMeshProUGUI text;

    void Update()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        text.text = $"ステージ解放まで{gameManager.stageOpen3}分";
    }
}
