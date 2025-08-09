using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] GameObject obj;
    [Header("吹っ飛ぶか吹っ飛ばないかの単位")]
    [SerializeField] int toFly;
    [SerializeField] int notFlying;

    [Header("UIオブジェクト")]
    [SerializeField] GameObject resultObject;
    [Header("距離テキスト")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("矢印")]
    [SerializeField] Image arrow;

    [Header("ハイスコアポジション")]
    [SerializeField] Transform[] pos;

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
                arrow.transform.DOMove(pos[i].position, 1f).SetEase(Ease.OutBounce);

                Sequence sequence = DOTween.Sequence();
                sequence.Append(
                    showRankingImage.transform.DOScale(new Vector3(reduction_x, reduction_y, 0), time).SetEase(Ease.InQuint)
                    );
                sequence.Append(
                    showRankingImage.transform.DOScale(new Vector3(expansion_x, expansion_y, 0), time).SetEase(Ease.OutQuint)
                    );
                
                var count = obj.GetComponent<KeyInputCounter>().TotalCount;
                if(count >= toFly)
                {
                    float dis = 0;
                    for(int c = 0; c < count; c++)
                    {
                        dis += 3.9373f;
                    }

                    scoreText.text = $"{count} 里" + $"{dis} KM";
                    Debug.Log("距離");
                }
                else if(count >= notFlying)
                {
                    float dis = 0;
                    for (int c = 0; c < count; c++)
                    {
                        dis += 0.30303f;
                    }

                    scoreText.text = $"{count} 尺" + $"{dis} M";
                    Debug.Log("距離");
                }
                else
                {
                    scoreText.text = $"{count} 寸";
                    Debug.Log("距離");
                }

                isJudgment = true;

                //番付表示
                showRankingImage.sprite = rankingImages[i];
                Debug.Log("番付表示");
            }
        }
    }
}
