using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMngr : MonoBehaviour
{
    public int combo;

    public List<GameObject> lights;

    void Start()
    {
        ChangeCombos();
    }

    void Update()
    {
        
    }

    void ChangeCombos()
    {
        int combos = Random.Range(0, 3);
        switch (combos)
        {
            case 0:
                lights[4].SetActive(true);
                lights[3].SetActive(true);
                break;
        }
    }
}
