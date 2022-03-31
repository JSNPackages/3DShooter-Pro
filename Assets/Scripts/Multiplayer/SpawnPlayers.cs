using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour {
    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    void Start() {
        Vector2 randomPos = new Vector2(Random.Range(this.minX, this.maxX), Random.Range(this.minY, this.maxY));
        PhotonNetwork.Instantiate(this.playerPrefab.name, randomPos, Quaternion.identity);
    }
}
