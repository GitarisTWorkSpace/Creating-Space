using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] [TextArea(4,6)] public string HeaderText;
    [SerializeField] [TextArea(4,6)] public string MainText;
}
