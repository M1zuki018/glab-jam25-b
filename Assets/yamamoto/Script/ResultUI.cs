using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [Header("�Q��")]
    [SerializeField] GameObject obj;
    [Header("������Ԃ�������΂Ȃ����̒P��")]
    [SerializeField] int toFly;
    [SerializeField] int notFlying;

    [Header("UI�I�u�W�F�N�g")]
    [SerializeField] GameObject resultObject;
    [Header("�����e�L�X�g")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("���")]
    [SerializeField] Image arrow;

    [Header("�n�C�X�R�A�|�W�V����")]
    [SerializeField] Transform[] pos;

    [Header("�����ɉ���������̒l")]
    [SerializeField] int[] judgment;

    [Header("�ԕt")]
    [SerializeField] Sprite[] rankingImages;
    [SerializeField] Image showRankingImage;

    [Header("UI�A�j���[�V�����̏ڍ�")]
    [Header("�k��")]
    [SerializeField] float reduction_x;
    [SerializeField] float reduction_y;

    [Header("�g��䗦")] 
    [SerializeField] float expansion_x;
    [SerializeField] float expansion_y;

    [Header("�A�j���[�V��������")] [SerializeField]float time;

    private bool isJudgment;

    // Start is called before the first frame update
    void Start()
    {
        resultObject.SetActive(false);
    }
    public void ScoreView(float score)
    {
        resultObject.SetActive(true);
        //�����ɉ������ԕt�̔���
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

                    scoreText.text = $"{count} ��" + $"{dis} KM";
                    Debug.Log("����");
                }
                else if(count >= notFlying)
                {
                    float dis = 0;
                    for (int c = 0; c < count; c++)
                    {
                        dis += 0.30303f;
                    }

                    scoreText.text = $"{count} ��" + $"{dis} M";
                    Debug.Log("����");
                }
                else
                {
                    scoreText.text = $"{count} ��";
                    Debug.Log("����");
                }

                isJudgment = true;

                //�ԕt�\��
                showRankingImage.sprite = rankingImages[i];
                Debug.Log("�ԕt�\��");
            }
        }
    }
}
