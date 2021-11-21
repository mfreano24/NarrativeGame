using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public string promptText;

    [TextArea(3,6)]
    public string[] dialogue;
    public Sprite[] icons;


    public virtual void Interact()
    {
        UIManager.Instance.DisplayDialogue(dialogue, icons);
    }
}
