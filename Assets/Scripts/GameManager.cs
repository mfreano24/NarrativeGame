using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;

    public static GameManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public PlayerController player;

    public void DisablePlayerControls()
    {
        player.controlsEnabled = false;
    }


    public void EnablePlayerControls()
    {
        player.controlsEnabled = true;
    }
<<<<<<< HEAD


    #region ProgressionFlags
    public int numTemplePuzzlesSolved = 0;

    public bool hasSleptInBedroom = false;

    public void IncrementTemplePuzzles()
    {
        if (SceneManager.GetActiveScene().name != "TempleLevel")
        {
            return;
        }

        ++numTemplePuzzlesSolved;
        GameObject e = GameObject.Find("EndingDoor");
        Vector3 pos = e.transform.position;
        if(numTemplePuzzlesSolved >= 3)
        {
            pos.y = 14.97f;
        }
        else if(numTemplePuzzlesSolved == 2)
        {
            pos.y = 11.7f;
        }
        else if(numTemplePuzzlesSolved == 1)
        {
            pos.y = 9.54f;
            GameObject.Find("doordialogue").GetComponent<BoxCollider>().enabled = true;
        }

        e.transform.position = pos;


    }

    

    public void SleepInBed()
    {
        hasSleptInBedroom = true;
    }

    //UUUUUUUUUUUUUUUUUUUUUUUUUUGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHGHGHGHGHHHHHHHHHGHGHGGUHGUHHHGHHHHHHHHHH

    public void AddColorToCurrentSolve(string color)
    {
        if (!hasSleptInBedroom)
        {
            string[] SleepyDialogue = {"*yaaaaawn*. I think I'm a bit tired. This seems like a lot to take in right now.",
            "Maybe I'll find somewhere to take a rest first."};

            Sprite[] SleepyIcons = { spriteChoices[0], spriteChoices[1] };

            UIManager.Instance.DisplayDialogue(SleepyDialogue, SleepyIcons);
            return;
        }


        if(color == roygbiv[currIndex])
        {
            currList.Add(color);
            currIndex--;
            string[] GoodDlog = { "Yep. Adding " + color + "." };
            Sprite[] GoodIcons = { spriteChoices[1] };
            if (currIndex < 0)
            {
                SolveTempleThinkPuzzle();
            }
        }
        else
        {
            currIndex = roygbiv.Count - 1;
            string[] IncorrectDlog = { "Hmm, that doesn't seem right. Let me try again." };
            Sprite[] incorrectIcons = { spriteChoices[2] };
            UIManager.Instance.DisplayDialogue(IncorrectDlog, incorrectIcons);
        }
    }

    public void SolveTempleThinkPuzzle()
    {
        UIManager.Instance.promptText.text = "";
        string[] GoodDlog = { "I think I got it. Violet, Indigo, Blue, Green, Yellow, Orange, Red. That's light in reverse, isn't it?",
            "...I think I heard something move from the main hallway. Maybe the weird looking door moved.."};
        Sprite[] GoodIcons = { spriteChoices[1], spriteChoices[2] };

        UIManager.Instance.DisplayDialogue(GoodDlog, GoodIcons);
        foreach (RainbowBookcase rb in Bookcases)
        {
            rb.enabled = false; //no longer process this puzzle, please!
        }

        IncrementTemplePuzzles(); //this should be the last one.
    }
    #endregion
=======
>>>>>>> parent of 9e5f10b (finished base temple without decor)
}
