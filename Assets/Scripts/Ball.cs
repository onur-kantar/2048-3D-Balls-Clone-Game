using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject mergePS;
    public BallCreator owner;
    public BallProperties ballProperties;
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateView();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (owner.lastBall == gameObject)
        {
            owner.CreateBall();
        }
        if (collision.gameObject.CompareTag("Ball") && ballProperties.Id > collision.gameObject.GetComponent<Ball>().ballProperties.Id)
        {
            if (collision.gameObject.GetComponent<Ball>().ballProperties.Power == ballProperties.Power)
            {
                owner.ballList.Remove(collision.gameObject);
                Destroy(collision.gameObject);
                ballProperties.UpdateProperties();
                Instantiate(mergePS, transform.position, Quaternion.identity);
                if (ballProperties.Power == Constants.MAX_POWER)
                {
                    owner.ballList.Remove(gameObject);
                    Destroy(gameObject);
                    owner.gameManager.IncreasesScore();
                    return;
                }
                UpdateView();
            }
            else
            {
                owner.gameManager.HasViolation(transform.position.y);
            }
        }
    }
    void UpdateView()
    {
        GetComponentInChildren<TextMeshPro>().text = ballProperties.Value.ToString();
        transform.localScale = ballProperties.Size;
        rend.material.color = ballProperties.Color;
    }
}
