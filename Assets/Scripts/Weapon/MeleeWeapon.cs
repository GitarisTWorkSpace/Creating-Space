using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IMeleeWeapon
{
    #region Характеристики
    [SerializeField] public float damage;
    [Header("Range in units")]
    [SerializeField] public float range;
    [Header("Fire Rate in 0.second")]
    [SerializeField] public float fireRate;
    [SerializeField] public int typeWeapon;
    public bool inHand = false;
    private float nextFire;
    #endregion

    #region Объекты
    [SerializeField] public ParticleSystem BloodParticle;
    [SerializeField] public Animator Animator;
    [SerializeField] public AudioClip FireSound;
    [SerializeField] public AudioSource AudioSource;
    [SerializeField] public Camera PlayerCamera;
    #endregion
    public void GetObjacts()
    {
        PlayerCamera = FindAnyObjectByType<Camera>();
        AudioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        GetObjacts();
    }

    public void Damage(float damage, float range)
    {
        RaycastHit hit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, range))
        {
            //Debug.Log("Попал в " + hit.transform.gameObject.name);
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.gameObject.GetComponent<Zombie>().healthPointZ -= damage;
                BloodParticle.Play();
                AudioSource.Play();
            }
        }
    }

    private void Update()
    {
        inHand = transform.parent != null;
        if (Input.GetMouseButtonDown(0) && inHand && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Damage(damage, range);
        }
    }
}
