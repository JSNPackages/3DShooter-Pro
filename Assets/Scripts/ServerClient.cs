using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

/// <summary>
/// ServerClient represents a single user, that has connected to the hosted server.
/// </summary>
public class ServerClient {
    // TCPClient
    public TcpClient tcp;
    
    // Identification
    public string name;
    public int id;
    public bool isHost;

    /// <summary>This constructor initializes the new Point to
    /// (<paramref name="tcp"/>,<paramref name="name"/>,<paramref name="id"/>).</summary>
    /// <param name="tcp">The client's attached TcpClient.</param>
    /// <param name="name">The client's attached name.</param>
    /// <param name="id">The client's attached, unique ID.</param>
    public ServerClient(TcpClient tcp, String name, int id) {
        this.tcp = tcp;
        this.name = name;
        this.id = id;
    }
}
