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
    public class TestAnagramApplication
    {

        [Fact]
        public void testCheckForAnagramWithValidData()
        {
            // Set Up
            Creator creator = new AnagramCreator();
            Logger logger = new LoggerConfiguration().CreateLogger();
            FileAccess jsonAccess = new JsonAccess("..\\..\\..\\src\\Storage\\AnagramData.json");
            AnagramApplication app = (AnagramApplication)creator.FactoryMethod(jsonAccess, logger);

            //Test
            bool actualOutcome =app.checkForAnagram("test", "tset");

            //Assert
            Assert.True(actualOutcome);
        }

        [Fact]
        public void testCheckForAnagramWithInvalidData()
        {
            // Set Up
            Creator creator = new AnagramCreator();
            Logger logger = new LoggerConfiguration().CreateLogger();
            FileAccess jsonAccess = new JsonAccess("..\\..\\..\\src\\Storage\\AnagramData.json");
            AnagramApplication app = (AnagramApplication)creator.FactoryMethod(jsonAccess, logger);

            //Test
            bool actualOutcome = app.checkForAnagram("testValueOne", "testValueTwo");

            //Assert
            Assert.False(actualOutcome);

        }

        [Fact]
        public void testCheckForAnagramWithNullValues()
        {
            // Set Up
            Creator creator = new AnagramCreator();
            Logger logger = new LoggerConfiguration().CreateLogger();
            FileAccess jsonAccess = new JsonAccess("..\\..\\..\\src\\Storage\\AnagramData.json");
            AnagramApplication app = (AnagramApplication)creator.FactoryMethod(jsonAccess, logger);

            //Test
            bool actualOutcome = app.checkForAnagram(null, null);

            //Assert
            Assert.False(actualOutcome);
        }
    }
}
