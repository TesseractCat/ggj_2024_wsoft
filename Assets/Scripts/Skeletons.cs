using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletons : MonoBehaviour
{
    void Start()
    {
        foreach (Animator a in GetComponentsInChildren<Animator>()) {
            a.Play("Base Layer.Idle", 0, Random.value);
        }
    }

    public void Jump()
    {
        foreach (Animator a in GetComponentsInChildren<Animator>()) {
            StartCoroutine(RandomJump(a));
        }
    }

    IEnumerator RandomJump(Animator a) {
        yield return new WaitForSeconds(Random.value * 0.2f);
        a.Play("Base Layer.Jump", 0, Random.value);
    }
}
