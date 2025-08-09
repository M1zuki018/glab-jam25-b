using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [System.Serializable]
    public class soundClip
    {
        public AudioClip clip;
        public string soundName;
    }
    [Header("SEリスト")]
    [SerializeField] List<soundClip> seList;

    [Header("BGMリスト")]
    [SerializeField] List<soundClip> bgmList;
    private AudioSource audioSource;

    void Start()
    {
       

    }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
        audioSource = GetComponent<AudioSource>();
        BGMStop();

    }

    public void SoundPlay(string soundName)
    {
        //Debug.Log(soundName);
        foreach(soundClip clip in seList)
        {
            if(clip.soundName == soundName)
            {
                audioSource.PlayOneShot(clip.clip);
                return;
            }
        }
        Debug.LogError("SoundSE ない");
        //switch (soundName)
        //{
        //    case "張り手_強":
        //        audioSource.PlayOneShot(clipList[0]);
        //        break;

        //    case "張り手_弱":
        //        audioSource.PlayOneShot(clipList[1]);
        //        break;

        //    case "ぶっ飛ぶ":
        //        audioSource.PlayOneShot(clipList[2]);
        //        break;

        //    case "選択":
        //        audioSource.PlayOneShot(clipList[3]);
        //        break;

        //    case "勝利":
        //        audioSource.PlayOneShot(clipList[4]);
        //        break;

        //    case "敗北":
        //        audioSource.PlayOneShot(clipList[4]);
        //        break;
        //}
    }

    public void BGMPlay(string bgmName)
    {
        BGMStop();
        foreach (soundClip clip in bgmList)
        {
            if (clip.soundName == bgmName)
            {
                audioSource.clip = clip.clip;
                //audioSource.Stop();
                audioSource.Play();
                return;
            }
       }
        Debug.LogError("SoundBGM ない");
        //switch (bgmName)
        //{
        //    case "タイトル":
        //        audioSource.clip = bgmList[0];
        //        audioSource.Play();
        //        break;

        //    case "インゲーム":
        //        audioSource.clip = bgmList[1];
        //        audioSource.Play();
        //        break;
        //}
    }

    public void BGMStop()
    {
        audioSource.Stop();
    }
}
