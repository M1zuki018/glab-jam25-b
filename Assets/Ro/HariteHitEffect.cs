using UnityEngine;

public class HariteHitEffect : MonoBehaviour
{
    [SerializeField, Header("�\�����ԁi�b�j")]
    private float showTime = 0.05f;


    public void PlayAt(Vector3 worldPos)
    {
        transform.position = worldPos;
        gameObject.SetActive(false);  // �ĕ\���̂��߂Ɉ�UOFF
        gameObject.SetActive(true);   // ���̃t���[���ŕ\��
        CancelInvoke();
        Invoke(nameof(Hide), showTime);
    }

    private void Hide() => gameObject.SetActive(false);
}