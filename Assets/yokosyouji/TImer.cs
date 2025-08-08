using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]UnityEvent _event;
    [SerializeField] private float _count = 15f;
    [SerializeField] private bool _timeActiv = false;


    public void TimeStart(int count)
    {
        _count = count;
        _timeActiv = true;
    }

    private void Update()
    {
        if (_timeActiv)
        {
            _count -= Time.deltaTime;
            if (_count <= 0)
            {
                Debug.Log("Stop");
                _timeActiv=false;
                _event?.Invoke();
            }
        }
    }
}
