using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Header("Controls")]
    Movement playerMovement;
    bool isTransitioning = false;

    [Header("Particles")]
    public ParticleSystem Confeti;
    public ParticleSystem BOOM;

    private void Start()
    {
        playerMovement = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Fuel":
                Debug.Log("Fuel Pickup");
                break;
            case "Finish":
                FinishLevel();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        if (!isTransitioning)
        {
            BOOM.Play();
            isTransitioning = true;
            playerMovement.audio.PlayOneShot(playerMovement.Crash);

            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", 1f);
        }
    }

    void FinishLevel()
    {
        if (!isTransitioning)
        {
            Confeti.Play();
            isTransitioning = true;
            playerMovement.audio.PlayOneShot(playerMovement.GoalPoint);

            GetComponent<Movement>().enabled = false;
            Invoke("LoadNextLevel", 2f);
        }
    }

    void ReloadLevel()
    {
        int CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        isTransitioning = false;
        SceneManager.LoadScene(CurrentLevel);
    }

    void LoadNextLevel()
    {
        GetComponent<Movement>().enabled = false;
        isTransitioning = false;
        int NextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (NextLevel == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(NextLevel);
    }
}
