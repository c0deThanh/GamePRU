using System.Collections;
using UnityEngine;

public class GunSpawn : MonoBehaviour
{
    public static GunSpawn instance;

    [SerializeField]
    public Transform[] spawnPoints; // Array of fixed spawn positions

    [SerializeField] private GameObject[] headPrefab;

    private GameObject headInstance;
    private Coroutine deactivateCoroutine;


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
        StartCoroutine(SpawnHeadEveryInterval(1f)); // Start coroutine to spawn the object every 1 second
    }

    IEnumerator SpawnHeadEveryInterval(float interval)
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            // Check if headInstance is null or not active
            if (headInstance == null || !headInstance.activeInHierarchy)
            {
                // Select a random prefab from the headPrefab array
                int randomPrefabIndex = Random.Range(0, headPrefab.Length);
                GameObject selectedPrefab = headPrefab[randomPrefabIndex];

                // Select a random spawn position from the spawnPoints array
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Vector3 spawnPosition = spawnPoints[randomIndex].position;
                Transform spawnParent = spawnPoints[randomIndex];

                // Instantiate the selected prefab at the spawn position
                headInstance = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

                headInstance.transform.SetParent(spawnParent, true);
                headInstance.SetActive(true);
                //headInstance.GetComponent<HeadController>().createHealthEnemy();
            }
            yield return new WaitForSeconds(interval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && headInstance != null && headInstance.activeInHierarchy)
        {
            headInstance.SetActive(false);
        }
    }
}
