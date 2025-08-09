using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    [SerializeField, Header("�t�F�[�h����")]
    public float fadeTime;
    [SerializeField, Header("�t�F�[�h�pImage �t���X�N���[���̂���")]
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        Color imageColor = Color.black;
        imageColor.a = 0f;
        fadeImage.color = imageColor;
        fadeImage.gameObject.SetActive(false);
    }
    
    public void SceneMoveLoad(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        Color imageColor = Color.black;
        imageColor.a = 0f;
        fadeImage .color = imageColor;  
        fadeImage.DOFade(1f, fadeTime).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
