using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "CommandInfo")]
public class CommandInfo : ScriptableObject {
    [SerializeField]private string id;
    [SerializeField]private int argCount;
    [SerializeField]private List<string> response = new List<string>();

    public string ID { get=>id;}
    public List<string> RESPONSE { get=>response;}
}
