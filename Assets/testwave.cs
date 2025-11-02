using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class testwave : MonoBehaviour
{
    private int waveNum = 1;
    public TextMeshProUGUI NumDisplay;

    private void Update()
    {
        NumDisplay.text = ("Will Start at Wave: " + waveNum);
        DifficultyINcreases.wave = waveNum - 1;
    }

    public void IncreaseWave()
    {
        waveNum += 1;
    }
}
