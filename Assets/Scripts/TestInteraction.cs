using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : Interactive
{
    public override void Interact()
    {
        base.Interact();

        Debug.Log("this is the test interaction.");
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
