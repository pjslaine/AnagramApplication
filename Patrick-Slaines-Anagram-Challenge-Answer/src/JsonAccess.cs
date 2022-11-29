using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrick_Slaines_Anagram_Challenge_Answer.src
{
    public class JsonAccess : FileAccess
    {
        
        public JsonAccess(string relativeFilePath)
        {
            this.relativeFilePath = relativeFilePath;
        }

        public override bool WriteToFile(UserInput input)
        {
            /* Firstly, the method checks if input data is null
             *  - If it is null, return false
             * 
             * Method checks if the file exists at the path
             *  - If it does exist, the file content is read and deserialized to List<UserInput>. 
             *  - The contents of the file are checks to see if the method input parameter can be found in the file
             *      - If the input value is found, returns false
             *      - If the input value is not found, then the input value is added to JSON storage, returns true
             *    
             *  - If the file does not exist, a file is created at the path.
             *    A new List<UserInput> object is created. 
             *    The new UserInput object is addded.
             *    List is serialized and written to the file
             */

            if(input == null)
            {
                return false;
            }

            bool added = false;
            bool found = false;
            if (File.Exists(relativeFilePath))
            {
                                
                string stringData = File.ReadAllText(relativeFilePath);
                List<UserInput> inputList = JsonConvert.DeserializeObject<List<UserInput>>(stringData);
                //If the file doesnt contain data
                if (inputList == null)
                {
                    inputList = new List<UserInput>();
                    inputList.Add(input);
                    added = true;
                }
                //If the file contains data check the data doesnt contain the UserInput we want to add
                else
                {
                    
                    foreach (UserInput storageInput in inputList)
                    {
                        if ((storageInput.inputValueOne == input.inputValueOne || storageInput.inputValueOne == input.inputValueTwo) && (storageInput.inputValueTwo == input.inputValueTwo || storageInput.inputValueTwo == input.inputValueOne))
                        {
                            found = true;                              
                            break;

                        }
                        
                    }
                    //If its not found add it
                    if (found == false)
                    {
                        inputList.Add(input);
                        added = true;
                        
                    }

                }
                
                stringData = JsonConvert.SerializeObject(inputList);
                File.WriteAllText(relativeFilePath, stringData);
                if (added == true)
                {
                    return true;
                }
                return false;
            }
            else
            {
                
                FileStream stream =File.Create(relativeFilePath);
                stream.Close();
                List<UserInput> newList = new List<UserInput>();
                newList.Add(input);
                string stringData = JsonConvert.SerializeObject(newList);
                    
                File.WriteAllText(path: relativeFilePath, stringData);
                return true;
                
            }
            

        }

        public override List<UserInput> LoadFromFile()
        {
            /*
             * Method Checks if the Json Data Exists at the storage directory
             *  - If the file does exist, the data is read from the file and returned as a List<UserInput>
             *  - If the file does not exist, a new file is created at the path and a empty List<UserInput> is returned
             */

            if (File.Exists(relativeFilePath))
            {
                try
                {
                    string stringData = File.ReadAllText(relativeFilePath);

                    List<UserInput> inputList = JsonConvert.DeserializeObject<List<UserInput>>(stringData);
                    if (inputList == null)
                    {
                        return new List<UserInput>();
                    }
                    return inputList;
                }catch(Exception)
                {
                    return new List<UserInput>();
                }
            }
            else
            {
                
                FileStream stream =File.Create(relativeFilePath);
                stream.Close();
                return new List<UserInput>();
            }
        }
    }
}
