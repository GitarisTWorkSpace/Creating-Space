using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Note : MonoBehaviour
{
    [SerializeField] public GameObject NotePanel;
    [SerializeField] public bool isActive = false;
    [SerializeField] public TMP_Text NoteText;
    [SerializeField] [TextArea(4,6)] public string text;

    private void Awake()
    {
        NoteText.text = text;
    }

    public void Read()
    {
        if (!isActive)
        {
            NotePanel.SetActive(true);
            isActive = true;
        }
        else if (isActive)
        {
            NotePanel.SetActive(false);
            isActive = false;
        }

        Time.timeScale = isActive ? 0f : 1f;
    }

    public void Close(bool value)
    {
        isActive = false;
        Read();
    }
}
