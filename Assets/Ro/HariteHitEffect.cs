using UnityEngine;

public class HariteHitEffect : MonoBehaviour
{
    [SerializeField, Header("表示時間（秒）")]
    private float showTime = 0.05f;


    public void PlayAt(Vector3 worldPos)
    {
        transform.position = worldPos;
        gameObject.SetActive(false);  // 再表示のために一旦OFF
        gameObject.SetActive(true);   // このフレームで表示
        CancelInvoke();
        Invoke(nameof(Hide), showTime);
    }

    private void Hide() => gameObject.SetActive(false);
}