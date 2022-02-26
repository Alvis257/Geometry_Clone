using Assets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrriger : MonoBehaviour
{
    private Geometry geometry;

    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}