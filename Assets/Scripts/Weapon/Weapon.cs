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
    #endregion

    #region Объекты
    [SerializeField] public ParticleSystem fireParticle;
    [SerializeField] public AudioClip fireSound;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public Camera playerCamera;
    [SerializeField] public Inventory Inventory;
    #endregion

    #region Патроны
    [SerializeField] public int ammoInWeapon;
    [SerializeField] private int maxAmmoInWeapon;
    [SerializeField] public int ammoInInventory;
    [SerializeField] private int maxAmmoInInventory;
    #endregion

    private float nextFire;

    private void Awake()
    {
        playerCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if(ammoInWeapon == 0)
        {
            isActive = false;
        }

        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && isActive)
        {
            nextFire = Time.time + fireRate; 
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && gameObject.transform.parent != null)
        {
            StartCoroutine(RealoadWeapon());
        }

        GetAmmo();
    }

    public void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.gameObject.GetComponent<Zombie>().healthPointZ -= damage;
            }
        }

        ammoInWeapon--;

        fireParticle.Play();
        audioSource.Play();
    }

    private void Reloading()
    {
        if (maxAmmoInWeapon == ammoInWeapon)
            return;

        if (ammoInInventory == 0)
            return;

        if (ammoInInventory >= maxAmmoInWeapon)
        {
            Inventory.Ammonation[typeWeapon] -= maxAmmoInWeapon - ammoInWeapon;
            ammoInWeapon = maxAmmoInWeapon;
        }
        else
        {
            ammoInWeapon += ammoInInventory;
            Inventory.Ammonation[typeWeapon] = 0;
        }
    }

    private IEnumerator RealoadWeapon()
    {
        isActive = false;
        Reloading();
        transform.position -= new Vector3(0, 10f,0);
        yield return new WaitForSeconds(reload);
        transform.position = transform.parent.transform.position;
        isActive = true;
    }

    public void GetAmmo()
    {
        ammoInInventory = Inventory.Ammonation[typeWeapon];
    }
}
