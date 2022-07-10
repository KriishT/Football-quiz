using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sequences : MonoBehaviour
{
    [SerializeField] AudioClip Winsound;
    [SerializeField] AudioClip Wrongsound;
    [SerializeField] GameObject teleporter;
    [SerializeField] GameObject teleporter2;
    Transform trnsfrm;

    void Start()
    {
        trnsfrm = GetComponent<Transform>();   
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Teleporter")
        {
            Teleportsequnce();
        }

        if (collision.gameObject.tag == "Teleporter2")
        {
            Teleport2sequnce();
        }

        Sequences(collision);
    }
    private void Sequences(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Correct":
                Winsequence();
                break;

            case "Wrong":
                Wrongsequence();
                break;

            case "Teleporter":
                
                break;
        }
    }


    void Wrongsequence()
    {
        GetComponent<AudioSource>().PlayOneShot(Wrongsound);
    }
    void Winsequence()
    {
        Invoke("NextLevel", 3f);
        GetComponent<AudioSource>().PlayOneShot(Winsound);
    }

    void NextLevel()
    {
        int currentsceneiIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentsceneiIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void LevelRestart()
    {
        int currentsceneiIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneiIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WorldEnd")
        {
            LevelRestart();
        }
    }

    void Teleport2sequnce()
    {
        trnsfrm.position = teleporter2.transform.position;
    }
    void Teleportsequnce()
    {
        trnsfrm.position = teleporter.transform.position;
    }
}
