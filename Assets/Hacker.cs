using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        ShowMainMenu("Ted");
        
    }

    void ShowMainMenu(string userName)
    {    
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello there, " + userName);
        Terminal.WriteLine("We need someone to hack into various facilities. Can you do it?");
        Terminal.WriteLine("Press 1 for the Daily Life Corp.");
        Terminal.WriteLine("Press 2 for the AMD Computers");
        Terminal.WriteLine("Press 3 for the All Knowing Organization");
        Terminal.WriteLine("Do you need a backstory? Press 4");
        Terminal.WriteLine("Enter your selection: ");
    }
    void OnUserInput(string input)
    {
        if ( input == "007") {
            Terminal.WriteLine("Please choose your level Mr. Bond");
        }
        else if (input == "420") {
            Terminal.WriteLine("Blaze it! No need to rush, choose your level when you're done.");
        } 
        else if (input == "1")
        {
            Terminal.WriteLine("You chose level 1");
        } else if (input == "menu")
        {
            ShowMainMenu("Ted");
        }
        else {
            Terminal.WriteLine("False");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
