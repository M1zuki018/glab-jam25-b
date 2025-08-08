using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTransformer : MonoBehaviour
{
    [SerializeField] float _scale;
    public float _count; // 受け取る変数
    float _distance; // 結果用の箱
    /// <summary>
    /// scoreTransformer._count = 作ってもらった変数;　このセットはどっちのコードでも行けるように
    /// </summary>

    private void Start()
    {
        _distance = _count * _scale;
        Debug.Log("SCORE" + _distance + " KM");
    }
}