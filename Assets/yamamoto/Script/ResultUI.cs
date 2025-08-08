using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [Header("番付テキスト")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("矢印")]
    [SerializeField] Image arrow;

    [Header("ハイスコアポジション")]
    [SerializeField] Transform[] pos;

    [Header("距離に応じた判定の値")]
    [SerializeField] int[] judgment;

    [Header("番付")]
    [SerializeField] string[] rankingName;

    [Header("UIアニメーションの詳細")]
    [Header("縮小")] [SerializeField]float reduction;
    [Header("拡大")] [SerializeField]float expansion;
    [Header("アニメーション時間")] [SerializeField]float time;

    public int score;

    private bool isJudgment;

    // Start is called before the first frame update
    void Start()
    {
        //距離に応じた番付の判定
        for(int i = 0; i < judgment.Length; i++)
        {
            if(score >= judgment[i] && !isJudgment)
            {
                arrow.transform.DOMove(new Vector3(pos[i].position.x, pos[i].position.y, pos[i].position.z), 1f).SetEase(Ease.OutBounce);

                Sequence sequence = DOTween.Sequence();
                sequence.Append(
                    scoreText.transform.DOScale(new Vector3(reduction, reduction, reduction), time).SetEase(Ease.InQuint)
                    );
                sequence.Append(
                    scoreText.transform.DOScale(new Vector3(expansion, expansion, expansion), time).SetEase (Ease.OutQuint)
                    );
                scoreText.text = rankingName[i];

                isJudgment = true;
            }
        }
    }
}
