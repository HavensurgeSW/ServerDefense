using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameManager : MonoBehaviour
{
    [SerializeField]private List<Command> commands = new List<Command>();
    [SerializeField]private TerminalManager terminal;



    private void Awake()
    {
        terminal.Init(InterpretCommand);
    }

    List<string> InterpretCommand(string s){
        string[] arguments = s.Split(' ');
       

        foreach (Command cmd in commands)
        {
            if (cmd.INFO.ID == arguments[0])
            {
                cmd.CALLBACK?.Invoke();
                return cmd.INFO.RESPONSE;
            }
            
        }

        return new List<string> { "Command not recognized. Type \"help\" for a list of commands" };
    }
}
