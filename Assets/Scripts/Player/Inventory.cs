using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public GameObject[] WeaponInInventory = new GameObject[3];
    [SerializeField] public int[] countMediKitIninvenory = new int[3];
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
                case 0:
                    countMediKitIninvenory[index]--;
                    return 30f;
                case 1:
                    countMediKitIninvenory[index]--;
                    return 50f;
                case 2: 
                    countMediKitIninvenory[index]--;
                    return 100f;
                default: return 0;
            }
        }
        return 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            activMediKit++;
            if(activMediKit >= countMediKitIninvenory.Length)
            {
                activMediKit = 0;
            }
        }
        //else if (Input.GetKeyDown(KeyCode.Tab) && countMediKitIninvenory.Length > activMediKit)
        //{
        //    activMediKit = 0;
        //}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Health>().GetHealing(Medikit(activMediKit));
        }
    }
}
