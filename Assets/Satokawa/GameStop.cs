using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class GameStop : MonoBehaviour
{
    [SerializeField, Header("‚â‚ß‚ÌUI")]
    private GameObject stopUI;
    [SerializeField, Header("‚â‚ß‚ÌŒã‚Ìˆ—")]
    private UnityEvent stopEvent;
    [SerializeField, Header("•\Ž¦ŽžŠÔ")]
    private float viewTime;
    // Start is called before the first frame update
    void Start()
    {
        stopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Active()
    {
        stopUI.SetActive(true);
        DOVirtual.DelayedCall(viewTime,() => stopEvent.Invoke());
    }
}
