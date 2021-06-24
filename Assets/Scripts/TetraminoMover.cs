using System.Runtime.InteropServices;
using UnityEngine;

public class TetraminoMover : MonoBehaviour
{
    [SerializeField] private float timeToSlideDown = 2f;
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private GridScriptableObject gridObject;

    private Boundries boundries;
    private Rotation rotation;
    private float timer;
    private bool isTriggered = false;

    private void Start()
    {
        boundries = GetComponent<Boundries>();
        rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (!boundries.ValidMove())
            {
                transform.position -= Vector3.left;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (!boundries.ValidMove())
            {
                transform.position -= Vector3.right;
            }
        }

        if (!(Time.time - timer > (Input.GetKey(KeyCode.DownArrow) ? timeToSlideDown / 5 : timeToSlideDown))) return;
        transform.position += Vector3.down;
        if (!boundries.ValidMove())
        {
            transform.position -= Vector3.down;
            if (!isTriggered)
            {
                gameEvent.Invoke();
                isTriggered = true;
            }
            AddToGrid();
            ScriptDisabler();
        }
        timer = Time.time;
    }

    private void ScriptDisabler()
    {
        enabled = false;
        rotation.enabled = false;
    }

    private void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            var position = children.transform.position;
            var roundX = Mathf.RoundToInt(position.x);
            var roundY = Mathf.RoundToInt(position.y);

            gridObject.PlaygroundGrid[roundX, roundY] = children;
        }
    }
    

}
