using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initailSize = 20;

    private Queue<GameObject> m_pool = new Queue<GameObject>();

    void Awake()
    {
        for (int cnt = 0; cnt < initailSize; cnt++)
        {
            GameObject go = Instantiate(prefab) as GameObject;
            go.GetComponent<PoolObject>().Init(this);
            m_pool.Enqueue(go); go.SetActive(false);

        }
    }

    public void ReUse(Vector3 position)
    {
        if (m_pool.Count > 0)
        {
            GameObject reuse = m_pool.Dequeue();
            reuse.transform.position = position;
            reuse.SetActive(true);
        }
        else
        {
            GameObject go = Instantiate(prefab) as GameObject;
            go.GetComponent<PoolObject>().Init(this);
            go.transform.position = position;
        }
    }


    public void Recovery(GameObject recovery)
    {
        m_pool.Enqueue(recovery);
        recovery.SetActive(false);
    }
}
