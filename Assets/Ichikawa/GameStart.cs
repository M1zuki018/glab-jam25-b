using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStart : MonoBehaviour
{
    // ������UI�p�l����Inspector�Őݒ�ł���悤�ɁAGameObject�̃��X�g���g�p
    public List<GameObject> _uiPanels;
    [SerializeField] float _displayTime = 3.0f;
    [SerializeField] UnityEvent _gameStart;

    void Start()
    {
        // UI�p�l���̃��X�g���ݒ肳��Ă��邩�m�F
        if (_uiPanels == null || _uiPanels.Count == 0)
        {
            Debug.LogWarning("UI�p�l�����ݒ肳��Ă��܂���I");
            return;
        }

        // �S�Ă�UI�p�l����\��
        foreach (GameObject panel in _uiPanels)
        {
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }

        // �w�莞�Ԍ�ɑS�Ă�UI�p�l�����\���ɂ���R���[�`�����J�n
        StartCoroutine(HideAllUIPanels());
    }

    IEnumerator HideAllUIPanels()
    {
        // displayTime�b�҂�
        yield return new WaitForSeconds(_displayTime);

        // �ҋ@��A�S�Ă�UI�p�l�����\���ɂ���
        foreach (GameObject panel in _uiPanels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }

        // �S�Ă�UI�p�l���̔�\������������������ɃC�x���g���Ăяo��
        _gameStart.Invoke();
    }
}