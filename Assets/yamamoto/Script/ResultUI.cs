using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [Header("�X�R�A�e�L�X�g")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("�]��")]
    [SerializeField] TextMeshProUGUI evaluationText;

    private int score;
    private string evaluation;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Score  :  {score}";

        //�]����̏������]�����ꂽ�l���e�L�X�g�ɓ����
        evaluationText.text = $"{evaluation}";
    }
}
