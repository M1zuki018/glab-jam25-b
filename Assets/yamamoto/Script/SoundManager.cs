using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("SE���X�g")]
    [SerializeField] List<AudioClip> clipList;

    [Header("BGM���X�g")]
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
            case "�����_��":
                audioSource.PlayOneShot(clipList[0]);
                break;

            case "�����_��":
                audioSource.PlayOneShot(clipList[1]);
                break;

            case "�Ԃ����":
                audioSource.PlayOneShot(clipList[2]);
                break;

            case "�I��":
                audioSource.PlayOneShot(clipList[3]);
                break;

            case "����":
                audioSource.PlayOneShot(clipList[4]);
                break;

            case "�s�k":
                audioSource.PlayOneShot(clipList[4]);
                break;
        }
    }

    public void BGMPlay(string bgmName)
    {
        switch (bgmName)
        {
            case "�^�C�g��":
                audioSource.clip = bgmList[0];
                audioSource.Play();
                break;

            case "�C���Q�[��":
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
