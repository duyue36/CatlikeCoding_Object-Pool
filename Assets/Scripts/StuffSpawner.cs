using UnityEngine;


public class StuffSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct FloatRange
    {

        public float min, max;

        public float RandomInRange
        {
            get
            {
                return Random.Range(min, max);
            }
        }
    }
    public Material stuffMaterial;
    public Stuff[] stuffPrefabs;

    float timeSinceLastSpawn;

    public float velocity;

    public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;

    float currentSpawnDelay;

    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay)
        {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
    }

    void SpawnStuff()
    {
        Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
        Stuff spawn = Instantiate<Stuff>(prefab);
        //Stuff spawn = prefab.getP

        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = Vector3.one * scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;

        spawn.Body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandomInRange;
        spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;

        //spawn.GetComponent<MeshRenderer>().material = stuffMaterial;
        spawn.SetMaterial(stuffMaterial);
    }
}