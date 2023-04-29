using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [SerializeField] public float damage;
    [Header("Fire Rate in 0.second")]
    [SerializeField] public float fireRate;
    [Header("Reloading in second")]
    [SerializeField] public float reload;
    [Header("Range in units")]
    [SerializeField] public float range;
    [SerializeField] public int typeWeapon;

    [SerializeField] private int ammoInWeapon;
    [SerializeField] private int maxAmmoInWeapon;
    [SerializeField] private int ammoInInventory;
    [SerializeField] private int maxAmmoInInventory;

    public bool isActive = false;
    public bool isShword;

    [SerializeField] public ParticleSystem fireParticle;
    [SerializeField] public AudioClip fireSound;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public Camera playerCamera;
    [SerializeField] public GameObject HUD;

    private float nextFire;

    private void Awake()
    {
        playerCamera = FindAnyObjectByType<Camera>();
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
            StartCoroutine(Reaload());
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

    private IEnumerator Reaload()
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
    }

    public void SendInformation()
    {
        HUD.GetComponent<HeadUpDisplay>().GetAmmoInformation(ammoInWeapon, ammoInInventory);
    }
}
