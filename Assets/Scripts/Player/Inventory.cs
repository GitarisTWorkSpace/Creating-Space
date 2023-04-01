using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public float healthPoint = 100f;
    [SerializeField] private float maxHealthPoint = 100f;
    [SerializeField] public int[] currentWeaponAmmo = new int[4];
    [SerializeField] public int[] maxCurrentWeaponAmmo = {0, 70, 300, 50};
    [SerializeField] public int[] currentAmmoInWeapon = new int[4];
    [SerializeField] public int[] maxCurrentAmmoInWeapon = {0, 7, 30, 5};

    public TMP_Text HealthText;
    public TMP_Text Ammo;
    public TMP_Text InWeapon;

    public Slider HealthSlider;

    [SerializeField] public int indexOfWepon = 1;

    private void Update()
    {
        if(healthPoint > maxHealthPoint) healthPoint = maxHealthPoint;
        
        for(int i = 0; i < 4; i++)
        {
            if(maxCurrentWeaponAmmo[i] < currentWeaponAmmo[i])
                currentWeaponAmmo[i] = maxCurrentWeaponAmmo[i];

            if(maxCurrentAmmoInWeapon[i] < currentAmmoInWeapon[i])
                currentAmmoInWeapon[i] = maxCurrentAmmoInWeapon[i];
        }

        HealthText.text = Mathf.Round(healthPoint).ToString();
        HealthSlider.value = healthPoint;

        Ammo.text = currentWeaponAmmo[indexOfWepon - 1].ToString();
        InWeapon.text = currentAmmoInWeapon[indexOfWepon - 1].ToString();
    }
}
