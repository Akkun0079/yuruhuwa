using System.Collections.Generic;
using UnityEngine;
using System.IO;
using ES3Internal;

public class GameManager : MonoBehaviour
{
    private string savePath;

    // シングルトンインスタンスのGameManager
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }

    // 最大スタミナと現在のスタミナの値
    public int maxStamina = 100;
    public int currentStamina = 0;
    // スタミナの減少率（1秒あたりの減少量）
    public float staminaDecreaseRate = 1.0f;

    // スタミナの回復時間と回復量
    public float recoveryTime = 30f;
    public int recoverAmount = -1;

    // 次の回復までの残り時間
    private float remainingTime = 0f;

    // ステージ解放までのタイム
    public int stageOpen = 0;
     // ステージ解放までのタイム
    public int stageOpen2 = 0;
     // ステージ解放までのタイム
    public int stageOpen3 = 0;
    // ステージ解放ゲージ減少時間
    public float stageTime = 60f;
     // ステージ解放ゲージ減少時間
    public float stageTime2 = 60f;
     // ステージ解放ゲージ減少時間
    public float stageTime3 = 60f;
    // ステージ解禁の時間
    public int open = 0;

    // 特定の条件のためのフラグ
    public static bool flag10;
    public static bool flag5;

    // 報酬とクリア回数
    public int reward;
    public int clearNum;
    public int advirtuaClear;

    // クリアステージ番号を追跡する配列
    public int[] clearEasyStageNum;
    public int[] clearNormalStageNum;
    public int[] clearHardStageNum;
    public int[] clearBossStageNum;

    // 総合スコア
    public int totalScore;

    // アイテムのための配列
    public int[] item;
    public int[] item2;

    // チケットとチケット獲得数
    public int ticket = 0;
    public int ticketGet = 0;

    // 残り回復時間のプロパティ
    public float RemainingTime
    {
        get { return remainingTime; }
    }

    private void Awake()
    {
       
        // GameManagerが既に存在する場合、このインスタンスを破棄する
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // GameManagerが存在しない場合、このインスタンスをシングルトンとして設定し、シーン間で破棄されないようにする
        instance = this;
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;

          if (ES3.FileExists("SaveFile.es3"))
        {
           LoadData();
        }
        SaveData();
       
        // スタミナの回復を開始
        StartRecovery();
    }

 

    private void Update()
    {

        if (Time.time % 5 < Time.deltaTime)
        {
            SaveData();
            Debug.Log("currentStamina: " + currentStamina + "をセーブ");
            Debug.Log("stageOpen: " + stageOpen + "をセーブ");
        }

        // スタミナが0より大きい場合、回復時間を減らしていく
        if (0 < currentStamina)
        {
            remainingTime -= Time.deltaTime;

            // スタミナの回復時間が経過した場合、スタミナを回復する
            if (remainingTime <= 0)
            {
                currentStamina += recoverAmount;

                // スタミナが最大値を超えた場合、最大値に設定する
                if (currentStamina > maxStamina)
                {
                    currentStamina = maxStamina;
                }

                // スタミナの回復を再開する
                StartRecovery();
            }
        }

        // ステージを時間で解放する処理
        // ステージ解放時間が0より大きい場合、数値を減らしていく
        if (0 < stageOpen)
        {
            stageTime -= Time.deltaTime;

            // 1秒経過した場合、stageOpenを1減らす
            if (stageTime <= 0)
            {
                stageOpen -= 1;
                stageTime = 60;
            }
        }

         if (0 < stageOpen2)
        {
            stageTime2 -= Time.deltaTime;

            // 1秒経過した場合、stageOpenを1減らす
            if (stageTime2 <= 0)
            {
                stageOpen2 -= 1;
                stageTime2 = 60;
            }
        }

         if (0 < stageOpen3)
        {
            stageTime3 -= Time.deltaTime;

            // 1秒経過した場合、stageOpenを1減らす
            if (stageTime3 <= 0)
            {
                stageOpen3 -= 1;
                stageTime3 = 60;
            }
        }
    }

      private void OnDisable()
    {
        // シーンが変わるたびにセーブデータを保存
        SaveData();
    }

    // スタミナの回復を開始するメソッド
    public void StartRecovery()
    {
        remainingTime = recoveryTime;
    }

    // スタミナを使用するメソッド
    public bool UseStamina(int amount)
    {
        // スタミナが使用量以上ある場合、スタミナを減らしtrueを返す
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
            return true;
        }

        // スタミナが不足している場合、falseを返す
        return false;
    }

    
    private void SaveData()
    {
       // 変数や配列のセーブ
        ES3.Save("reward", reward);
        ES3.Save("clearNum", clearNum);
        ES3.Save("advirtuaClear", advirtuaClear);
        ES3.Save("clearEasyStageNum", clearEasyStageNum);
        ES3.Save("clearNormalStageNum", clearNormalStageNum);
        ES3.Save("clearHardStageNum", clearHardStageNum);
        ES3.Save("clearBossStageNum", clearBossStageNum);
        ES3.Save("totalScore", totalScore);
        ES3.Save("item", item);
        ES3.Save("item2", item2);
        ES3.Save("ticket", ticket);
        ES3.Save("ticketGet", ticketGet);
        ES3.Save("currentStamina", currentStamina);
        ES3.Save("stageOpen", stageOpen);
        ES3.Save("stageOpen2", stageOpen2);
        ES3.Save("stageOpen3", stageOpen3);

        Debug.Log("currentStamina: " + currentStamina + "をセーブ");
        Debug.Log("stageOpen: " + stageOpen + "をセーブ");
    }

    private void LoadData()
    {
        // 変数や配列のロード
        reward = ES3.Load<int>("reward");
        clearNum = ES3.Load<int>("clearNum");
        advirtuaClear = ES3.Load<int>("advirtuaClear");
        clearEasyStageNum = ES3.Load<int[]>("clearEasyStageNum");
        clearNormalStageNum = ES3.Load<int[]>("clearNormalStageNum");
        clearHardStageNum = ES3.Load<int[]>("clearHardStageNum");
        clearBossStageNum = ES3.Load<int[]>("clearBossStageNum");
        totalScore = ES3.Load<int>("totalScore");
        item = ES3.Load<int[]>("item");
        item2 = ES3.Load<int[]>("item2");
        ticket = ES3.Load<int>("ticket");
        ticketGet = ES3.Load<int>("ticketGet");
        currentStamina = ES3.Load<int>("currentStamina");
        stageOpen = ES3.Load<int>("stageOpen");
        stageOpen2 = ES3.Load<int>("stageOpen2");
        stageOpen3 = ES3.Load<int>("stageOpen3");

        Debug.Log("currentStamina: " + currentStamina + "をロード");
        Debug.Log("stageOpen: " + stageOpen + "をロード");
    }

}
