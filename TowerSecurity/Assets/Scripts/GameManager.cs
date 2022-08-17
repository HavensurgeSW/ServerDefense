using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class GameManager : MonoBehaviour
{
    [SerializeField]private List<Command> commands = new List<Command>();
    [SerializeField]private TerminalManager terminal;

    public Location[] locations;
  

    Location currentLocation;

    private void Awake()
    {
        terminal.Init(InterpretCommand);
        currentLocation = null;
    }

    List<string> InterpretCommand(string s){
        s.ToLower();
        string[] arguments = s.Split(' ');
       
        bool searchHit = false;

        foreach (Command cmd in commands)
        {
            if (cmd.INFO.ID == arguments[0])
            {
                string[] tempArg = new string[arguments.Length - 1];
                for (int i = 1; i <= tempArg.Length; i++)
                {
                    tempArg[i-1] = arguments[i];
                }

                searchHit = true;
                cmd.CALLBACK?.Invoke(tempArg);
                return cmd.INFO.RESPONSE; 
            }
     
        }

        return new List<string> { "Command not recognized. Type \"help\" for a list of commands" };
    }

    public void ChangeDirectory(string[] arg) {
        //arguments.length-1 != argCountSO
        string locName = arg[0];

        foreach (Location loc in locations)
        {
            if (loc.id == locName)
            {
                currentLocation = loc;
                loc.ToggleSelected(true);
                loc.ToggleColor(Color.red);
            }
            else
            {
                loc.ToggleSelected(false);
                loc.ToggleColor(Color.white);
            }
        }
    }

}
