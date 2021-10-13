using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : MonoBehaviour
{
    
    public static PoolingObject SharedInstance;
    [SerializeField]
    List<GameObject> _pooledObjects;
    [SerializeField]
    GameObject _objectToPool;
    [SerializeField]
    int _amountToPool;
    Vector3 _bottomLeftWorld;
    Vector3 _topRightWorld;
    [SerializeField]
    Transform _playerPosition;
    float sum = 0;
    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        _bottomLeftWorld = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        _topRightWorld = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        _pooledObjects = new List<GameObject>();
        GameObject _pooled;
        for(int i=0; i<_amountToPool; i++)
        {
            _pooled = Instantiate(_objectToPool);
            _pooled.SetActive(false);
            _pooledObjects.Add(_pooled);
        }

        StartCoroutine("ObjectPool");
    }

    public GameObject GetPooledObject()
    {
        for(int i=0; i<_amountToPool; i++)
        {
            if(!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ObjectPool()
    {
        while(true)
        {

        GameObject _platForm = GetPooledObject();
        if (_platForm != null)
        {
                Vector3 pos = transform.position;
              //  pos.y += 5;
                sum += pos.y+2;
              
                  _platForm.transform.position = new Vector3(Random.Range(_bottomLeftWorld.x, _topRightWorld.x), sum, 0);
                //_platForm.transform.position += pos;
            _platForm.SetActive(true);

        }
        yield return new WaitForSecondsRealtime(3f);
        }
    }
}
