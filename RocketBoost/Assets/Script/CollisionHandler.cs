using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Safe");
                break;
            case "Fuel":
                Debug.Log("Fuel Pickup");
                break;
            case "Finish":
                Debug.Log("Taaaaa Daaaaaaahhhh!");
                FinishLevel();
                break;
            default:
                Debug.Log("Kabooommmmm!!!!");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    void FinishLevel()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 2f);
    }

    void ReloadLevel()
    {
        int CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentLevel);
    }

    void LoadNextLevel()
    {
        GetComponent<Movement>().enabled = false;
        int NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (NextLevel == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(NextLevel);
    }
}
