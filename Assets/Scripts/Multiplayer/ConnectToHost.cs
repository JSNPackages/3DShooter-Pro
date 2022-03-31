using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToHost : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        SceneManager.LoadScene("HomeScene");
    }
}