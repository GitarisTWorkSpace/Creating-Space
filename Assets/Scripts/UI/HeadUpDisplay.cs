using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadUpDisplay : MonoBehaviour
{
    public GameObject PausePanel;
    private bool pauseIsActive = false;

    private void ActivePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            pauseIsActive = true;
        }

        if (pauseIsActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void IsPaused(bool value)
    {
        pauseIsActive = value;
    }

    private void Update()
    {
        ActivePause();
    }
}
