using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class PlayerStats
{
    private static int points;

    private static string[] inventory = new string[4];

    public static string[] bowergirlSpeech {get; private set; } = new string[10];

    public static bool gameDone;

    public static string grade {get; set;}

    public static int Points 
    {
        get 
        {
            return points;
        }
        set
        {
            points = value;
        }
    }

    public static bool Done
    {
        get
        {
            return gameDone;
        }
        set
        {
            gameDone = value;
        }
    }

    public static string[] Content 
    {
        get 
        {
            return inventory;
        }
        set 
        {
            inventory = value;
        }
    }

    public static void DetermineResult()
    {

        if (inventory.All(value => string.IsNullOrEmpty(value)))
        {
            Debug.Log("we made it!");
            bowergirlSpeech[0] = " what the <b>FUCK</b>";
            bowergirlSpeech[1] = "really?! you didn't get me... anything???";
            bowergirlSpeech[2] = "im gonna beat ur ass >:(";
            grade = "F";
            return;
        }

        if (inventory.Any(value => value == "coin") && inventory.Any(value => value == "whiteflower"))
        {
            bowergirlSpeech[0] = "<b>SERIOUSLY?</b>";
            bowergirlSpeech[1] = "<color=red><b>These are my two least favorite things!</b></color>";
            bowergirlSpeech[2] = "I hate everything!";
            grade = "F";
            return;
        }

        if (inventory.Any(value => value == "coin"))
        {
            bowergirlSpeech[0] = "wait what is THIS?!";
            bowergirlSpeech[1] = "<b>This coin isn't even shiny! Did you just pick this from the ground?</b>";
            bowergirlSpeech[2] = "All of this is horrible! I hate it!";
            grade = "F";
            return;
        }

        if (inventory.Any(value => value == "whiteflower"))
        {
            bowergirlSpeech[0] = "...";
            bowergirlSpeech[1] = "These are my least favorite colors.";
            bowergirlSpeech[2] = "Ugh, just go.";
            grade = "F";
            return;
        }
        int count = 0;

        foreach (string item in inventory)
        {
            string reaction = "";
            switch (item)
            {
                case "flower":
                    reaction = "What a nice flower!";
                    break;
                case "bottlecap":
                    reaction = "The bottlecap is a little icky but... it's the thought that counts.";
                    break;
                case "berry":
                    reaction = "A blue berry! My favorite :)";
                    break;
                case "keys":
                    reaction = "The keys are shiny but you know I can't drive right?";
                    break;
                case "sock":
                    reaction = "This sock is great, I can feel it in my sole.";
                    break;
                case "straw":
                    reaction = "The straw you brought me is... exstrawvagant!";
                    break;
                case "feather":
                    reaction = "Wasn't this feather attached to your tail last week??";
                    break;
                case "raisin":
                    reaction = "Ugh.. you couldn't find me a fresh grape. I'll be raisin hell about this...";
                    break;
                default:
                    break;
            }
            bowergirlSpeech[count] = reaction;
            count++;
        }

        if (points < 0)
        {
            grade = "D";

        }
        else if (points > 0 && points < 7)
        {
            grade = "C";
        }
        else if (points > 5 && points < 11)
        {
            grade = "B";
        }
        else if (points > 0 && points < 16)
        {
            grade = "A";
        }
        else if (points == 16)
        {
            grade = "A+";
        }



    }
}