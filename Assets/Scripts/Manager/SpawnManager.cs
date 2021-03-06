using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private readonly float treePosX = 10.0f;
    private readonly float treePosY = 3.9f;
    private readonly float spawnPosZ = 145.0f;

    public List<GameObject> obstacleObj;
    public List<GameObject> treeObjList;
    public bool isSpawnable;

    public void InitSpawnManager()
    {
        StartCoroutine(OnSpawnTree());
        StartCoroutine(OnSpawnObject());
    }

    IEnumerator OnSpawnObject()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            if(isSpawnable)
            {
                int index = Random.Range(0, obstacleObj.Count);

                Instantiate(obstacleObj[index], new Vector3(Random.Range(-6.0f, 6.0f), 5.0f, spawnPosZ), obstacleObj[index].transform.rotation);
            }
        }
    }

    IEnumerator OnSpawnTree()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 4));

            if (isSpawnable)
            {
                int posIndex = Random.Range(0, 2);
                float positionX = 10.0f;

                if (posIndex == 0)
                {
                    positionX = treePosX;
                }
                else
                {
                    positionX = -treePosX;
                }

                int treeIndex = Random.Range(0, treeObjList.Count);

                GameObject tree = Instantiate(treeObjList[treeIndex], new Vector3(positionX, treePosY, spawnPosZ), treeObjList[treeIndex].transform.rotation);
                tree.transform.localEulerAngles = new Vector3(0.0f, Random.Range(0.0f, 180.0f), 0.0f);
            }
        }
    }
}
