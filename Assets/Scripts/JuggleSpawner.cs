using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggleSpawner : MonoBehaviour
{
    private Transform a_Transform;
    private Transform spawner_Transform;

    private GameObject juggling_Pin_Blue;
    private GameObject juggling_Pin_Green;
    private GameObject juggling_Pin_Red;

    void Start()
    {
        a_Transform = gameObject.transform;
        spawner_Transform = a_Transform.Find("Spawner");

        juggling_Pin_Blue = Resources.Load<GameObject>("Juggling_Pin_Blue");
        juggling_Pin_Green = Resources.Load<GameObject>("Juggling_Pin_Green");
        juggling_Pin_Red = Resources.Load<GameObject>("Juggling_Pin_Red");


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
        for(int i = 0; i < 20; i++)
        {
            spawner_Transform.Translate(new Vector2(100, 0));
            yield return new WaitForSeconds(1.0f);
            int length = All_Items.Instance.ItemList.Count;
            Spawn(All_Items.Instance.ItemList[Random.Range(0, length)]);
            yield return new WaitForSeconds(1.5f);
        }       
    }

    /// <summary>
    /// The function Spawn a blue juggling pin on Call
    /// </summary>
    private void Spawn()
    {
        Instantiate(juggling_Pin_Blue, spawner_Transform.position, Quaternion.identity, a_Transform);
    }

    /// <summary>
    /// The function Spawn a specific item on Call
    /// </summary>
    /// <param name="Object"></param>
    /// <param name="GravityCoff"></param>
    private void Spawn(string ObjectName)
    {
        Juggling_Item jItem = All_Items.Instance.FindItemByName(ObjectName);
        GameObject go = Instantiate(jItem.Obj, spawner_Transform.position, Quaternion.identity, a_Transform);
        go.GetComponent<Juggling_Item>().Mass = jItem.Mass;
    }

    private void Spawn(Juggling_Item jItem)
    {
        GameObject go = Instantiate(jItem.Obj, spawner_Transform.position, Quaternion.identity, a_Transform);
        go.GetComponent<Juggling_Item>().Mass = jItem.Mass;
    }
}
