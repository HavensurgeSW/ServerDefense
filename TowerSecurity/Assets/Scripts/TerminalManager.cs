using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;

using TMPro;

public class TerminalManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject cmdEntryPrefab = null;

    [Header("Required components")]
    [SerializeField] private TMP_InputField terminalInput = null;
    [SerializeField] private Transform logHolder = null;

    private List<CmdEntry> activeEntries = null;
    private ObjectPool<CmdEntry> entriesPool = null;

    private Action<string> OnInputCommand = null;

    public void Init(Action<string> onInputCommand)
    {
        terminalInput.ActivateInputField();
        terminalInput.Select();
        OnInputCommand = onInputCommand;

        activeEntries = new List<CmdEntry>();

        entriesPool = new ObjectPool<CmdEntry>(CreateEntry, GetEntry, ReleaseEntry);
    }

    // TODO: CHECK WHY THIS WORKS WITH ONGUI AND NOT WITH UPDATE
    private void OnGUI()
    {
        if (!terminalInput.isFocused || string.IsNullOrEmpty(terminalInput.text))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnInputCommand(terminalInput.text);

            ClearInputField();

            //refocus input field
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    private void ClearInputField()
    {
        terminalInput.text = string.Empty;
    }

    private void ClearCmdEntries()
    {
        for (int i = 0; i < activeEntries.Count; i++)
        {
            entriesPool.Release(activeEntries[i]);
        }

        activeEntries.Clear();
    }

    public void AddInterpreterLines(List<string> userInput)
    {
        ClearCmdEntries();
        for (int i = 0; i < userInput.Count; i++)
        {
            CmdEntry entry = entriesPool.Get();
            entry.SetSiblingIndex(i);
            entry.SetText(userInput[i]);
            activeEntries.Add(entry);
        }
    }

    private CmdEntry CreateEntry()
    {
        return Instantiate(cmdEntryPrefab, logHolder).GetComponent<CmdEntry>();
    }

    private void GetEntry(CmdEntry entry)
    {
        entry.ToggleStatus(true);
    }

    private void ReleaseEntry(CmdEntry entry)
    {
        entry.SetText(string.Empty);
        entry.ToggleStatus(false);
    }
}
