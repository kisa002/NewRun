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

        int rand = -1;

        for(int i=0; i<500; i++)
        {
            rand = Random.Range(0, 65);

            if (rand < 10)
                rand = 0;
            else if (rand < 20)
                rand = 1;
            else if (rand < 30)
                rand = 2;
            else if (rand < 40)
                rand = 3;
            else if (rand < 50)
                rand = 4;
            else if (rand < 65)
                rand = 5;

            GameObject item = Instantiate(prefabItem[rand]);

            x = Random.Range(-1.5f, 1.5f);
            y += Random.Range(1f, 3.5f);

            item.transform.position = new Vector3(x, y, -4f);

            NetworkServer.Spawn(item);

            //Debug.Log("CREATE ITEM: x=" + x + " / y=" + y);
        }
    }
}
