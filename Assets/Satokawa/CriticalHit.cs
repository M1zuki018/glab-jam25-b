using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CriticalHit : MonoBehaviour
{
    [SerializeField, Header("クリティカルヒットの演出")]
    private GameObject criticalhit;
    [SerializeField, Header("空振りの演出")]
    private GameObject strikeout;
    // Start is called before the first frame update
    void Start()
    {
        criticalhit.SetActive(false);
        strikeout.SetActive(false);
        criticalhit.GetComponent<SpriteRenderer>().DOFade(1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitEffect(bool isHit)
    {
        GameObject effectObj = null;
        if (isHit)
        {
            effectObj = criticalhit;
        }
        else
        {
            effectObj = strikeout;
        }
        effectObj.SetActive(true);
        Vector3 scale =  effectObj.transform.localScale;
        effectObj.transform.localScale /= 1.5f;
        effectObj.transform.DOScale(scale, 0.2f).SetEase(Ease.OutBounce).SetDelay(0.1f)
            .OnComplete(() => criticalhit.GetComponent<SpriteRenderer>().DOFade(0f, 1f).SetDelay(0.5f));


    }
}
