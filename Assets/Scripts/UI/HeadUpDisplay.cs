using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadUpDisplay : MonoBehaviour
{
    [SerializeField] public TMP_Text HealthText; // UI текст со значением кол-во здоровья
    [SerializeField] public Slider HealthSlider; // UI Слайдер для показания здоровья игрока

    [SerializeField] public TMP_Text AmmoInWeapon; // UI текст со значением кол-во патронов в обойме
    [SerializeField] public TMP_Text AmmoInInventory; // UI текст со значением кол-во патронов у игрока

    [SerializeField] public TMP_Text PressE;
    [SerializeField] public TMP_Text CountZombieLost;

    [SerializeField] public GameObject DeadPanel;
    private bool deadIsActive = false;

    [SerializeField] public GameObject PausePanel;
    private bool pauseIsActive = false;

    public void ToStart()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ActivePressE(bool isActive)
    {
        if (isActive)
            PressE.text = "E";
        if (!isActive)
            PressE.text = "";
    }

    public void SetInterectebleText(string text)
    {
        PressE.text = text;
    }

    public void SetCountZombie(int count)
    {
        CountZombieLost.text = count.ToString();
    }

    public void IsPaused(bool status) 
    { 
        pauseIsActive = status; 
        Time.timeScale = pauseIsActive ? 0f : 1f; 
    }

    public void ActiveDeadScrin(bool status)
    {
        deadIsActive = status;
        if (!deadIsActive)
        {
            DeadPanel.SetActive(true);
            deadIsActive = true;
        }
        else if (deadIsActive)
        {
            DeadPanel.SetActive(false);
            deadIsActive = false;
        }

        Time.timeScale = deadIsActive ? 0f : 1f;
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

    private void ActivePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            pauseIsActive = true;
            Time.timeScale = 0f;
        }
    }
}
