using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �摜�̕\���ؑւ����邽�߂̃N���X
/// </summary>
public class ImageDisplay : MonoBehaviour
{
    //[SerializeField] private GameObject _ImageUI;
    /// <summary>
    /// �摜��\������
    /// </summary>
    public void LoadImage(GameObject Image)
    {
        Image.SetActive(true);
    }
    /// <summary>
    /// �摜���\���ɂ���
    /// </summary>
    public  void HideImage(GameObject Image)
    {
        Image.SetActive(false);
    }
    public void Start()
    {

    }
}
