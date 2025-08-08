using System;
using UnityEngine;
using UnityEngine.Events;

class TImer : MonoBehaviour
{
    [SerializeField]UnityEvent _event;
    [SerializeField] private float _count = 15f;
    [SerializeField] private bool _timeActiv = false;


     void TimeStar()
    {
        _timeActiv = true;
    }

    private void Update()
    {
        if (_timeActiv)
        {
            _count -= Time.deltaTime;
            if (_count <= 0)
            {
                _timeActiv=false;
                _event?.Invoke();
            }
        }
    }
}
