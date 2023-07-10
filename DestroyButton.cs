using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{

    public GameObject[] Chara;

    public EnemyController[] enemyCon;

    public EnemyController2[] enemyCon2;

    public GachaManager gachaManager;

    public GachaManager2 gachaManager2;

    public bool flag = true;

    public void OnClickDestroyButton()
    {
        if(flag == true)
        {
           // 配列内の各キャラクターを順番に処理する
           for (int i = 0; i < enemyCon.Length; i++)
           {
           // キャラクターの GameObject を破壊する
            enemyCon[i].DestroyEnemy(Chara[i]);
           }
           flag = false;
        }
    }

    public void OnClickDestroyButton2()
    {
          if(flag == true)
        {
             // 配列内の各キャラクターを順番に処理する
           for (int i = 0; i < enemyCon2.Length; i++)
           {
            // キャラクターの GameObject を破壊する
            enemyCon2[i].DestroyEnemy(Chara[i]);
           }
        }
        flag = false;
    }
}