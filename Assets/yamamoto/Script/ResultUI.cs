using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [Header("UIオブジェクト")]
    [SerializeField] GameObject resultObject;
    [Header("番付テキスト")]
    [SerializeField] TextMeshProUGUI rankingNameText;
    [Header("距離テキスト")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("矢印")]
    [SerializeField] Image arrow;

    [Header("ハイスコアポジション")]
    [SerializeField] float[] posY;
    [SerializeField] float posX;

    [Header("距離に応じた判定の値")]
    [SerializeField] int[] judgment;

    [Header("番付")]
    [SerializeField] Sprite[] rankingImages;
    [SerializeField] Image showRankingImage;

    [Header("UIアニメーションの詳細")]
    [Header("縮小")]
    [SerializeField] float reduction_x;
    [SerializeField] float reduction_y;

    [Header("拡大比率")] 
    [SerializeField] float expansion_x;
    [SerializeField] float expansion_y;

    [Header("アニメーション時間")] [SerializeField]float time;

    private bool isJudgment;

    // Start is called before the first frame update
    void Start()
    {
        resultObject.SetActive(false);
    }
    public void ScoreView(float score)
    {
        resultObject.SetActive(true);
        //距離に応じた番付の判定
        for (int i = 0; i < judgment.Length; i++)
        {
            if (score >= judgment[i]&& !isJudgment)
            {
                arrow.transform.DOMoveY(posY[i],1f).SetEase(Ease.OutBounce);

                Sequence sequence = DOTween.Sequence();
                sequence.Append(
                    showRankingImage.transform.DOScale(new Vector3(reduction_x, reduction_y, 0), time).SetEase(Ease.InQuint)
                    );
                sequence.Append(
                    showRankingImage.transform.DOScale(new Vector3(expansion_x, expansion_y, 0), time).SetEase(Ease.OutQuint)
                    );
                scoreText.text = score + "km";
                isJudgment = true;

                //番付表示
                showRankingImage.sprite = rankingImages[i];
                Debug.Log("番付表示");
            }
        }
    }
}
