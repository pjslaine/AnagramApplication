using Patrick_Slaines_Anagram_Challenge_Answer.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FileAccess = Patrick_Slaines_Anagram_Challenge_Answer.src.FileAccess;

namespace Patrick_Slaines_Anagram_Challenge_Answer.Tests
{
    public  class TestJsonAccess
    {
        [Fact]
        public void testCorrectnessOfFilePath()
        {
            FileAccess fileAccess = new JsonAccess("..\\..\\src\\Tests\\AnagramData.json");
            Assert.Equal("..\\..\\src\\Tests\\AnagramData.json", fileAccess.relativeFilePath);
        }

        [Fact]
        public void testWriteToFileThatDoesntYetExist()
        {
            //Set Up 
            string relativePath = "..\\..\\..\\src\\Tests\\AnagramData.json";          

            FileAccess fileAccess = new JsonAccess(relativePath);
            UserInput userInput = new UserInput("testUser", "test", "tset", true);

            //Test
            fileAccess.WriteToFile(userInput);
            string actualData = File.ReadAllText(relativePath);
            string expectedData = "[{\"username\":\"testUser\",\"inputValueOne\":\"test\",\"inputValueTwo\":\"tset\",\"isAnagram\":true}]";
            
            //Assert
            Assert.Equal(expectedData, actualData);

            //Clean Up
            File.Delete(relativePath);
        }

        [Fact]
        public void testWriteToFileWithInformationContainedInFile()
        {
            //Set Up
            string relativePath = "..\\..\\..\\src\\Tests\\AnagramData.json";
            FileAccess fileAccess = new JsonAccess(relativePath);
            UserInput userInput = new UserInput("testUser", "test", "tset", true);
            
            //Test
            fileAccess.WriteToFile(userInput);
            bool inserted =fileAccess.WriteToFile(userInput);

            string actualData = File.ReadAllText(relativePath);
            string expectedData = "[{\"username\":\"testUser\",\"inputValueOne\":\"test\",\"inputValueTwo\":\"tset\",\"isAnagram\":true}]";
            
            //Assert
            Assert.Equal(expectedData, actualData);
            Assert.False(inserted);


            //Clean Up
            File.Delete(relativePath);

        }

        [Fact]
        public void testWriteToFileWithExistingBlankStorageFile()
        {
            //Set Up
            string relativePath = "..\\..\\..\\src\\Tests\\AnagramData.json";
            FileStream stream =File.Create(relativePath);
            stream.Close();
            FileAccess fileAccess = new JsonAccess(relativePath);
            UserInput userInput = new UserInput("testUser", "test", "tset", true);

            //Test
            bool inserted = fileAccess.WriteToFile(userInput);
            string actualData = File.ReadAllText(relativePath);
            string expectedData = "[{\"username\":\"testUser\",\"inputValueOne\":\"test\",\"inputValueTwo\":\"tset\",\"isAnagram\":true}]";

            //Assert
            Assert.Equal(expectedData, actualData);
            Assert.True(inserted);


            //Clean Up
            File.Delete(relativePath);

        }

        [Fact]
        public void testWriteToFileWithNullValue()
        {
            //Set Up
            string relativePath = "..\\..\\..\\src\\Tests\\AnagramData.json";
            FileStream stream = File.Create(relativePath);
            stream.Close();
            FileAccess fileAccess = new JsonAccess(relativePath);

            //Test
            bool inserted = fileAccess.WriteToFile(null);

            //Assert
            Assert.False(inserted);


            //Clean Up
            File.Delete(relativePath);
        }


        [Fact]
        public void testLoadFromFileWithBlankFile()
        {
            //Set Up
            string relativePath = "..\\..\\..\\src\\Tests\\AnagramData.json";
            FileStream stream = File.Create(relativePath);
            stream.Close();
           
            FileAccess fileAccess = new JsonAccess(relativePath);

            //Test
            List<UserInput> userList =fileAccess.LoadFromFile();

            //Assert 
            Assert.Equal(userList.Count, 0);

            //Clean Up
            File.Delete(relativePath);
        }

        [Fact]
        public void testLoadFromFileWithOneObjectInStorage()
        {
            //Set Up
            string relativePath = "..\\..\\..\\src\\Tests\\AnagramData.json";
            FileStream stream = File.Create(relativePath);
            stream.Close();
            string fileData = "[{\"username\":\"testUser\",\"inputValueOne\":\"test\",\"inputValueTwo\":\"tset\",\"isAnagram\":true}]";
            File.WriteAllText(relativePath,fileData);
            FileAccess fileAccess = new JsonAccess(relativePath);

            //Test
            List<UserInput> userList = fileAccess.LoadFromFile();

            //Assert 
            Assert.Equal(userList.Count, 1);
            Assert.Equal(userList[0].username, "testUser");
            Assert.Equal(userList[0].inputValueOne, "test");
            Assert.Equal(userList[0].inputValueTwo, "tset");
            Assert.Equal(userList[0].isAnagram, true);

            //Clean Up
            File.Delete(relativePath);
        }

        
    }
}
