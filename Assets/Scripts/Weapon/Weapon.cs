using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public Camera playerCamera;
    public Transform spawnBullet;
    public int indexWeapon;
    public int ammo;
    public int ammoInWeapon;
    public int maxAmmoInWeapon;

    [SerializeField] public bool weaponInHand = false;

    [SerializeField] private float shootForce;
    [SerializeField] private float spread;

    private void Shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

        ammoInWeapon--;
    }

    private void Reloading()
    {
        ammo = player.GetComponent<Inventory>().currentWeaponAmmo[indexWeapon];
        if (maxAmmoInWeapon == ammoInWeapon)
            return;

        if (ammo > maxAmmoInWeapon)
        {
            ammo -= maxAmmoInWeapon;
            ammoInWeapon = maxAmmoInWeapon;
        }
        else
        {
            ammoInWeapon = ammo;
            ammo = 0;
        }
    }

    private void Start() 
    {
        ammo = player.GetComponent<Inventory>().currentWeaponAmmo[indexWeapon];
        ammoInWeapon = player.GetComponent<Inventory>().currentAmmoInWeapon[indexWeapon];
        maxAmmoInWeapon = player.GetComponent<Inventory>().maxCurrentAmmoInWeapon[indexWeapon];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && weaponInHand && ammoInWeapon > 0)
        {
            Shoot();
            player.GetComponent<Inventory>().currentAmmoInWeapon[indexWeapon] = ammoInWeapon;
            player.GetComponent<Inventory>().currentWeaponAmmo[indexWeapon] = ammo;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reloading();
        }
    }
}
