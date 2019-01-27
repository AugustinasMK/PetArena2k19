using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopSpawner : MonoBehaviour
{

    public float xFrom;
    public float xTo;

    public GameObject poopPrefab;

    public GameObject caster;

    public void EnableSpawner(GameObject caster)
    {
        StartCoroutine("Spawn");
        this.caster = caster;
    }

    public void DisableSpawner()
    {
        StopCoroutine("Spawn");
    }

    public IEnumerator Spawn()
    {
        for (; ; )
        {
            GameObject poopGO = Instantiate(poopPrefab, new Vector2(Random.Range(xFrom, xTo), 15f), Quaternion.identity);
          
            yield return new WaitForSeconds(0.1f);
        }
    }
}
