using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;

public class TerminalManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject logPrefab;

    [Header("Required components")]
    public GameObject console;
    public TMP_InputField terminalInput;
    public Transform log;
   

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
            
            OnInputCommand(userInput);
            
            //refocus input field
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    void ClearInputField() {
        terminalInput.text = "";
    }

    void ClearTerminalLog() {
        foreach (Transform child in log)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddInterpreterLines(List<string> userInput) {
        ClearTerminalLog();
        GameObject entry;
        for (int i = 0; i < userInput.Count; i++)
        {
            entry = Instantiate(logPrefab, log);
            entry.GetComponentInChildren<TMP_Text>().text = userInput[i];
        }
    }

   


   
}
