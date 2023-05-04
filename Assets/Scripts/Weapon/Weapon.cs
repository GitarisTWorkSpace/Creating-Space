using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Характеристики
    [SerializeField] public float damage;
    [Header("Fire Rate in 0.second")]
    [SerializeField] public float fireRate;
    [Header("Reloading in second")]
    [SerializeField] public float reload;
    [Header("Range in units")]
    [SerializeField] public float range;
    [SerializeField] public int typeWeapon;
    public bool isActive = false;
    public bool isShword;
    #endregion

    #region Объекты
    [SerializeField] public ParticleSystem fireParticle;
    [SerializeField] public AudioClip fireSound;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public Camera playerCamera;
    [SerializeField] public GameObject HUD;
    #endregion

    #region Патроны
    [SerializeField] private int ammoInWeapon;
    [SerializeField] private int maxAmmoInWeapon;
    [SerializeField] private int ammoInInventory;
    [SerializeField] private int maxAmmoInInventory;
    #endregion

    private float nextFire;

    private void Awake()
    {
        playerCamera = FindObjectOfType<Camera>();
        HUD = FindObjectOfType<HeadUpDisplay>().gameObject;
    }

    private void Update()
    {
        if(ammoInWeapon == 0 && !isShword)
        {
            isActive = false;
        }

        if (Input.GetMouseButton(0) && Time.time > nextFire && isActive)
        {
            nextFire = Time.time + fireRate; 
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isShword && gameObject.transform.parent != null)
        {
            StartCoroutine(RealoadWeapon());
        }
    }

    public void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log("Попал в " + hit.transform.gameObject.name);
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.gameObject.GetComponent<Zombie>().healthPointZ -= damage;
            }
        }

        //if(!isShword)
            ammoInWeapon--;

        SendInformation();
    }

    private void Reloading()
    {
        if (maxAmmoInWeapon == ammoInWeapon)
            return;

        if (ammoInInventory == 0)
            return;

        if (ammoInInventory >= maxAmmoInWeapon)
        {
            ammoInInventory -= maxAmmoInWeapon - ammoInWeapon;
            ammoInWeapon = maxAmmoInWeapon;
        }
        else
        {
            ammoInWeapon += ammoInInventory;
            ammoInInventory = 0;
        }
    }

    private IEnumerator RealoadWeapon()
    {
        isActive = false;
        Reloading();
        yield return new WaitForSeconds(reload);
        SendInformation();
        isActive = true;
    }

    public void GetAmmo(int ammo)
    {
        ammoInInventory += ammo;

        if (maxAmmoInInventory < ammoInInventory)
            ammoInInventory = maxAmmoInInventory;

        if(isActive)
            SendInformation();
    }

    public void SendInformation()
    {
        HUD.GetComponent<HeadUpDisplay>().GetAmmoInformation(ammoInWeapon, ammoInInventory);
    }
}
