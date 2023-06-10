using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GarbangeSpawn : MonoBehaviour
{
    public static GarbangeSpawn instance;
    public Tilemap[] tilemaps; // Array dari Tilemap yang akan di-spawn

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }
    private void Start()
    {
        SpawnRandomTilemap();
    }

    private void SpawnRandomTilemap()
    {
        int randomIndex = Random.Range(0, tilemaps.Length); // Mendapatkan indeks acak dari array Tilemap
        Tilemap tilemapToSpawn = tilemaps[randomIndex]; // Mengambil Tilemap sesuai indeks acak

        Instantiate(tilemapToSpawn, transform.position, Quaternion.identity); // Membuat instance dari Tilemap pada posisi spawner
    }
}
