using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyObjectPooling;

public class Spawner : MonoBehaviour
{
    // đối tượng nào cần dùng pool viết vào đây 
    public GameObject cubePrefab;
    // khai báo Pool cho từng đối tượng 
    public static ObjectPool<PoolObject> cubePool;
    private void Awake()
    {
        cubePool = new ObjectPool<PoolObject>(cubePrefab, 5);
    }


    // demo cách sử dụng pool
    public void SpawnObjectTest()
    {
        GameObject cubeObj = cubePool.PullGameObject(new Vector3(0,3,0));
        cubeObj.GetComponent<Rigidbody>().AddForce(Vector3.up*30,ForceMode.Impulse);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            SpawnObjectTest();
    }
}
// Đối tượng sử dụng pool implement IPoolable và thực thi như template
// đối tượng này sẽ có 1 instance trên scenes
// khi muốn trả đối tượng về pool chỉ việc setActive = false đối tượng sẽ tự động quay về pool
