using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float healthPoint = 100f; // Кол-во здоровья игрока 
    [SerializeField] private float maxHealthPoint = 100f; // Максимальное здоровье игрока

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
    }

    public void TakeHealing(float health)
    {
        healthPoint += health;
        if (healthPoint > maxHealthPoint) healthPoint = maxHealthPoint;
    }

    private void PlayerDead()
    {
        if(healthPoint <= 0) healthPoint = 0;
    }
}
