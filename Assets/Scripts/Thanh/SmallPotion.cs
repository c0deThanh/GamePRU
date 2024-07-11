using System.Collections;
using UnityEngine;

public class SmallPotion : MonoBehaviour
{
    public static SmallPotion instance;

    [SerializeField]
    public Transform[] spawnPoints; // Array of fixed spawn positions

    [SerializeField] private GameObject headPrefab;

    private GameObject headInstance;

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
        headInstance = Instantiate(headPrefab);
        headInstance.SetActive(false);

        StartCoroutine(SpawnHeadEveryInterval(10f)); // Start coroutine to spawn the object every 3 seconds
    }

    IEnumerator SpawnHeadEveryInterval(float interval)
    {
        while (true)
        {
            if (!headInstance.activeInHierarchy)
            {
                // Select a random spawn position from the spawnPoints array
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Vector3 spawnPosition = spawnPoints[randomIndex].position;

                // Set the position of the object to the selected spawn position
                headInstance.transform.position = spawnPosition;
                headInstance.SetActive(true);
                //headInstance.GetComponent<HeadController>().createHealthEnemy();
            }
            yield return new WaitForSeconds(interval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X) && headInstance.activeInHierarchy)
        //{
        //    headInstance.SetActive(false);
        //}
    }
}
