using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public GameObject[] WeaponInInventory;
    [SerializeField] public int[] countMediKitIninvenory;
    [SerializeField] public int activMediKit;

    public void SetAmmoInWeapon(int typeWeapon, int ammo)
    {
        foreach(var weapon in WeaponInInventory)
        {
            if (weapon == null) continue;

            if (weapon.GetComponent<Weapon>().typeWeapon == typeWeapon)
                weapon.GetComponent<Weapon>().GetAmmo(ammo);
        }
    }

    private float Medikit(int index)
    {
        if (countMediKitIninvenory[index] > 0)
        {
            switch (index)
            {
                case 0: return 30f;
                case 1: return 50f;
                case 2: return 100f;
                default: return 0;
            }
        }
        return 0;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && countMediKitIninvenory.Length <= activMediKit)
        {
            activMediKit++;
        }
        else
        {
            activMediKit = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Health>().GetHealing(Medikit(activMediKit));
        }
    }
}
