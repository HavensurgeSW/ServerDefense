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

    void InterpretCommand(string s){
        s.ToLower();
        string[] arguments = s.Split(' ');
        bool searchHit = false;
       
        foreach (Command cmd in commands)
        {
            if (cmd.INFO.ID == arguments[0])
            {
                searchHit = true;
                string[] tempArg = new string[arguments.Length - 1];
                for (int i = 1; i <= tempArg.Length; i++)
                {
                    tempArg[i - 1] = arguments[i];
                }
                cmd.CALLBACK?.Invoke(tempArg, cmd.INFO);
                break;
                //return cmd.INFO.SUCCRESPONSE; 
            }
     
        }

        if (!searchHit) {
            
        }

       //return new List<string> { "Command not recognized. Type \"help\" for a list of commands" };
    }

   

    public void ChangeDirectory(string[] arg, CommandInfo cmdi) {
        //arguments.length-1 != argCountSO
        string locName = arg[0];
        bool searchHit = false;
        foreach (Location loc in locations)
        {
            if (loc.id == locName)
            {
                currentLocation = loc;
                loc.ToggleSelected(true);
                loc.ToggleColor(Color.red);
                searchHit = true;
            }
            else
            {
                loc.ToggleSelected(false);
                loc.ToggleColor(Color.white);
            }
        }

        if (searchHit) {
            terminal.AddInterpreterLines(cmdi.ERRORRESPONSE);
        }
    }

    public void InstallTower(string[] arg) {

        if (currentLocation != null&&currentLocation.CheckForLocationAvailability()) {
            
        }
            
    }

}
