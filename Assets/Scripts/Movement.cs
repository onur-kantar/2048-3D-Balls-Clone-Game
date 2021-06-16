using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameManager.isGameOver)
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            if (clickPos.x < -Constants.MAX_MIN_MOVEMENT_DISTANCE || clickPos.x > Constants.MAX_MIN_MOVEMENT_DISTANCE)
            {
                clickPos.x = (clickPos.x / Mathf.Abs(clickPos.x)) * Constants.MAX_MIN_MOVEMENT_DISTANCE;
            }
            transform.position = new Vector3(clickPos.x, transform.position.y, transform.position.z);
        }
    }
}
