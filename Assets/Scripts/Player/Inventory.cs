using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public float healthPoint = 100f; // Кол-во здаровья игрока 
    [SerializeField] private float maxHealthPoint = 100f; // Максимальное здоровье игрока
    [SerializeField] public int[] currentWeaponAmmo = new int[4]; // Кол-во патронов у игрока 
    [SerializeField] public int[] maxCurrentWeaponAmmo = {0, 70, 300, 50}; // максимально возможное кол-во патронов у игрока
    [SerializeField] public int[] currentAmmoInWeapon = new int[4]; // Кол-во патронов в обойме у игрока
    [SerializeField] public int[] maxCurrentAmmoInWeapon = {0, 7, 30, 5}; // Максимально возможное кол-во патронов в обойме 

    public TMP_Text HealthText; // UI текст со значением кол-во здоровья
    public TMP_Text Ammo; // UI текст со значением кол-во патронов у игрока
    public TMP_Text InWeapon; // UI текст со значением кол-во патронов в обойме

    public Slider HealthSlider; // UI Слайдер для показания здоровья игрока

    [SerializeField] public int indexOfWepon = 0; // Индекс оружия в руках игрока.

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

        Ammo.text = currentWeaponAmmo[indexOfWepon].ToString();
        InWeapon.text = currentAmmoInWeapon[indexOfWepon].ToString();
    }
}
