using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    [SerializeField] private GameObject NextStep;
    [SerializeField] private GameObject HUD;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if (NextStep != null) NextStep.SetActive(true);
            else if (NextStep == null)
            {
                //HUD.GetComponent<HeadUpDisplay>().ActiveDeadScrin(!true);
            }

            Destroy(gameObject);
        }
    }
}
