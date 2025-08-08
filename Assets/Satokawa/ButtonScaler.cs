using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening; // �� �Y�ꂸ��

public class ButtonScalerTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float scaleUp = 1.1f;       // �g��{��
    private float duration = 0.2f;      // �A�j���[�V�����̎���

    private Vector3 originalScale;
    private Tween currentTween;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ������Tween������Ύ~�߂�
        currentTween?.Kill();

        // �g��Tween
        currentTween = transform.DOScale(originalScale * scaleUp, duration).SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // �k��Tween
        currentTween?.Kill();

        currentTween = transform.DOScale(originalScale, duration).SetEase(Ease.OutBack);
    }
}
