using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggleSpawner : MonoBehaviour
{
    private Transform a_Transform;
    private Transform spawner_Transform;

    private GameObject juggling_Item;

    void Start()
    {
        a_Transform = gameObject.transform;
        spawner_Transform = a_Transform.Find("Spawner");

        juggling_Item = Resources.Load<GameObject>("Juggling_Pin_Blue");

        StartCoroutine("SpawnerMovement");
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Meant to keep the Spa
    /// </summary>
    private IEnumerator SpawnerMovement()
    {
        for(int i = 0; i < 10; i++)
        {
            spawner_Transform.Translate(new Vector2(100, 0));
            yield return new WaitForSeconds(2.0f);
            Spawn();
            yield return new WaitForSeconds(3.0f);
        }       
    }

    /// <summary>
    /// The function to Spawn new item on Call
    /// </summary>
    private void Spawn()
    {
        Instantiate(juggling_Item, spawner_Transform.position, Quaternion.identity, a_Transform);
    }
}
