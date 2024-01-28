using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightlyRandomScale : MonoBehaviour
{
    void Start()
    {
        transform.localScale = new Vector3(
            Random.Range(0.8f, 1.2f),
            Random.Range(0.8f, 1.2f),
            Random.Range(0.8f, 1.2f)
        );
    }
}
