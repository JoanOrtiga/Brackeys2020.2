using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackTrackGrid : MonoBehaviour
{
    [SerializeField] private Vector2 gridSize;

    private static Grid grid;

    [SerializeField] private BackTrackingBox[] backTrackObjects;

    [SerializeField] private bool isBackTracking;

    private CountDownTimer countDownTimer;

    [SerializeField] private float timeScaled = 0.8f;

    private void Awake()
    {
        grid = GetComponent<Grid>();

        backTrackObjects = new BackTrackingBox[GameObject.FindObjectsOfType(typeof(BackTrackingBox)).Length];

        int index = 0;

        foreach (BackTrackingBox item in GameObject.FindObjectsOfType<BackTrackingBox>())
        {
            backTrackObjects[index] = item;
            index++;
        }

        isBackTracking = false;
    }
    public void Start()
    {
        countDownTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<CountDownTimer>();

        countDownTimer.timeAt0.AddListener(StartBackTracking);
    }

    private void StartBackTracking()
    {
        Time.timeScale = timeScaled;

        isBackTracking = true;
    }

    private void Update()
    {
        if (isBackTracking)
        {
            if(CheckAllBackTrackingObjects() == false)
            {
                countDownTimer.countingDown = true;
                isBackTracking = false;

                Time.timeScale = 1f;
            }
        }
    }

    public static Vector2 GetNearestPointOnGrid(Vector2 position)
    {
        //We find nearest point where position can attach to.
        int xCount = Mathf.RoundToInt(position.x / grid.cellSize.x);
        int yCount = Mathf.RoundToInt(position.y / grid.cellSize.y);

        Vector3 result = new Vector2(xCount * grid.cellSize.x, yCount * grid.cellSize.y);

        return result;
    }


    private bool CheckAllBackTrackingObjects()
    {
        foreach (BackTrackingBox item in backTrackObjects)
        {
            if (item.isBackTracking())
            {
                return true;
            }
        }

        return false;
    }
}
