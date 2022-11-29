using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrick_Slaines_Anagram_Challenge_Answer.src
{
    public class UserInput
    {
        public string? username { get; set; }
        public string? inputValueOne { get; set; }
        public string? inputValueTwo { get; set; }
        public bool? isAnagram { get; set; }

        public UserInput(string username, string inputValueOne, string inputValueTwo, bool isAnagram)
        {
            this.username = username;
            this.inputValueOne = inputValueOne;
            this.inputValueTwo = inputValueTwo;
            this.isAnagram = isAnagram;
        }
  }
}
