using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    public GameObject MeteorPrefab;
    public float spawnRate;
    public float spawnStart;

    Vector2 min;
    Vector2 max;

    // Start is called before the first frame update
    void Start()
    {

        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        InvokeRepeating("SpawnMeteor", spawnStart, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnMeteor()
    {
        float meteorExtentsX = MeteorPrefab.GetComponent<Renderer>().bounds.extents.x;
        float meteorExtentsY = MeteorPrefab.GetComponent<Renderer>().bounds.extents.y;

        float randomX = Random.Range(min.x + meteorExtentsX, max.x - meteorExtentsX);
        Vector2 randomPosition = new Vector2(randomX, max.y + meteorExtentsY);
        GameObject Meteor = Instantiate(MeteorPrefab, randomPosition, Quaternion.identity);
        Meteor.GetComponent<MeteorController>().meteorSpeed = Random.Range(minSpeed, maxSpeed);
    }
}
