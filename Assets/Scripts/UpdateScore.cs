using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private GameEvent audioEvent;
    
    private TextMeshProUGUI textToUpdate;
    private int initialScore = 0;
    private int currentScore;
    private int oneLineMultiplier = 100;
    private int twoLineMultiplier = 400;
    private int threeLineMultiplier = 1000;
    private int fourLineMultiplier = 3000;
    private int counter = 0;
    private void Start()
    {
        textToUpdate = GetComponent<TextMeshProUGUI>();
        currentScore = initialScore;
        textToUpdate.SetText("Score: {0}", initialScore);
    }

    public void ScoreCounter()
    {
        counter++;
    }
    
    public void ScoreUpdater()
    {
        switch (counter)
        {
            case 4:
                Score(fourLineMultiplier);
                break;
            case 3:
                Score(threeLineMultiplier);
                break;
            case 2:
                Score(twoLineMultiplier);
                break;
            case 1:
               Score(oneLineMultiplier);
                break;
            default:
                break;
        }
    }

    private void Score(int multipler)
    {
        currentScore = currentScore + multipler;
        textToUpdate.SetText("Score: {0}", currentScore);
        audioEvent.Invoke();
        counter = 0;
    }
}
