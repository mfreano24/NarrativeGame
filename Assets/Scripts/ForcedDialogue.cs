using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedDialogue : MonoBehaviour
{
    [TextArea(5, 10)]
    public string[] dialogue;
    public Sprite[] icons;

    bool dialogueComplete = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogueComplete)
        {
            dialogueComplete = true;
            UIManager.Instance.DisplayDialogue(dialogue, icons);
        }
    }
}
