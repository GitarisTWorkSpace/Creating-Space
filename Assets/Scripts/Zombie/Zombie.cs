using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] public Difficulty difficulty = new Difficulty();
    [SerializeField] public string difficult;
    [SerializeField] public float healthPointZ = 150f;
    [SerializeField] public float damage = 5f;
    [SerializeField] public float fireRate = 3f;
    [SerializeField] private float deathTime = 2f;

    private void Awake()
    {
        difficult = FindObjectOfType<MainSettings>().difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        damage = difficulty.ZombieDamage(difficult);
        if (healthPointZ <= 0){
            Destroy(gameObject, deathTime);
        }
    }
}
