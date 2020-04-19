using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{
    public GameObject obsitcle;

    public float timer;
    public float obsticleSpawnTimer;

    public float maxSpawnDelay;
    public float minSpawnDelay;

    public float topSpawn;
    public float bottomSpawn;

    public float horizontalSpeed;

    private GameController gc;

    // Use this for initialization
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gc.complete)
        {
            transform.Translate(-Vector2.left.x * Time.deltaTime * horizontalSpeed, 0, 0);

            timer += Time.deltaTime;

            if (timer > obsticleSpawnTimer)
            {
                GameObject obsitcle1 = Instantiate(obsitcle, new Vector3(transform.position.x + Random.Range(5, 15), topSpawn, transform.position.z), Quaternion.identity);
                GameObject obsitcle2 = Instantiate(obsitcle, new Vector3(transform.position.x + Random.Range(5, 10), bottomSpawn, transform.position.z), Quaternion.identity);

                timer = 0;

                obsticleSpawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay);
            }
        }
    }
}
