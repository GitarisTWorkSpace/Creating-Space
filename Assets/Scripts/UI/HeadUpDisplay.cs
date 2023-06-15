using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadUpDisplay : MonoBehaviour
{
    #region Health
    [Header("Health")]

    [SerializeField] public TMP_Text HealthPoints;
    [SerializeField] public Slider HealthPointsSlider;
    [SerializeField] public TMP_Text CountMediKit;
    #endregion

    #region MediKit
    [Header("MediKit")]
    [SerializeField] public Image MediKitImage;
    [SerializeField] public Sprite[] MediKitSprites;
    #endregion

    #region Weapon
    [Header("Weapon")]

    [SerializeField] public TMP_Text IndexWeaponInHand;
    [SerializeField] public TMP_Text AmmoInWeapon;
    [SerializeField] public TMP_Text AmmoInInventory;
    #endregion

    #region Panels
    [Header("Panels")]

    [SerializeField] public GameObject PausePanel;
    private bool pausePanelisActive = false;

    [SerializeField] public Slider SensivitySlider;

    [SerializeField] public GameObject ReaderPanel;
    [SerializeField] public TMP_Text HeaderText;
    [SerializeField] public TMP_Text ReaderText;
    private bool readrePanelIsActive = false;

    [SerializeField] public GameObject PressE;
    private bool pressButtonIsActive = false;
 
    [SerializeField] public GameObject DeadPanel;
    private bool deadPanelIsActive = false;
    #endregion

    #region Scripts
    [Header("Scripts")]

    [SerializeField] public Health Health;
    [SerializeField] public Inventory Inventory;
    [SerializeField] public PlayerMoveController PlayerController;
    [SerializeField] public Weapon Weapon;
    [SerializeField] public MeleeWeapon MeleeWeapon;
    #endregion

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SetSensivity(20f);
    }

    #region Panels Method
    public void ActivePausePanel(bool value)
    {
        pausePanelisActive = value;
    }

    public void ActiveReader(bool value)
    {
        readrePanelIsActive = value;
    }

    public void GetReaderPanelInfo(string headerText, string mainReaderText)
    {
        HeaderText.text = headerText;
        ReaderText.text = mainReaderText;
        ActiveReader(true);
    }

    public void ActivePressButton(bool value)
    {
        pressButtonIsActive = value;
    }

    public void ActiveDeadPanel(bool value)
    {
        deadPanelIsActive = value;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    public void SetSensivity(float value)
    {
        PlayerController.sensivity = value;
        SensivitySlider.value = value;
    }

    #region Private Method
    private void UpdateHealhPointsInfo()
    {
        HealthPoints.text = Health.healthPoint.ToString();
        HealthPointsSlider.maxValue = 100f;
        HealthPointsSlider.value = Health.healthPoint;
    }

    private void UpdateMediKItInfo()
    {
        CountMediKit.text = Inventory.countMediKitIninvenory[Inventory.activMediKit].ToString();
        MediKitImage.sprite = MediKitSprites[Inventory.activMediKit];
    }

    private void UpdateAmmoInfo()
    {
        IndexWeaponInHand.text = Inventory.activeWeapon.ToString();
        if (Inventory.activeWeapon == 0)
        {
            AmmoInWeapon.text = Weapon.ammoInWeapon.ToString();
            AmmoInInventory.text = Weapon.ammoInInventory.ToString();
        }
        else
        {
            AmmoInInventory.text = "0";
            AmmoInWeapon.text = "0";
        }
    }
    #endregion

    private void Update()
    {
        UpdateHealhPointsInfo();
        UpdateMediKItInfo();
        UpdateAmmoInfo();

        PausePanel.SetActive(pausePanelisActive);
        ReaderPanel.SetActive(readrePanelIsActive);
        DeadPanel.SetActive(deadPanelIsActive);
        PressE.SetActive(pressButtonIsActive);

        if (readrePanelIsActive || pausePanelisActive || deadPanelIsActive) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = pausePanelisActive || readrePanelIsActive || deadPanelIsActive ? 0 : 1;
    }
}
