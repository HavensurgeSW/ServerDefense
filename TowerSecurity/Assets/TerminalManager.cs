using System.Collections;
using System.Collections.Generic;
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

    private void OnGUI()
    {
        if (terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return)) {
            //Store user input && clear the line
            string userInput = terminalInput.text;
            ClearInputField();
            AddDirectoryLine(userInput);
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
        //resizing CMDline container for the scrollrect to stay based.
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);

        GameObject msg = Instantiate(directoryLine, msgList.transform);
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);

        msg.GetComponentsInChildren <TMP_Text>()[1].text = userInput;

    }
}
