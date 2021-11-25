using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleepytime : Interactive
{
    public override void Interact()
    {
        base.Interact();
        GameManager.Instance.hasSleptInBedroom = true;
        GameManager.Instance.IncrementTemplePuzzles(); //this is one, just gotta hope the player knows.
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
