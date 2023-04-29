using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Note : MonoBehaviour
{
    public string noteTextstr;
    public GameObject notice;
    public GameObject noteUI;
    public Text text;

    private void OnTriggerStay(Collider other)
    {

        Debug.Log("Записка");
        text.text = noteTextstr;
        if (Input.GetKeyDown(KeyCode.E))
        {
            noteUI.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            noteUI.SetActive(false);
        }
        notice.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        notice.SetActive(false);
        noteUI.SetActive(false);
    }
}
