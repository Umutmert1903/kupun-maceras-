using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
           sceneLoader.LoadScene();
        }
    }
}
