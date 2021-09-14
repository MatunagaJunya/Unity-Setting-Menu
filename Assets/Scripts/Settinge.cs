using UnityEngine;
using UnityEngine.UI;

public class Settinge : MonoBehaviour
{
    /// <summary>
    /// データが入っているクラス
    /// </summary>
    private Settinge_Data Data;
    /// <summary>
    /// データのパラメータークラス
    /// </summary>
    private Settinge_Parameter Parameter;

    /// <summary>
    /// 主音量
    /// </summary>
    [SerializeField, Header("主音量")]
    private int MainVolume = 10;
    /// <summary>
    /// BGMの音量
    /// </summary>
    [SerializeField, Header("BGMの音量")]
    private int BGMVolume = 10;
    /// <summary>
    /// SEの音量
    /// </summary>
    [SerializeField, Header("SEの音量")]
    private int SEVolume = 10;

    /// <summary>
    /// 画面解像度
    /// </summary>
    [SerializeField,Header("画面解像度")]
    private Vector2[] ScreenSize;
    private bool Screen;
    private bool FPS;

    private void Awake()
    {
        Data = GameObject.Find("GameSettinge").GetComponent<Settinge_Data>();
        Parameter = GameObject.Find("GameSettinge").GetComponent<Settinge_Parameter>();
    }


}
