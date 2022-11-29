using Patrick_Slaines_Anagram_Challenge_Answer.src;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.File;
using FileAccess = Patrick_Slaines_Anagram_Challenge_Answer.src.FileAccess;

/*
 * 1. Creates the storage access object - In the future, the abstract class can be extended in order for the support different file types
 * 2. Instantiates AnagramApplicatio Object
 * 3. Run Application
 * 
 */


Logger logger = new LoggerConfiguration().WriteTo.File(path: "..\\..\\..\\src\\Logging\\log.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();
FileAccess jsonAccess =new JsonAccess("..\\..\\..\\src\\Storage\\AnagramData.json");
Creator creator = new AnagramCreator();
Application application = creator.FactoryMethod(jsonAccess,logger);
application.RunApplication();