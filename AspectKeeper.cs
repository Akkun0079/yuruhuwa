using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AspectKeeper : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera; //対象とするカメラ
    [SerializeField]
    private Vector2 aspectVec; //目的解像度

   void Update()
{
    var screenAspect = Screen.width / (float)Screen.height; // 画面のアスペクト比
    var targetAspect = aspectVec.x / aspectVec.y; // 目的のアスペクト比

    var magRate = targetAspect / screenAspect; // 目的アスペクト比にするための倍率

    var viewportRect = new Rect(0, 0, 1, 1); // Viewport初期値でRectを作成

    if (magRate < 1)
    {
        viewportRect.width = magRate; // 使用する横幅を変更
        viewportRect.x = (1 - viewportRect.width) / 2; // 横方向の中央寄せ
        viewportRect.y = 0; // 上下方向は上端に固定
    }
    else
    {
        viewportRect.height = 1 / magRate; // 使用する縦幅を変更
        viewportRect.y = (1 - viewportRect.height) / 2; // 縦方向の中央寄せ
        viewportRect.x = 0; // 左右方向は左端に固定
    }

    targetCamera.rect = viewportRect; // カメラのViewportに適用
}
}
