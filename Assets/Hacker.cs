using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class Hacker : MonoBehaviour
{    
    //Game configuration data
    string[] level1Passwords = {"food", "walk","drink","dog","cat","animal" };
    string[] level2Passwords = {"processor", "memory", "cooler", "graphics", "interface"};
    string[] level3Passwords = {"frequency", "intranet", "network", "rocket", "speakers"};
    
    
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
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            StartGame();
        }
        if (input == "007")
        {
            Terminal.WriteLine("Please choose your level Mr. Bond!");
        }
        else if (input == "420")
        {
            Terminal.WriteLine("Blaze it! No need to rush, choose your level when you're done.");
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
        _currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[0];
                break;
            case 2:
                password = level2Passwords[0];
                break;
            case 3:
                password = level3Passwords[0];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter your password:");
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
