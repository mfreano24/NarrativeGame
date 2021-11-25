using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBookcase : Interactive
{

    public string color;

    public override void Interact()
    {
        base.Interact();
        GameManager.Instance.AddColorToCurrentSolve(color);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().SetInteractive(this);
            UIManager.Instance.DisplayPromptText(promptText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().SetInteractive(null);
            UIManager.Instance.DisplayPromptText("");
        }
    }
}
