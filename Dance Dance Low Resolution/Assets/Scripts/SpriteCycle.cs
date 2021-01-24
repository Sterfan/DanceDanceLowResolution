using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCycle : MonoBehaviour
{
    [SerializeField]
    Note[] notes;

    List<GameObject> onNotes = new List<GameObject>();
    List<GameObject> offNotes = new List<GameObject>();
    List<Note> notesInQueue = new List<Note>();

    [SerializeField]
    float tickTime = 1;

    [SerializeField]
    float speedUpTime = 10;

    [SerializeField]
    float acceleration = 0.1f; //Time by which it reduces tick time

    float timer = 0;

    float speedTimer = 0;

    int loops = 0;


    void Awake()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            for (int l = 0; l < notes[i].positions.Length; l++)
            {
                offNotes.Add(notes[i].positions[l]);
            }
        }
    }


    void FixedUpdate()
    {
        timer += Time.deltaTime;
        speedTimer += Time.deltaTime;

        if (timer >= tickTime)
        {
            //do the stuff
            ClearOnNotes();
            //if (loops < 5)
            //{
            //    Debug.Log(loops);
            //    AddNotesToQueue(GenerateNote());
            //    loops++;
            //}
            AddNotesToQueue(GenerateNote());
            AddToOnNotes();
            TurnOnNotes();
            TurnOFFNotes();






            timer = 0;
        }

        //if (speedTimer >= speedUpTime)
        //{
        //    tickTime -= acceleration;
        //}
    }


    Note GenerateNote()
    {
        int noteToSpawn = Random.Range(0, notes.Length);
        return notes[noteToSpawn];
    }

    void AddToOnNotes()
    {
        if (notesInQueue.Count > 0)
        {
            for (int i = notesInQueue.Count - 1; i >= 0; i--)
            {
                if (notesInQueue[i].currentPosition < notesInQueue[i].positions.Length - 1)
                {
                    AddOnNote(notesInQueue[i].positions[notesInQueue[i].currentPosition]);
                    notesInQueue[i].currentPosition++;
                }
                else
                {
                    AddOnNote(notesInQueue[i].positions[notesInQueue[i].currentPosition]);
                    notesInQueue.RemoveAt(i);
                }
            }
        }
    }

    void AddOnNote(GameObject note)
    {
        onNotes.Add(note);
        RemoveFromOffNote(note);
    }

    void RemoveFromOffNote(GameObject note)
    {
        if (offNotes.Count > 0)
        {
            for (int i = 0; i < offNotes.Count; i++)
            {
                if (offNotes[i].Equals(note))
                {
                    offNotes.RemoveAt(i);
                }
            }
        }
    }

    void ClearOnNotes()
    {
        if (onNotes.Count > 0)
        {
            for (int i = onNotes.Count - 1; i >= 0; i--)
            {
                offNotes.Add(onNotes[i]);
                onNotes.RemoveAt(i);
            }
        }
    }

    void AddNotesToQueue(Note notesToAdd)
    {
        notesInQueue.Add(new Note(notesToAdd.positions));
    }

    void TurnOnNotes()
    {
        if (onNotes.Count > 0)
        {
            for (int i = 0; i < onNotes.Count; i++)
            {
                onNotes[i].SetActive(true);
            }
        }
    }
    
    void TurnOFFNotes()
    {
        if (offNotes.Count > 0)
        {
            for (int i = 0; i < offNotes.Count; i++)
            {
                offNotes[i].SetActive(false);
            }
        }
    }
}
