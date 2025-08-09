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
    [Header("SE���X�g")]
    [SerializeField] List<soundClip> seList;

    [Header("BGM���X�g")]
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
        Debug.LogError("SoundSE �Ȃ�");
        //switch (soundName)
        //{
        //    case "�����_��":
        //        audioSource.PlayOneShot(clipList[0]);
        //        break;

        //    case "�����_��":
        //        audioSource.PlayOneShot(clipList[1]);
        //        break;

        //    case "�Ԃ����":
        //        audioSource.PlayOneShot(clipList[2]);
        //        break;

        //    case "�I��":
        //        audioSource.PlayOneShot(clipList[3]);
        //        break;

        //    case "����":
        //        audioSource.PlayOneShot(clipList[4]);
        //        break;

        //    case "�s�k":
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
        Debug.LogError("SoundBGM �Ȃ�");
        //switch (bgmName)
        //{
        //    case "�^�C�g��":
        //        audioSource.clip = bgmList[0];
        //        audioSource.Play();
        //        break;

        //    case "�C���Q�[��":
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
