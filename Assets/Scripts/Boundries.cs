using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{
    [SerializeField] private PlaygroundSize playgroundSize;
    [SerializeField] private GridScriptableObject gridObject;

    public bool ValidMove()
        {
            foreach (Transform children in transform)
            {
                var position = children.transform.position;
                var roundX = Mathf.RoundToInt(position.x);
                var roundY = Mathf.RoundToInt(position.y);
                
                if(roundX < 0 || roundX >= playgroundSize.width || roundY < 0 || roundY >= playgroundSize.height)
                {
                    return false;
                }

                if (gridObject.PlaygroundGrid[roundX, roundY] != null)
                {
                    return false;
                } 
            }
            return true;
        }
}
