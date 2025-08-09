using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField][Header("タイマー終了後の処理")] private UnityEvent _event;
    [SerializeField]  TextMeshProUGUI timerText;
    private float _count = 15f;
    private bool _timeActive = false;


    public void TimeStart(int count)
    {
        _count = count;
        _timeActive = true;
    }

    private void Update()
    {
        if (_timeActive)
        {
            _count -= Time.deltaTime;
            int displayTime = Mathf.FloorToInt(_count);
            timerText.text = displayTime.ToString();

            if (_count <= 0)
            {
                //Debug.Log("Stop");
                _timeActive = false;
                _event?.Invoke();
            }
        }
    }
    public void TimerStop()
    {
        _timeActive = false;
        _count = 0f;
    }
}