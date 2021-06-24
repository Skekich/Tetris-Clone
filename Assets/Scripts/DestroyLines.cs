using System.Runtime.InteropServices;
using UnityEngine;

public class DestroyLines : MonoBehaviour
{
    [SerializeField] private GridScriptableObject gridObject;
    [SerializeField] private GameEvent rowsDeleted;
    [SerializeField] private GameEvent calulateScore;

    private bool isFull = false;
    
    private void Update()
    {
        if (!isFull) return;
        CheckForFullRow();
        calulateScore.Invoke();
        isFull = false;
    }
    
    public void IsFull()
    {
        isFull = true;
    }
    
    private void CheckForFullRow()
    {
        for (var i = gridObject.playgroundSize.height - 1 ; i >= 0 ; --i)
        {
            if (RowFull(i))
            {
                DeletedRow(i);
                RowDown(i);
            }
        }
    }

    private void RowDown(int width)
    {
        for (var y = width; y < gridObject.playgroundSize.height; y++)
        {
            for (var j = 0; j < gridObject.playgroundSize.width; j++)
            {
                if (gridObject.PlaygroundGrid[j, y] == null) continue;
                gridObject.PlaygroundGrid[j, y - 1] = gridObject.PlaygroundGrid[j, y];
                gridObject.PlaygroundGrid[j, y] = null;
                gridObject.PlaygroundGrid[j, y - 1].position += Vector3.down;
            }
        }
    }

    private void DeletedRow(int height)
    {
        for (var j = 0; j < gridObject.playgroundSize.width; ++j)
        {
            Destroy(gridObject.PlaygroundGrid[j, height].gameObject);
            gridObject.PlaygroundGrid[j, height] = null;
        }
        rowsDeleted.Invoke();
    }

    private bool RowFull(int height)
    {
        for (var j = 0; j < gridObject.playgroundSize.width; ++j)
        {
            if (gridObject.PlaygroundGrid[j, height] == null)
            {
                return false;
            }
        }
        return true;
    }
}