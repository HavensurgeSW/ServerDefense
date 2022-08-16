using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class Command
{
    [SerializeField] private CommandInfo info;
    [SerializeField] private UnityEvent<string[]> callback;

    public CommandInfo INFO { get => info; }
    public UnityEvent<string[]> CALLBACK { get => callback; }
}
