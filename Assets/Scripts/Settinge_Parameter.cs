using UnityEngine;
using System;
using System.IO;

[SerializeField]
public class Settinge_Data
{
    /// <summary>
    /// 主音量
    /// </summary>
    public float MainVolume;
    /// <summary>
    /// BGMの音量
    /// </summary>
    public float BGMVolume;
    /// <summary>
    /// SEの音量
    /// </summary>
    public float SEVolume;

    /// <summary>
    /// スクリーンサイズx軸
    /// </summary>
    public float ScreenSize_x;
    /// <summary>
    /// スクリーンサイズy軸
    /// </summary>
    public float ScreenSize_y;
    /// <summary>
    /// フルスクリーンなどを指定
    /// </summary>
    public bool Screen;
    /// <summary>
    /// フレームレート
    /// </summary>
    public int FPS;
}

public class Settinge_Parameter : MonoBehaviour
{
    /// <summary>
    /// 設定のパラメーター
    /// </summary>
    [SerializeField, Header("設定のパラメーター")]
    private Settinge_Data Data;

    /// <summary>
    /// データのパス
    /// </summary>
    private string SaveFilePath = "Assets/Resources/Settinge_Data.json";

    /// <summary>
    /// スクリーンサイズ
    /// </summary>
    private Vector2 ScreenSize;

    private void Awake()
    {
        //データを呼出
        using (var fs = new StreamReader(SaveFilePath, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            string result = fs.ReadToEnd();
            Debug.Log(result);
            Data = JsonUtility.FromJson<Settinge_Data>(result);
        }
    }

    private void Start()
    {
        //スクリーンのサイズの値を渡す
        ScreenSize = new Vector2(Data.ScreenSize_x, Data.ScreenSize_y);

        //スクリーンの解像度、スクリーン設定、フレームレートの指定
        Screen.SetResolution((int)ScreenSize.x, (int)ScreenSize.y, Data.Screen, Data.FPS);
    }

    /// <summary>
    /// 設定の保存
    /// </summary>
    public void Data_Save()
    {
        string json = JsonUtility.ToJson(Data);

        //Json書き込み
        StreamWriter SW = new StreamWriter(SaveFilePath);
        SW.Write(json);
        SW.Flush();
        SW.Close();
    }
}
