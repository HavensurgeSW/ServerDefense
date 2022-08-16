using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();

    public List<string> Interpret(string userInput) {
        response.Clear();

        userInput = userInput.ToLower();
        string[] args = userInput.Split();

        if (args[0] == "help")
        {
            response.Add("You should try 'hello' ");
        }
        else if (args[0] == "hello") {
            response.Add("Welcome to the system, Administrator");
        }
        else{
            response.Add("Command not recognized. Type \"help\" for a list of commands");
        }




        return response;
    }
}
