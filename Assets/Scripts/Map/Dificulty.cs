using UnityEngine;

public class Dificulty
{
    private int[] CountZombie;
    private int[] IndexSpaner;

    private int DificultyWave;

    public void GetDificulty(int dificulty, int waveCount)
    {
        
    }

    private void Easy()
    {
        CountZombie = new int[3] { 4, 10, 15 };
        IndexSpaner = new int[3] { 1, 0, 2};
    }
}
