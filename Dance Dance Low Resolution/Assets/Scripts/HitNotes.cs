using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNotes : MonoBehaviour
{
    SpriteCycle spriteCycler;

    [SerializeField]
    GameObject[] lastNotes;

    [SerializeField]
    GameObject[] hitSprites;

    [SerializeField]
    GameObject[] missSprites;

    [SerializeField]
    GameObject[] hitSpaces;

    [SerializeField]
    int[] hitsPerMultiplier = new int[3];

    [SerializeField]
    DancingLimb[] dancingLimbs;

    public float tickTime = 1;

    int score = 0;

    [SerializeField]
    int scorePerHit = 5;
    
    [SerializeField]
    int yellowIndex = 0;
    [SerializeField]
    int greenIndex = 1;
    [SerializeField]
    int redIndex = 2;
    [SerializeField]
    int blueIndex = 3;

    int consecutiveHits = 0;
    [SerializeField]
    int health = 3;

    int multiplier = 1;

    float timer = 0;

    bool[] hitKeys = new bool[4];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hitKeys.Length; i++)
        {
            hitKeys[i] = false;
        }
        spriteCycler = FindObjectOfType<SpriteCycle>();
        tickTime = spriteCycler.tickTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitKeys[yellowIndex])
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
            {
                hitKeys[yellowIndex] = true;
                hitSpaces[yellowIndex].SetActive(false);
                dancingLimbs[yellowIndex].MakeManDance();
                if (lastNotes[yellowIndex].activeInHierarchy)
                {
                    //Do good hit stuff

                    //Set good hit sprites on for a little
                    //Add score
                    //Make guy dance
                    //Add to multiplier progress

                    ActivateHitSprites(true, yellowIndex);
                    AddScore();
                    consecutiveHits++;
                }
                else
                {
                    //Do bad hit stuff

                    //Set bad hit sprites on for a little
                    //Reset multiplier

                    ActivateHitSprites(false, yellowIndex);
                    RemoveHealth();
                    consecutiveHits = 0;
                }
            }
        }

        if (!hitKeys[greenIndex])
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
            {
                hitKeys[greenIndex] = true;
                hitSpaces[greenIndex].SetActive(false);
                dancingLimbs[greenIndex].MakeManDance();
                if (lastNotes[greenIndex].activeInHierarchy)
                {
                    //Do good hit stuff

                    //Set good hit sprites on for a little
                    //Add score
                    //Make guy dance
                    //Add to multiplier progress

                    ActivateHitSprites(true, greenIndex);
                    AddScore();
                    consecutiveHits++;
                }
                else
                {
                    //Do bad hit stuff

                    //Set bad hit sprites on for a little
                    //Reset multiplier

                    ActivateHitSprites(false, greenIndex);
                    RemoveHealth();
                    consecutiveHits = 0;
                }
            }
        }

        if (!hitKeys[redIndex])
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                hitKeys[redIndex] = true;
                hitSpaces[redIndex].SetActive(false);
                dancingLimbs[redIndex].MakeManDance();
                if (lastNotes[redIndex].activeInHierarchy)
                {
                    //Do good hit stuff

                    //Set good hit sprites on for a little
                    //Add score
                    //Make guy dance
                    //Add to multiplier progress

                    ActivateHitSprites(true, redIndex);
                    AddScore();
                    consecutiveHits++;
                }
                else
                {
                    //Do bad hit stuff

                    //Set bad hit sprites on for a little
                    //Reset multiplier

                    ActivateHitSprites(false, redIndex);
                    RemoveHealth();
                    consecutiveHits = 0;
                }
            }
        }

        if (!hitKeys[blueIndex])
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                hitKeys[blueIndex] = true;
                hitSpaces[blueIndex].SetActive(false);
                dancingLimbs[blueIndex].MakeManDance();
                if (lastNotes[blueIndex].activeInHierarchy)
                {
                    //Do good hit stuff

                    //Set good hit sprites on for a little
                    //Add score
                    //Make guy dance
                    //Add to multiplier progress

                    ActivateHitSprites(true, blueIndex);
                    AddScore();
                    consecutiveHits++;
                }
                else
                {
                    //Do bad hit stuff

                    //Set bad hit sprites on for a little
                    //Reset multiplier

                    ActivateHitSprites(false, blueIndex);
                    RemoveHealth();
                    consecutiveHits = 0;
                }
            }
        }


        UpdateMultiplier();

    }


    void UpdateMultiplier()
    {
        if (consecutiveHits >= hitsPerMultiplier[2])
        {
            multiplier = 8;
        }
        else if (consecutiveHits >= hitsPerMultiplier[1])
        {
            multiplier = 4;
        }
        else if (consecutiveHits >= hitsPerMultiplier[0])
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

    void ActivateHitSprites(bool hit, int index)
    {
        if (hit)
        {
            hitSprites[index].SetActive(true);
            missSprites[index].SetActive(true);
        }
        else
        {
            missSprites[index].SetActive(true);
        }
    }

    public void ResetHitKeys()
    {
        for (int i = 0; i < hitKeys.Length; i++)
        {
            hitKeys[i] = false;
        }
    }

    public void ResetHitSpaces()
    {
        for (int i = 0; i < hitSpaces.Length; i++)
        {
            hitSpaces[i].SetActive(true);
        }
    }

    public void DisableThumperEffectSprites()
    {
        for (int i = 0; i < hitSprites.Length; i++)
        {
            hitSprites[i].SetActive(false);
            missSprites[i].SetActive(false);
        }
    }

    void DisplayScore()
    {

    }

    void AddScore()
    {
        score += scorePerHit * multiplier;
    }
}
