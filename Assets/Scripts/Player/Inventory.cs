using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public float healthPoint = 100f;
    [SerializeField] private float maxHealthPoint = 100f;
    public int[] currentWeaponAmmo = new int[4];
    public int[] maxCurrentWeaponAmmo = new int[4] {0, 70, 300, 50};
    public int currentAmmoINWeapon;

    public TMP_Text HealthText;
    public TMP_Text Ammo;
    public TMP_Text InWeapon;

    public Slider HealthSlider;

    private void Update()
    {
        if(healthPoint > maxHealthPoint) healthPoint = maxHealthPoint;
        foreach(var item in currentWeaponAmmo)
            if (currentWeaponAmmo[item] > maxCurrentWeaponAmmo[item]) 
                currentWeaponAmmo = maxCurrentWeaponAmmo;

        HealthText.text = Mathf.Round(healthPoint).ToString();
        HealthSlider.value = healthPoint;

        Ammo.text = currentWeaponAmmo.ToString();
        InWeapon.text = currentAmmoINWeapon.ToString();
    }
}
