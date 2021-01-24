using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNotes : MonoBehaviour
{
    [SerializeField]
    GameObject[] lastNotes;

    [SerializeField]
    int[] hitsPerMultiplier = new int[3];

    int score = 0;

    [SerializeField]
    int scorePerHit = 5;

    int consecutiveHits = 0;
    [SerializeField]
    int health = 3;

    int multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
        {
            if (lastNotes[0].activeInHierarchy)
            {
                //Do good hit stuff

                //Set good hit sprites on for a little
                //Add score
                //Make guy dance
                //Add to multiplier progress

                AddScore();
                consecutiveHits++;
            }
            else
            {
                //Do bad hit stuff

                //Set bad hit sprites on for a little
                //Reset multiplier

                RemoveHealth();
                consecutiveHits = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (lastNotes[1].activeInHierarchy)
            {
                //Do good hit stuff
            }
            else
            {
                //Do bad hit stuff
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (lastNotes[2].activeInHierarchy)
            {
                //Do good hit stuff
            }
            else
            {
                //Do bad hit stuff
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (lastNotes[3].activeInHierarchy)
            {
                //Do good hit stuff
            }
            else
            {
                //Do bad hit stuff
            }
        }



        UpdateMultiplier();

    }

    void UpdateMultiplier()
    {
        if (consecutiveHits >= hitsPerMultiplier[3])
        {
            multiplier = 8;
        }
        else if (consecutiveHits >= hitsPerMultiplier[2])
        {
            multiplier = 4;
        }
        else if (consecutiveHits >= hitsPerMultiplier[1])
        {
            multiplier = 2;
        }
        else
        {
            multiplier = 1;
        }
    }

    void RemoveHealth()
    {
        health--;
        //Set heart sprite inactive
    }

    void DisplayScore()
    {

    }

    void AddScore()
    {
        score += scorePerHit * multiplier;
    }
}
