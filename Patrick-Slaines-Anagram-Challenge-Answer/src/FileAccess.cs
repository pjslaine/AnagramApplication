using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrick_Slaines_Anagram_Challenge_Answer.src
{
    public abstract class FileAccess
    {
        public string? relativeFilePath { get; set; }
        public abstract bool WriteToFile(UserInput input);

        public abstract List<UserInput> LoadFromFile();
    }
}
