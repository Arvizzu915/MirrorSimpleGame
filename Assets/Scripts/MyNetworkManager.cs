using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        // Check if the player limit has been reached
        if (numPlayers >= 4)
        {
            conn.Disconnect(); // Reject the connection
            return;
        }

        base.OnServerConnect(conn); // Allow the connection if there's space
    }
}
