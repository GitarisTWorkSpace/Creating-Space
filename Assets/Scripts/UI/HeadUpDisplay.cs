using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadUpDisplay : MonoBehaviour
{
    public GameObject PausePanel;
    private bool pauseIsActive = false;

    public TMP_Text HealthText; // UI ����� �� ��������� ���-�� ��������
    public TMP_Text AmmoInInventory; // UI ����� �� ��������� ���-�� �������� � ������
    public TMP_Text AmmoInWeapon; // UI ����� �� ��������� ���-�� �������� � ������

    public Slider HealthSlider; // UI ������� ��� ��������� �������� ������

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

        Time.timeScale = pauseIsActive ? 0f : 1f;
    }

    public void IsPaused(bool value)
    {
        pauseIsActive = value;
    }

    public void GetAmmoInformation(int ammoInWeapon, int ammoInInventory)
    {
        AmmoInInventory.text = ammoInInventory.ToString();
        AmmoInWeapon.text = ammoInWeapon.ToString();
    }

    public void GetHealthInformation(float healthPoint)
    {
        HealthText.text = Mathf.Round(healthPoint).ToString();
        HealthSlider.value = healthPoint;
    }

    private void Update()
    {
        ActivePause();    
    }
}
