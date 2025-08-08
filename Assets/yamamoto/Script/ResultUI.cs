using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [Header("�ԕt�e�L�X�g")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("���")]
    [SerializeField] Image arrow;

    [Header("�n�C�X�R�A�|�W�V����")]
    [SerializeField] Transform[] pos;

    [Header("�����ɉ���������̒l")]
    [SerializeField] int[] judgment;

    [Header("�ԕt")]
    [SerializeField] string[] rankingName;

    [Header("UI�A�j���[�V�����̏ڍ�")]
    [Header("�k��")] [SerializeField]float reduction;
    [Header("�g��")] [SerializeField]float expansion;
    [Header("�A�j���[�V��������")] [SerializeField]float time;

    public int score;

    private bool isJudgment;

    // Start is called before the first frame update
    void Start()
    {
        //�����ɉ������ԕt�̔���
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
