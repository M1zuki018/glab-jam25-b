using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    public float fadeTime;
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        Color imageColor = Color.black;
        imageColor.a = 0f;
        fadeImage.color = imageColor;
        fadeImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneMoveLoad("InGame");
        } 
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
