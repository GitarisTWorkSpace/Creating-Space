using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public GameObject HUD;

    public float healthPoint = 100f; // Кол-во здаровья игрока 

    [SerializeField] private float maxHealthPoint = 100f; // Максимальное здоровье игрока

    private void Start()
    {
        SendInformation();
    }

    public void GetDamage(float damage)
    {
        healthPoint -= damage;
        SendInformation();
    }

    public void GetHealing(float health)
    {
        healthPoint += health;
        if (healthPoint > maxHealthPoint) healthPoint = maxHealthPoint;
        SendInformation();
    }

    private void DeadScrin()
    {
        if(healthPoint <= 0)
        {
            healthPoint = 0;
            HUD.GetComponent<HeadUpDisplay>().ActiveDeadScrin(!true);
            healthPoint = maxHealthPoint;
        }
    }

    private void Update()
    {
        DeadScrin();
    }

    private void SendInformation()
    {
        HUD.GetComponent<HeadUpDisplay>().GetHealthInformation(healthPoint);
    }
}
