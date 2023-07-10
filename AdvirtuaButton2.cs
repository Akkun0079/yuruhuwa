using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageText2 : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        text.text = $"{gameManager.clearEasyStageNum[0]}_{gameManager.clearEasyStageNum[1]}_{gameManager.clearEasyStageNum[2]}_{gameManager.clearNum}_";
    }
    
}
