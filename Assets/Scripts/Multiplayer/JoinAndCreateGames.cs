using Photon.Pun;
using UnityEngine.UI;

public class JoinAndCreateGames : MonoBehaviourPunCallbacks {
    public InputField createInput;
    public InputField joinInput;

    public void CreateRoom() {
        PhotonNetwork.CreateRoom(this.createInput.text);
    }

    public void JoinRoom() {
        PhotonNetwork.JoinRoom(this.joinInput.text);
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Playground");
    }
}
