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
            // combo 0 = yellow + red, black + blue
            case 0:
                lights[1].SetActive(true);
                lights[2].SetActive(false);
                lights[3].SetActive(true);
                lights[4].SetActive(false);
                break;
            // combo 1 = black + red, yellow + blue
            case 1:
                lights[1].SetActive(false);
                lights[2].SetActive(true);
                lights[3].SetActive(true);
                lights[4].SetActive(false);
                break;
            // combo 2 = blue + red, yellow + black
            case 2:
                lights[1].SetActive(false);
                lights[2].SetActive(false);
                lights[3].SetActive(true);
                lights[4].SetActive(true);
                break;
        }
    }
}
