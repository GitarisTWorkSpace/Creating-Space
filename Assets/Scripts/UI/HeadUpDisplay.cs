using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadUpDisplay : MonoBehaviour
{
    public GameObject PausePanel;
    private bool pauseIsActive = false;

    public TMP_Text HealthText; // UI текст со значением кол-во здоровья
    public TMP_Text AmmoInInventory; // UI текст со значением кол-во патронов у игрока
    public TMP_Text AmmoInWeapon; // UI текст со значением кол-во патронов в обойме

    public Slider HealthSlider; // UI Слайдер для показания здоровья игрока

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
