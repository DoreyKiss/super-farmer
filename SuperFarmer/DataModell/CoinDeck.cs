using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFarmer.DataModell
{
    public class CoinDeck
    {
        //todo
        private Dictionary<string, string> users = new Dictionary<string, string>();

        public void Set(string key, string value)
        {
            if (users.ContainsKey(key))
            {
                users[key] = value;
            }
            else
            {
                users.Add(key, value);
            }
        }
    }
}
