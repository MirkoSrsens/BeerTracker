namespace NetworkService
{
    public class NetworkQueueCheckers
    {
        //[InjectDiContainter]
        //private NetworkServiceMessageHandler networkServicehandler { get; set; }

        //public NetworkQueueCheckers()
        //{
        //    DiContainerLibrary.DiContainer.DiContainerInitializor.RegisterObject(this);
        //}

        //public void ManageQueue()
        //{
        //    new Task(async () =>
        //    {
        //        while (true)
        //        {
        //            if (networkServicehandler.playersInQueue.Count >= 2)
        //            {
        //                var player1 = networkServicehandler.playersInQueue.Dequeue();
        //                var player2 = networkServicehandler.playersInQueue.Dequeue();
        //                player1.IsHost = true;
        //                player2.IsHost = false;
                        
        //                this.SendConnectionInfo(player1.IpAddress, player1.Port, player2);
        //                this.SendConnectionInfo(player2.IpAddress, player2.Port, player1);
        //            }
        //            await Task.Delay(5000);
        //        }
        //    }).Start();
        //}

        //public void SendConnectionInfo(string ipAddress, int port, PlayerData playerData)
        //{
        //    try
        //    {
        //        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //        var json = JsonConvert.SerializeObject(playerData);

        //        IPAddress broadcast = IPAddress.Parse(ipAddress);
        //        byte[] sendbuf = Encoding.ASCII.GetBytes(json);
        //        IPEndPoint ep = new IPEndPoint(broadcast, port);

        //        s.SendTo(sendbuf, ep);
        //    }
        //    catch(Exception ex)
        //    {
        //        System.IO.File.WriteAllText(@"Log.txt", ex.Message);
        //    }
        //}
    }
}
