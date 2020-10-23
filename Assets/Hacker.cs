using UnityEngine;

public class Hacker : MonoBehaviour
{    
    //Game configuration data
    string[] level1Passwords = {"food", "walk","drink","dog","cat","animal" };
    string[] level2Passwords = {"processor", "memory", "cooler", "graphics", "interface"};
    string[] level3Passwords = {"frequency", "intranet", "network", "rocket", "speakers"};
    int page = 0;
    string[] storyLine =
    {
        "We need someone to hack into the following facilities. Our budget is very limited and this is why we turned to you.", 
        "The more facilities you manage to break in, the more funding we'll raise. This is the moment to prove yourself and maybe you'll get richer than you ever dreamed.",
        "We managed to find some clues about the passwords but were unable to figure everything out. Can you do it for us? Type menu and choose a level!"
    };
    
    //game state
    int count = 0;
    int level; 
    enum Screen
    {
        MainMenu,
        Password,
        Win,
        Story
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
            count = 0;
            page = 0;
        }
        else if (_currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (_currentScreen == Screen.Password)
        {
            PassChecker(input);
        } else if (_currentScreen == Screen.Story)
        {
            Terminal.ClearScreen();
            ReadStory(storyLine,page);
        }
        
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3" || input=="4");
        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level!");
        }
        if (input == "007")
        {
            Terminal.WriteLine("Please choose your level Mr. Bond!");
        }
        else if (input == "420")
        {
            Terminal.WriteLine("Blaze it! No need to rush, choose your level when you're done.");
        }
        else
        {
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

    void AskForPassword()
    {
        
        _currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                DisplayPasswordAnagram();
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                DisplayPasswordAnagram();
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                DisplayPasswordAnagram();
                break;
            case 4:
                _currentScreen = Screen.Story;
                ReadStory(storyLine, page);
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void DisplayPasswordAnagram()
    {
        Terminal.WriteLine("Enter your password: " + password.Anagram());
    }
    void PassChecker(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        _currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have some ramen...");
                Terminal.WriteLine(@"
         |
         |  /
         | /
   .~^(,&|/o.
  |`-------^|
  \         /
   `======='  
");
                break;
            case 2:
                Terminal.WriteLine("The processors are heating up...");
                Terminal.WriteLine(@"
.--.
|__| .-------.
|=.| |.-----.|
|--| || AMD ||
|  | |'-----'|
|__|~')_____('
");
                break;
            case 3:
                Terminal.WriteLine("YOU ARE ALL KNOWING! THE HUMANITY IS BOWING BEFORE YOU...");
                Terminal.WriteLine(@"
      ___                       
 __  |'''|  __                   
|''| |'''| |''|       
|''| |'''| |''|     
|''| |'''| |''|      
---------------
");
                break;
            case 4:
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
            
        }
        
    }

    void ReadStory(string[] chapter,int index)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(chapter[index]);
        page++;

    }
    // Update is called once per frame
    void Update()
    {
        /*var index = Random.Range(0, level1Passwords.Length);
        print(level1Passwords[index]);*/
    }
}
