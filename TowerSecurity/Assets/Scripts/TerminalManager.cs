using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerminalManager : MonoBehaviour
{

    public GameObject directoryLine;
    public GameObject responseLine;

    public TMP_InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;

    //private Func<string, List<string>> OnInputCommand;
    private Action<string> OnInputCommand;

    public void Init(Action<string> a)
    {
        terminalInput.ActivateInputField();
        terminalInput.Select();
        OnInputCommand = a;
    }
  

    private void OnGUI()
    {
        if (terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return)) {
            //Store user input && clear the line
            string userInput = terminalInput.text;
            ClearInputField();
            AddDirectoryLine(userInput);
            OnInputCommand(userInput);
            userInputLine.transform.SetAsLastSibling();

            //refocus input field
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    void ClearInputField() {
        terminalInput.text = "";
    }

    void AddDirectoryLine(string userInput) {

        GameObject msg = Instantiate(directoryLine, msgList.transform);
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);

        msg.GetComponentsInChildren<TMP_Text>()[1].text = userInput;

    }

    public void AddInterpreterLines(List<string> interpretation) {
        for (int i = 0; i < interpretation.Count; i++)
        {
            GameObject res = Instantiate(responseLine, msgList.transform);
            res.transform.SetAsLastSibling();

            Vector2 listSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y + 35.0f);

            res.GetComponentInChildren<TMP_Text>().text = interpretation[i];
        }

        ScrollToBottom(interpretation.Count);
    }

    void ScrollToBottom(int lines) {
        if (lines > 4)
        {
            sr.velocity = new Vector2(0, 450);
        }
        else {
            sr.verticalNormalizedPosition = 0;
        }
    }

   
}
