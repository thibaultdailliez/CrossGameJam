
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawn groundSpawn;
    private void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<GroundSpawn>();
        SpawnObstacle();
    }


    private void OnTriggerExit(Collider other)
    {
        groundSpawn.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    private void Update()
    {

    }

    public GameObject obstaclePrefab;

    void SpawnObstacle ()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnP = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnP.position, Quaternion.identity, transform);
    }
}
