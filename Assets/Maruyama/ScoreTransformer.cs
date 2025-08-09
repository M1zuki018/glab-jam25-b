using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTransformer : MonoBehaviour
{
    [Header("•ÏŠ·”{—¦(‰ñ”¨KM)")]
    [SerializeField] float _scale;

    private void Start()
    {
        //var debugCount = 30;
        //var distance = GetScore(debugCount);
        //Debug.Log("SCORE " + distance + " KM");
    }

    public float GetScore(float count)
    {
        return count * _scale;
    }
}