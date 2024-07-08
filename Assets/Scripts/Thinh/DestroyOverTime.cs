using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
