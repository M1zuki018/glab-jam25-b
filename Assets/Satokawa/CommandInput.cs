using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CommandInput : MonoBehaviour
{

    public string command;
    public bool _isCommandInput;
    public bool isCommandInput
    {
        get;
        private set;
    }
    public TextMeshProUGUI commandText;
    private int textIndex;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        RandomCommand();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), command[textIndex].ToString());
            if(Input.GetKeyDown(key))
            {
                textIndex++;
            }
            if(textIndex >= command.Length)
            {
                isActive = false;
                isCommandInput = true;
            }
        }
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
        isCommandInput = false;
        isActive = true;
    }

}
