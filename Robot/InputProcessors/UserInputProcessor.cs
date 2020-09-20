using System;
using System.Collections.Generic;
using System.IO;
using Robot.Interfaces;
using Robot.Helpers;

namespace Robot.InputProcessors
{
    public class UserInputProcessor : IUserInputProcessor
    {
        /// <summary>Reads the commands from a text file.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Commands as a list of string arrays.</returns>
        /// <exception cref="ArgumentNullException">File name cannot be null.</exception>
        /// <exception cref="Exception">Unable to process commands.</exception>
        public List<string[]> ReadCommandsFromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("File name cannot be null.");

            List<string[]> commandList = new List<string[]>();

            try
            {
                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + $"/TestData/{fileName}"))
                {
                    var line = reader.ReadLine();

                    List<string[]> commands = new List<string[]>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineItems;
                        if (!line.StartsWith("#") && !line.StartsWith("echo"))
                        {
                            lineItems = line.Split(" ");
                            commands = ToOneCommandPerLineList(lineItems);
                            if (commands == null)
                                throw new ArgumentNullException("Unable to process commands.");

                            commands.ForEach(c => commandList.Add(c));
                        }
                    }
                }

                return commandList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        /// <summary>Separates commands that represent one line of text to a list of commands with one command per line.</summary>
        /// <param name="commands">The commands.</param>
        /// <returns>Commands as a list of string arrays.</returns>
        /// <exception cref="ArgumentNullException">Array of commands cannot be null.</exception>
        private List<string[]> ToOneCommandPerLineList(string[] commands)
        {
            if (commands == null)
                throw new ArgumentNullException("Array of commands cannot be null.");

            List<string[]> commandList = new List<string[]>();
            try
            {
                for (int i = 0; i < commands.Length; i++)
                {
                    if (commands[i].ToUpper() == AppConstants.place)
                    {
                        string[] commandArray = new string[2];
                        commandArray[0] = commands[i].ToUpper();
                        commandArray[1] = commands[i + 1];
                        commandList.Add(commandArray);
                    }
                    else if (commands[i].ToUpper() == AppConstants.move ||
                             commands[i].ToUpper() == AppConstants.left ||
                             commands[i].ToUpper() == AppConstants.right ||
                             commands[i].ToUpper() == AppConstants.report)
                    {
                        string[] commandArray = new string[1];
                        commandArray[0] = commands[i].ToUpper();
                        commandList.Add(commandArray);
                    }
                    else if (commands[i].ToUpper() == AppConstants.validate)
                    {
                        string[] commandArray = new string[2];
                        commandArray[0] = commands[i].ToUpper();
                        commandArray[1] = commands[i + 1];
                        commandList.Add(commandArray);
                    }
                }
                return commandList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
    }
}