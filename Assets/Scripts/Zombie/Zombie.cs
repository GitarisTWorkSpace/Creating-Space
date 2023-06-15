using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator anim;

    [SerializeField] public float healthPointZ = 150f;
    [SerializeField] public float damage;
    [SerializeField] private float deathTime = 2f;
    public Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = FindAnyObjectByType<Inventory>().GetComponent<Transform>();
    }

    void Update()
    {
        if (healthPointZ <= 0){
            navMeshAgent.isStopped = true;
            gameObject.transform.rotation = Quaternion.AngleAxis(90f,transform.position);
            Destroy(gameObject, deathTime);
        }

        navMeshAgent.SetDestination(target.position);
    }
}
