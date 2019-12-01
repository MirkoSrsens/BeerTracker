using System;

namespace Database
{
    [Serializable]
    public class PlayerData
    {
        public string IpAddress { get; set; }

        public int Port { get; set; }

        public bool IsHost { get; set; }
    }
}