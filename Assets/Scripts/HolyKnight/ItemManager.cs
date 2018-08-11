using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemManager : NetworkBehaviour
{
    public GameObject[] prefabItem;

    public void SpawnItem()
    {
        float x = 0;
        float y = 0;

        for(int i=0; i<500; i++)
        {
            GameObject item = Instantiate(prefabItem[Random.Range(0, 5)]);

            x = Random.Range(-1.5f, 1.5f);
            y += Random.Range(1, 3);

            item.transform.position = new Vector3(x, y, -4f);

            NetworkServer.Spawn(item);

            Debug.Log("CREATE ITEM: x=" + x + " / y=" + y);
        }
    }
}
