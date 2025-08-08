using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // 複数のUIパネルをInspectorで設定できるように、GameObjectのリストを使用
    public List<GameObject> _uiPanels;
    [SerializeField] float _displayTime = 3.0f;

    void Start()
    {
        // UIパネルのリストが設定されているか確認
        if (_uiPanels == null || _uiPanels.Count == 0)
        {
            Debug.LogWarning("UIパネルが設定されていません！");
            return;
        }

        // 全てのUIパネルを表示
        foreach (GameObject panel in _uiPanels)
        {
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }

        // 指定時間後に全てのUIパネルを非表示にするコルーチンを開始
        StartCoroutine(HideAllUIPanels());
    }

    IEnumerator HideAllUIPanels()
    {
        // displayTime秒待つ
        yield return new WaitForSeconds(_displayTime);

        // 待機後、全てのUIパネルを非表示にする
        foreach (GameObject panel in _uiPanels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}