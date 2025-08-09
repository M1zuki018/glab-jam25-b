using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画像の表示切替をするためのクラス
/// </summary>
public class ImageDisplay : MonoBehaviour
{
    //[SerializeField] private GameObject _ImageUI;
    /// <summary>
    /// 画像を表示する
    /// </summary>
    public void LoadImage(GameObject Image)
    {
        Image.SetActive(true);
    }
    /// <summary>
    /// 画像を非表示にする
    /// </summary>
    public  void HideImage(GameObject Image)
    {
        Image.SetActive(false);
    }
    public void Start()
    {

    }
}
