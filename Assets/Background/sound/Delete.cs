using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    void Start()
    {
        GameObject.Destroy(GameObject.Find("BGMusic1"));
    }
}
