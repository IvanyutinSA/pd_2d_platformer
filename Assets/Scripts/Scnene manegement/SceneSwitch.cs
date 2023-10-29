using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] LayerMask playerLayerMask;
    public string sceneName;
    string GetSceneName()
    {
        if (sceneName.Length > 0)
        {
            return sceneName;
        }
        return name.Substring(2);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.transform.tag == "Player")
        {
            SceneManager.LoadScene(GetSceneName());
        }
    }
}
