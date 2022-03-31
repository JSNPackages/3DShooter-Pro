using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SyncMovement : MonoBehaviour {
    private PhotonView view;
    void Start() {
        this.view = GetComponent<PhotonView>();
    }

    void Update() {
        if (this.view.IsMine) {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),
                Input.GetAxisRaw("Jump"));
            this.transform.position += input.normalized * 10f * Time.deltaTime;
        }
    }
}
