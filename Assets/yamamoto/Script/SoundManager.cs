using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("SEリスト")]
    [SerializeField] List<AudioClip> clipList;

    [Header("BGMリスト")]
    [SerializeField] List<AudioClip> bgmList;

    private AudioSource audioSource;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundPlay(string soundName)
    {
        switch (soundName)
        {
            case "張り手_強":
                audioSource.PlayOneShot(clipList[0]);
                break;

            case "張り手_弱":
                audioSource.PlayOneShot(clipList[1]);
                break;

            case "ぶっ飛ぶ":
                audioSource.PlayOneShot(clipList[2]);
                break;

            case "選択":
                audioSource.PlayOneShot(clipList[3]);
                break;

            case "勝利":
                audioSource.PlayOneShot(clipList[4]);
                break;

            case "敗北":
                audioSource.PlayOneShot(clipList[4]);
                break;
        }
    }

    public void BGMPlay(string bgmName)
    {
        switch (bgmName)
        {
            case "タイトル":
                audioSource.clip = bgmList[0];
                audioSource.Play();
                break;

            case "インゲーム":
                audioSource.clip = bgmList[1];
                audioSource.Play();
                break;
        }
    }

    public void BGMStop()
    {
        audioSource.Stop();
    }
}
