using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "CommandInfo")]
public class CommandInfo : ScriptableObject {
    [SerializeField]private string id;

    public string ID { get=>id;}
}
