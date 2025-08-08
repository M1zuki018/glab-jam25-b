using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTransformer : MonoBehaviour
{
    [SerializeField] float _scale;
    public float _count; // �󂯎��ϐ�
    float _distance; // ���ʗp�̔�
    /// <summary>
    /// scoreTransformer._count = ����Ă�������ϐ�;�@���̃Z�b�g�͂ǂ����̃R�[�h�ł��s����悤��
    /// </summary>

    private void Start()
    {
        _distance = _count * _scale;
        Debug.Log("SCORE" + _distance + " KM");
    }
}