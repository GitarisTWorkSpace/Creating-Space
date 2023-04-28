using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public float healthPoint = 100f; // Кол-во здаровья игрока 
    [SerializeField] private float maxHealthPoint = 100f; // Максимальное здоровье игрока
    public GameObject HUD;

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
        SendInformation();
    }

    private void SendInformation()
    {
        HUD.GetComponent<HeadUpDisplay>().GetHealthInformation(healthPoint);
    }

    private void Update()
    {
        if(healthPoint > maxHealthPoint) healthPoint = maxHealthPoint;
    }
}
