using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class Hacker : MonoBehaviour
{    
    //game state
    int count = 0;
    int level; 
    enum Screen
    {
        MainMenu,
        Password,
        Win
    };

    string password;

    Screen _currentScreen;
    // Start is called before the first frame update
    void Start()
    {   
        ShowMainMenu();
    }

    void ShowMainMenu()
    {    
        Terminal.ClearScreen();
        Terminal.WriteLine("We need someone to hack into various facilities. Can you do it?");
        Terminal.WriteLine("Press 1 for the Daily Life Corp.");
        Terminal.WriteLine("Press 2 for the AMD Computers");
        Terminal.WriteLine("Press 3 for the All Knowing Organization");
        Terminal.WriteLine("Do you need a backstory? Press 4");
        Terminal.WriteLine("Enter your selection: ");
        _currentScreen = Screen.MainMenu;
    }
    
    void OnUserInput(string input)
    {
        
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (_currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (_currentScreen == Screen.Password)
        {
            PassChecker(input);
        }
        
    }

    void RunMainMenu(string input)
    {
        if (input == "007")
        {
            Terminal.WriteLine("Please choose your level Mr. Bond!");
        }
        else if (input == "420")
        {
            Terminal.WriteLine("Blaze it! No need to rush, choose your level when you're done.");
        }
        else if (input == "1")
        {
            level = 1;
            password = "easypass";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "mediumpass";
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = "hardpass";
            StartGame();
        }
        else if (input == "4")
        {
            ReadBackstory();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
            count+=1;
            if (count == 3)
            {
                ShowMainMenu();
                Terminal.WriteLine("You must be dense. Please read the main menu again.CAREFULLY!");
                Terminal.WriteLine("CHOOSE FROM THE LEVELS LISTED ABOVE!");
                count = 0;
            }
        }
    }

    void StartGame()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password:");
        _currentScreen = Screen.Password;
    }

    void ReadBackstory()
    {
        Terminal.WriteLine("You chose to read your backstory.Coming right up!");
    }

    void PassChecker(string input)
    {
        if (input== password && level==1)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congratulations! You've cracked it!");
        } 
        else if (input == password && level == 2)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congratulations! You've cracked it!");
        }
        else if (input == password && level==3)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congratulations! You've cracked it!");
        }
        else
        {
            Terminal.WriteLine("The password is incorrect. Please try again!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
