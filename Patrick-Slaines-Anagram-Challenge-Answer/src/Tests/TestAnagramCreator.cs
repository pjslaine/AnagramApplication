using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrick_Slaines_Anagram_Challenge_Answer.src.Tests
{
    public class TestAnagramCreator
    {
        [Fact]
        public void testToEnsureAnagramCreatorReturnsCorrectObjectType()
        {
            //Set Up
            Creator creator = new AnagramCreator();
            Logger logger = new LoggerConfiguration().CreateLogger();
            FileAccess jsonAccess = new JsonAccess("..\\..\\..\\src\\Storage\\AnagramData.json");

            //Test
            Application app = creator.FactoryMethod(jsonAccess,logger);


            //Assert
            Assert.IsType<AnagramApplication>(app);
        }
    }
}
