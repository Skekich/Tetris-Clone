using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GridSO", fileName = "new grid")]
public class GridScriptableObject : ScriptableObject
{
    public PlaygroundSize playgroundSize;
    private Transform[,] grid;

    private void OnEnable()
    {
        grid = new Transform[playgroundSize.width, playgroundSize.height];
    }

    public Transform[,] PlaygroundGrid
    {
        get => grid;
        set => grid = value;
    }
    
}
