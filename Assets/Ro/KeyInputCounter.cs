using UnityEngine;
using UnityEngine.Events;

public class KeyInputCounter : MonoBehaviour
{
    [Header("左手4キー")]
    // 左手側の入力として使うキー（4つ全て同時押しで1ステップ扱い）
    [SerializeField] private KeyCode[] leftKeys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };
    
    [Header("右手4キー")]

    [SerializeField] private KeyCode[] rightKeys = { KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon };


    [Header("カウント結果")]
    // 現在の累計カウント
    [SerializeField] private int totalCount;

    public int TotalCount => totalCount;


    // どちらの側で最後にカウントしたかを示す列挙型
    private enum Side { None, Left, Right }
    private Side lastSide = Side.None; // 前回カウントした側（交互判定用）

    // 前フレームで4つ全押しされていたかどうか
    private bool prevLeftAll, prevRightAll;

    void Update()
    {
        // --- 現在の全押し状態を取得 ---
        bool leftAll = AllHeld(leftKeys);     
        bool rightAll = AllHeld(rightKeys);   

    
        // 「押されていなかった」→「全押しになった」瞬間だけ判定する
        if (leftAll && !prevLeftAll) CountIfAlternate(Side.Left);
        if (rightAll && !prevRightAll) CountIfAlternate(Side.Right);

        // --- このフレームの状態を保存（次フレームの比較用） ---
        prevLeftAll = leftAll;
        prevRightAll = rightAll;
    }

    // 指定されたキー配列が全て押されているかを判定
    bool AllHeld(KeyCode[] keys)
    {
        foreach (var k in keys)
            if (!Input.GetKey(k)) return false; // 1つでも押されていないキーがあればfalse
        return true; // 全て押されている場合true
    }

    // 前回と異なる側ならカウントする（交互押しルール）
    void CountIfAlternate(Side current)
    {
        if (current == lastSide) return; // 同じ側が連続した場合は無効
        lastSide = current;              // 今回の側を記録
        totalCount++;                    // カウントを加算
       
    }

    // カウントと状態をリセット
    public void ResetCount()
    {
        totalCount = 0;                         // カウントを0に
        lastSide = Side.None;                   // 最後に押した側情報を初期化
        prevLeftAll = prevRightAll = false;     // 押下状態履歴を初期化
    }
}