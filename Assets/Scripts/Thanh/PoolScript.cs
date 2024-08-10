using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    public static PoolScript instance;

    private List<GameObject> pooledObject = new List<GameObject>();
    private int amountToPool = 2;

    [SerializeField]
    public Transform[] spawnPoints; // Mảng chứa các vị trí spawn cố định



    [SerializeField] private GameObject headPerfab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(headPerfab);
            obj.SetActive(false);
            pooledObject.Add(obj);
        }
        StartCoroutine(SpawnHeadEveryInterval(3f)); // Bắt đầu coroutine để sinh đối tượng mỗi 3 giây

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }
        return null;
    }
    IEnumerator SpawnHeadEveryInterval(float interval)
    {
        while (true)
        {
            GameObject head = instance.GetPooledObject();
            if (head != null)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Vector3 spawnPosition = spawnPoints[randomIndex].position;

                head.transform.position = spawnPosition;
                head.SetActive(true);
            }
            yield return new WaitForSeconds(interval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject head = instance.GetPooledObject();
            if (head != null && head.activeInHierarchy)
            {
                head.SetActive(false);
            }
        }
    }


}
