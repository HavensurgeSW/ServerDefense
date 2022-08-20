using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "CommandInfo")]
public class CommandInfo : ScriptableObject {
    [SerializeField]private string id;
    [SerializeField]private int argCount;
    [SerializeField]private List<string> succResponse = new List<string>();
    [SerializeField] private List<string> errorResponse = new List<string>();

    public string ID { get=>id;}
    public int ARGCOUNT { get => argCount; }
    public List<string> SUCCRESPONSE { get=>succResponse;}
    public List<string> ERRORRESPONSE { get => errorResponse; }
}
