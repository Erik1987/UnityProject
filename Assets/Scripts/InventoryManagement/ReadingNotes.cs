using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class ReadingNotes : MonoBehaviour
{

    public GameObject storyNote;
    public GameObject storyNote1;
    public GameObject storyNote2;
    public GameObject storyNote3;
    public GameObject storyNote4;
    public GameObject controlsNote;

    private static bool note0hasBeenRead = false;
    private static bool note1hasBeenRead = false;
    private static bool note2hasBeenRead = false;
    private static bool note3hasBeenRead = false;
    private static bool note4hasBeenRead = false;
    private static bool ctrlshasBeenRead = false;


    void Start()
    {
    
    }

    void Update()
    {

        Close();

    }

     private void OnTriggerEnter2D(Collider2D other)
       {
        if (other.CompareTag("StoryNote") ||
            other.CompareTag("StoryNote1") ||
            other.CompareTag("StoryNote2") ||
            other.CompareTag("StoryNote3") ||
            other.CompareTag("StoryNote4") ||
            other.CompareTag("CtrlsNote"))
        {
            GameObject[] enemies = FindObjectsOfType<GameObject>().Where(s => s.scene == SceneManager.GetActiveScene()).Where(s => s.name.Contains("Enemy") && !s.name.Contains("Spawn")).ToArray();
            if (!enemies.Any())
            {
                if (other.CompareTag("StoryNote"))
                {
                    storyNote.SetActive(true);
                    note0hasBeenRead = true;
                    Time.timeScale = 0f;
                    FindObjectOfType<AudioManager>().Play("notepickup");
                }
                if (other.CompareTag("StoryNote1"))
                {
                    storyNote1.SetActive(true);
                    note1hasBeenRead = true;
                    Time.timeScale = 0f;
                    FindObjectOfType<AudioManager>().Play("notepickup");
                }
                if (other.CompareTag("StoryNote2"))
                {
                    storyNote2.SetActive(true);
                    note2hasBeenRead = true;
                    Time.timeScale = 0f;
                    FindObjectOfType<AudioManager>().Play("notepickup");
                }
                if (other.CompareTag("StoryNote3"))
                {
                    storyNote3.SetActive(true);
                    note3hasBeenRead = true;
                    Time.timeScale = 0f;
                    FindObjectOfType<AudioManager>().Play("notepickup");
                }
                if (other.CompareTag("StoryNote4"))
                {
                    storyNote4.SetActive(true);
                    note4hasBeenRead = true;
                    Time.timeScale = 0f;
                    FindObjectOfType<AudioManager>().Play("notepickup");
                }
                if (other.CompareTag("CtrlsNote"))
                {
                    controlsNote.SetActive(true);
                    ctrlshasBeenRead = true;
                    Time.timeScale = 0f;
                    FindObjectOfType<AudioManager>().Play("notepickup");
                }
            }
        }
    }

    private void Close()
    {
       if (Input.GetKeyDown(KeyCode.X) && note0hasBeenRead == true && storyNote.activeSelf == true)
        {
            storyNote.SetActive(false);
            Time.timeScale = 1f;
            Destroy(GameObject.FindGameObjectWithTag("StoryNote"));
            FindObjectOfType<AudioManager>().Play("notepickup");
        }
       if (Input.GetKeyDown(KeyCode.X) && note1hasBeenRead == true && storyNote1.activeSelf == true)
        {
            storyNote1.SetActive(false);
            Time.timeScale = 1f;
            Destroy(GameObject.FindGameObjectWithTag("StoryNote1"));
            FindObjectOfType<AudioManager>().Play("notepickup");
        }
       if (Input.GetKeyDown(KeyCode.X) && note2hasBeenRead == true && storyNote2.activeSelf == true)
        {
            storyNote2.SetActive(false);
            Time.timeScale = 1f;
            Destroy(GameObject.FindGameObjectWithTag("StoryNote2"));
            FindObjectOfType<AudioManager>().Play("notepickup");
        }
       if (Input.GetKeyDown(KeyCode.X) && note3hasBeenRead == true && storyNote3.activeSelf == true)
        {
            storyNote3.SetActive(false);
            Time.timeScale = 1f;
            Destroy(GameObject.FindGameObjectWithTag("StoryNote3"));
            FindObjectOfType<AudioManager>().Play("notepickup");
        }
       if (Input.GetKeyDown(KeyCode.X) && note4hasBeenRead == true && storyNote4.activeSelf == true)
        {
            storyNote4.SetActive(false);
            Time.timeScale = 1f;
            Destroy(GameObject.FindGameObjectWithTag("StoryNote4"));
            FindObjectOfType<AudioManager>().Play("notepickup");
        }
        if (Input.GetKeyDown(KeyCode.X) && ctrlshasBeenRead == true && controlsNote.activeSelf == true)
        {
            controlsNote.SetActive(false);
            Time.timeScale = 1f;
            Destroy(GameObject.FindGameObjectWithTag("CtrlsNote"));
            FindObjectOfType<AudioManager>().Play("notepickup");
        }

    }

}
