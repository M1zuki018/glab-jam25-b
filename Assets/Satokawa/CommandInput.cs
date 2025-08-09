using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CommandInput : MonoBehaviour
{
    [SerializeField, Header("�R�}���h�\���pText")]
    private TextMeshProUGUI commandText;
    [SerializeField, Header("Enter�L�[Image")]
    private Image enterImage;

    private string command;
    private bool _isCommandInput;
    public bool isCommandInput => _isCommandInput;
    private int textIndex = 0;
    private bool isActive = false;
    public int TextIndex => textIndex;
    // Start is called before the first frame update
    void Start()
    {
        commandText.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            
            if (textIndex >= command.Length && Input.GetKey(KeyCode.Return))
            {
                isActive = false;
                _isCommandInput = true;
                enterImage.color = Color.gray;
                FindAnyObjectByType<GameManager>().InputStop(true);
            }
            else if(textIndex < command.Length)
            {
                KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), command[textIndex].ToString());
                if (Input.GetKeyDown(key))
                {
                    textIndex++;
                    ApplySplitColor();
                }
            }
        }
        commandText.gameObject.SetActive(isActive);
        enterImage.gameObject.SetActive(isActive);
    }
    public void RandomCommand(int length = 4)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < length; i++)
        {
            sb.Append((char)Random.Range('A', 'Z' + 1));
        }
        command = sb.ToString();

        commandText.text = command;
        enterImage.color = Color.white;
        _isCommandInput = false;
    }
    public void CommandActive()
    {
        isActive = true;
    }
    public void ApplySplitColor()
    {
        // ���b�V�������ŐV��
        commandText.ForceMeshUpdate();

        TMP_TextInfo textInfo = commandText.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible) continue;

            // �����̒��_�C���f�b�N�X
            int meshIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            Color32[] vertexColors = textInfo.meshInfo[meshIndex].colors32;

            // splitIndex�����͑O���F�A����ȍ~�͌㔼�F
            Color32 c = (i < textIndex) ? Color.gray : Color.white;

            vertexColors[vertexIndex + 0] = c;
            vertexColors[vertexIndex + 1] = c;
            vertexColors[vertexIndex + 2] = c;
            vertexColors[vertexIndex + 3] = c;
        }

        // �ύX�𔽉f
        commandText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
}