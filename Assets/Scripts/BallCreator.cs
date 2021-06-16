using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [HideInInspector] public List<GameObject> ballList;
    [HideInInspector] public GameObject lastBall;
    [HideInInspector] public GameManager gameManager;
    BallProperties ballProperties;
    int ballId;
    int maxPower;
    private void Awake()
    {
        ballId = 0;
        maxPower = 1;
        ballList = new List<GameObject>();
        gameManager = GetComponent<GameManager>();
        CreateBall();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            lastBall.GetComponent<Rigidbody>().useGravity = true;
            lastBall.GetComponent<SphereCollider>().isTrigger = false;
            lastBall.transform.parent = null;
        }
    }
    public void CreateBall()
    {
        if (ballList.Any() && maxPower != Constants.MAX_POWER - 1)
        {
            foreach (GameObject ball in ballList)
            {
                if (ball.GetComponent<Ball>().ballProperties.Power > maxPower)
                {
                    maxPower = ball.GetComponent<Ball>().ballProperties.Power;
                }
            }
        }

        int randomPower = Random.Range(1, maxPower + 1);
        ballProperties = new BallProperties(ballId, randomPower);

        lastBall = Instantiate(ball, transform.position, Quaternion.identity);
        lastBall.GetComponent<Ball>().ballProperties = ballProperties;
        lastBall.GetComponent<Ball>().owner = this;
        lastBall.transform.parent = transform;
        ballList.Add(lastBall);
        ballId++;
    }
}
