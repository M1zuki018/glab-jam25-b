using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [Header("UI�I�u�W�F�N�g")]
    [SerializeField] GameObject resultObject;
    [Header("�ԕt�e�L�X�g")]
    [SerializeField] TextMeshProUGUI rankingNameText;
    [Header("�����e�L�X�g")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("���")]
    [SerializeField] Image arrow;

    [Header("�n�C�X�R�A�|�W�V����")]
    [SerializeField] float[] posY;
    [SerializeField] float posX;

    [Header("�����ɉ���������̒l")]
    [SerializeField] int[] judgment;

    [Header("�ԕt")]
    [SerializeField] string[] rankingName;

    [Header("UI�A�j���[�V�����̏ڍ�")]
    [Header("�k��")] [SerializeField]float reduction;
    [Header("�g��")] [SerializeField]float expansion;
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
                arrow.transform.DOMoveY(posY[i],1f).SetEase(Ease.OutBounce);

                Sequence sequence = DOTween.Sequence();
                sequence.Append(
                    rankingNameText.transform.DOScale(new Vector3(reduction, reduction, reduction), time).SetEase(Ease.InQuint)
                    );
                sequence.Append(
                    rankingNameText.transform.DOScale(new Vector3(expansion, expansion, expansion), time).SetEase(Ease.OutQuint)
                    );
                rankingNameText.text = rankingName[i];
                scoreText.text = score + "km";
                isJudgment = true;
            }
        }
    }
}
