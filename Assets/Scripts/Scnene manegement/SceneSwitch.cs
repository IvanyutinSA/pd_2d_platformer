using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] LayerMask playerLayerMask;
    int GetSceneId()
    {
        int sceneId = -1;
        for (int i = 0; i < name.Length; i++)
        {
            if (int.TryParse(name[i].ToString(), out sceneId))
            {
                sceneId = int.Parse(name.Substring(i));
                break;
            }
            if (i == name.Length - 1)
            {
                //Application.Quit();
                return 0;
            }
        }
        return sceneId + 1;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //if (collider.gameObject.transform.tag == "Player")
        if (true)
        {
            SceneManager.LoadScene(GetSceneId());
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
