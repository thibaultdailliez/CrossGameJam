using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnP;

    public void SpawnTile ()
    {
       GameObject temp = Instantiate(groundTile, nextSpawnP, Quaternion.identity);
        nextSpawnP = temp.transform.GetChild(1).transform.position;

    }
    private void Start()
    {
        for ( int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
        
    }

    
}
