using System;
using System.Collections.Generic;
using System.Text;

namespace EVEPOSMon
{
    public class Character
    {
        public string name;
        public string characterId;
        public string coportationName;
        public string corporationId;
        public bool selected;

        public override string ToString()
        {
            return name;
        }
    }

    public class AccountInfo
    {
        public string userId;
        public string apiKey;
        public List<Character> characters = new List<Character>();
    }
}
