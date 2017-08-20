using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour {

    ObjectPool m_ObjectPool;


    public void Init(ObjectPool _Pool)
    {
        m_ObjectPool = _Pool;
    }

    public void Over()
    {
        m_ObjectPool.Recovery(gameObject);


    }
}
