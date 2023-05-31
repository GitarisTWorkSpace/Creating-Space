using UnityEngine;

public class MainSettings : MonoBehaviour
{
    [SerializeField] public string difficulty;

    public void SwichDifficulty(int value)
    {
        switch (value)
        {
            case 0: difficulty = "Easy"; break;
            case 1: difficulty = "Medium"; break;
            case 2: difficulty = "Hard"; break;

            default: difficulty = "Easy"; break;
        }
    }
}
