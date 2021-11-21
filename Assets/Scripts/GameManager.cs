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
}
