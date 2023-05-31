using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] public Difficulty difficulty = new Difficulty();
    [SerializeField] public GameObject Wave;
    [SerializeField] public string difficult;
    [SerializeField] public float healthPointZ = 150f;
    [SerializeField] public float damage = 5f;
    [SerializeField] public float fireRate = 3f;
    [SerializeField] private float deathTime = 2f;
    [SerializeField] private NavMeshAgent navMeshAgent;
    public Transform target;

    private void Awake()
    {
        difficult = FindObjectOfType<MainSettings>().difficulty;
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindAnyObjectByType<Inventory>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        damage = difficulty.ZombieDamage(difficult);
        if (healthPointZ <= 0){
            if (Wave != null) Wave.GetComponent<Wave>().countZombie--;
            navMeshAgent.isStopped = true;
            gameObject.transform.rotation = Quaternion.AngleAxis(90f,transform.position);
            Destroy(gameObject, deathTime);
        }

        navMeshAgent.SetDestination(target.position);
    }
}
