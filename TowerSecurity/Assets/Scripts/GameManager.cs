using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;



public class GameManager : MonoBehaviour
{
    [SerializeField]private List<Command> commands = new List<Command>();
    //[SerializeField]private List<Waypoint> waypoints = new List<Waypoint>();
    [SerializeField]private TerminalManager terminal;

    public Tower prefab;
    public Tower prefab2;

    public Location[] locations;
  
    Location currentLocation;

    private void Awake()
    {
        terminal.Init(InterpretCommand);
        currentLocation = null;
    }

    void InterpretCommand(string s){
        string commandInput = s.ToLower();
        string[] arguments = commandInput.Split(' ');
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
            terminal.AddInterpreterLines(new List<string> { "Command not recognized. Type \"help\" for a list of commands" });
        }

    }

    #region COMMAND_IMPLEMENTATIONS

    public void ChangeDirectory(string[] arg, CommandInfo cmdi) {
        //arguments.length-1 != argCountSO
        string locName = arg[0];
        bool searchHit = false;
        foreach (Location loc in locations)
        {
            if (locName == "help" ||locName == "?") {
                terminal.AddInterpreterLines(cmdi.HELPRESPONSE);
                searchHit = true;
                break;
            }

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



        if (!searchHit) {
            terminal.AddInterpreterLines(cmdi.ERRORRESPONSE);
        }
    }

    public void Hello(string[] arg, CommandInfo cmdi) {
        terminal.AddInterpreterLines(cmdi.SUCCRESPONSE);
    }

    public void InstallTower(string[] arg, CommandInfo cmdi){
        //if (arg == null) {
        //    terminal.AddInterpreterLines(new List<string> { "No <Argument> detected. Use CD HELP for more information" });
        //}
        if (arg[0] == "help" || arg[0] == "?")
        {
            terminal.AddInterpreterLines(cmdi.HELPRESPONSE);
        }

        if (currentLocation != null&&currentLocation.CheckForLocationAvailability()){
            if (arg[0] == "antivirus")
            {
                currentLocation.SetAvailable(false);
                Instantiate(prefab,currentLocation.transform);
                terminal.AddInterpreterLines(cmdi.SUCCRESPONSE);
            }
            else {
                terminal.AddInterpreterLines(cmdi.ERRORRESPONSE);
            }

            if (arg[0] == "firewall")
            {
                currentLocation.SetAvailable(false);
                Instantiate(prefab2, currentLocation.transform);
                terminal.AddInterpreterLines(cmdi.SUCCRESPONSE);
            }
            else
            {
                terminal.AddInterpreterLines(cmdi.ERRORRESPONSE);
            }
        }
    }

    public void WriteTutorial(string[] arg, CommandInfo cmdi) {
        terminal.AddInterpreterLines(cmdi.SUCCRESPONSE);
    }

    public void ReloadScene(string[] arg, CommandInfo cmdi) {
        SceneManager.LoadScene(1);
    }

    public void QuitGame(string[] arg, CommandInfo cmdi)
    {
        if (arg[0] == "help" || arg[0] == "?")
        {
            terminal.AddInterpreterLines(cmdi.HELPRESPONSE);
        }

        if (arg[0] == "application") {
            Application.Quit();
        }
    }

    #endregion

}
