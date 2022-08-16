using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class Command
{
    [SerializeField] private CommandInfo info;
    [SerializeField] private UnityEvent callback;

    public CommandInfo INFO { get => info; }
    public UnityEvent CALLBACK { get => callback; }
}
