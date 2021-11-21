using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //singleton

    private static UIManager m_inst;

    public Text promptText;

    public static UIManager Instance
    {
        get
        {
            return m_inst;
        }
    }


    bool inDialogue = false;
    bool midTextDraw = false;
    bool finishedDraw = false;

    bool skipTextFlag = false;
    bool moveToNextDialogue = false;
    

    public Text dialogueText;
    public Image dialogueImage;
    public GameObject dialogueBox;

    private void Awake()
    {
        if(m_inst == null)
        {
            m_inst = this;
        }
        else
        {
            Debug.LogError("CANT HAVE MORE THAN 1 OF " + GetType());
        }

        promptText.text = "";

        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        bool lmbDown = Input.GetMouseButtonDown(0);
        if (lmbDown)
        {
            Debug.Log("Flags raised--inDialogue: " + inDialogue + " midTextDraw: " + midTextDraw + " finishedDraw: " + finishedDraw + " skipTextFlag" + skipTextFlag + " moveToNextDialogue: " + moveToNextDialogue);
        }
        if (inDialogue)
        {
            if(!finishedDraw && midTextDraw && lmbDown)
            {
                skipTextFlag = true;
            }
            else if (!midTextDraw && finishedDraw && lmbDown)
            {
                moveToNextDialogue = true;
            }
        }
    }



    public void DisplayDialogue(string[] dialogues, Sprite[] charactericons)
    {
        //make dialogue boxes
        if (!inDialogue)
        {
            dialogueBox.SetActive(true);
            GameManager.Instance.DisablePlayerControls();
            inDialogue = true;
            StartCoroutine(DrawDialogue(dialogues,charactericons));
        }
    }

    IEnumerator DrawDialogue(string[] dialogues, Sprite[] icons)
    {
        if(dialogues.Length != icons.Length)
        {
            Debug.LogError("dialogue count doesn't match the icon count");
        }

        for(int i = 0; i < dialogues.Length; i++)
        {
            
            StartCoroutine(DrawText(dialogues[i], dialogueText));
            dialogueImage.sprite = icons[i];
            yield return new WaitUntil(() => (finishedDraw && moveToNextDialogue && !midTextDraw));
            moveToNextDialogue = false;
            finishedDraw = false;
        }

        //disable dialogue box\
        GameManager.Instance.EnablePlayerControls();
        inDialogue = false;
        dialogueBox.SetActive(false);
    }

    IEnumerator DrawText(string currDialogue, Text drawTo)
    {
        midTextDraw = true;
        int n = currDialogue.Length;
        string currTxt = "";
        for(int i = 0; i < n; i++)
        {
            if (skipTextFlag)
            {
                skipTextFlag = false;
                dialogueText.text = currDialogue;
                break;
            }
            currTxt += currDialogue[i];
            dialogueText.text = currTxt;
            yield return new WaitForSeconds(0.05f);
        }
        finishedDraw = true;
        midTextDraw = false;
    }

    public void DisplayPromptText(string prompt)
    {
        Debug.Log("ope, we're in range.");
        promptText.text = prompt;
    }
}
