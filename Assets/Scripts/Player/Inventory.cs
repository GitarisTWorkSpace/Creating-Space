using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public GameObject Hand;
    [SerializeField] public int[] countMediKitIninvenory = new int[3];
    [SerializeField] public int activMediKit = 0;
    [SerializeField] public int activeWeapon = 0;

    [SerializeField] public int[] Ammonation = new int[3];
    [SerializeField] private int[] maxAmmonation = new int[3];

    public void GetAmmonation(int countAmmonation, int typeAmmonation)
    {
        Ammonation[typeAmmonation] += countAmmonation;
    }

    private void CheckAmmonation()
    {
        for(int i = 0; i < Ammonation.Length; i++)
            if(Ammonation[i] > maxAmmonation[i]) Ammonation[i] = maxAmmonation[i];
    }

    private void SetWeapon(int index)
    {
        Hand.transform.GetChild(index).gameObject.SetActive(true);
        for (int i = 0; i < Hand.transform.childCount; i++)
        {
            if (i != index)
                Hand.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void SwichWeapon()
    {
        int countCild = Hand.transform.childCount;

        if (Input.GetKeyDown(KeyCode.Alpha1) && countCild >= 0)
            SetWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2) && countCild >= 1)
            SetWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3) && countCild >= 2)
            SetWeapon(2);
        if (Input.GetKeyDown(KeyCode.Alpha4) && countCild >= 3)
            SetWeapon(3);
        if (Input.GetKeyDown(KeyCode.Alpha5) && countCild >= 4)
            SetWeapon(4);
        if (Input.GetKeyDown(KeyCode.Alpha6) && countCild >= 5)
            SetWeapon(5);
        if (Input.GetKeyDown(KeyCode.Alpha7) && countCild >= 6)
            SetWeapon(6);
        if (Input.GetKeyDown(KeyCode.Alpha8) && countCild >= 7)
            SetWeapon(7);
        if (Input.GetKeyDown(KeyCode.Alpha9) && countCild >= 8)
            SetWeapon(8);

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(activeWeapon >= Hand.transform.childCount)
                activeWeapon = 0;
            else 
                activeWeapon++;

            SetWeapon(activeWeapon);
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (activeWeapon <= 0)
                activeWeapon = Hand.transform.childCount;
            else
                activeWeapon--;

            SetWeapon(activeWeapon);
        }
    }

    private float Medikit(int index)
    {
        if (countMediKitIninvenory[index] > 0)
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Health>().TakeHealing(Medikit(activMediKit));
        }

        SwichWeapon();
        CheckAmmonation();
    }
}
