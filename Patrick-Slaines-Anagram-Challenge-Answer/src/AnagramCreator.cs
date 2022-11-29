using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrick_Slaines_Anagram_Challenge_Answer.src
{
    public class AnagramCreator : Creator
    {
        public override Application FactoryMethod(FileAccess access,ILogger log)
        {
            return new AnagramApplication(access,log);
        }
    }
}
