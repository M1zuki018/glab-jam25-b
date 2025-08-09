using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("参照")]
    private Timer timer;
    [SerializeField]
    private KeyInputCounter counter;
    [SerializeField]
    private ScoreTransformer scoreTransformer;
    [SerializeField]
    private CharacterImpulse characterImpulse;
    [SerializeField]
    private CommandInput commandInput;
    [SerializeField]
    private ResultUI resultUI;

    [SerializeField, Header("キー入力時間")]
    private int keyTime;
    [SerializeField, Header("サウンドPrefab")]
    private GameObject soundObject;
    private bool isKey;
    // Start is called before the first frame update
    void Start()
    {
        counter.enabled = false;
        isKey = false;
#if UNITY_EDITOR
        if (FindAnyObjectByType<SoundManager>() == null)
        {
            Instantiate(soundObject);
        }
#endif
        FindAnyObjectByType<SoundManager>().BGMPlay("インゲーム");
    }

    // Update is called once per frame
    void Update()
    {
        if (isKey)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                counter.enabled = false;
                counter.ScaleReset();
                commandInput.CommandActive();
                isKey = false;
            }
        }
    }
    public void StartInputKey()
    {
        timer.TimeStart(keyTime);
        counter.enabled = true;
        counter.ResetCount();
        commandInput.enabled = true;
        commandInput.RandomCommand();
        commandInput.ApplySplitColor();
        isKey = true;
    }
    public void InputStop(bool isCommand)
    {
        timer.TimerStop();
        FindAnyObjectByType<GameStop>();
        counter.ScaleReset();
        counter.enabled = false;
        counter.Push();
        isKey = false;
        commandInput.enabled = false;
        if (!isCommand)
        {
            counter.TimeUp();
        }
        characterImpulse.SmouMove(counter.TotalCount, isCommand);
    }
    public void result()
    {
        float score = scoreTransformer.GetScore(counter.TotalCount);
        DOVirtual.DelayedCall(1, () => resultUI.ScoreView(score));
    }
}