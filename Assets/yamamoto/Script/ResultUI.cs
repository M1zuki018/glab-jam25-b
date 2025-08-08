using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [Header("スコアテキスト")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("評価")]
    [SerializeField] TextMeshProUGUI evaluationText;

    private int score;
    private string evaluation;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Score  :  {score}";

        //評価基準の処理か評価された値をテキストに入れる
        evaluationText.text = $"{evaluation}";
    }
}
