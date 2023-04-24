using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadUpDisplay : MonoBehaviour
{
    public GameObject PausePanel;
    private bool pauseIsActive = false;

    public TMP_Text Ammo; // UI ����� �� ��������� ���-�� �������� � ������
    public TMP_Text InWeapon; // UI ����� �� ��������� ���-�� �������� � ������

    public void ToStart()
    {
        SceneManager.LoadScene("MainMenu");
    }

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
