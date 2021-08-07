using System;
using System.IO;
using System.Collections.Generic;

namespace WordsearchACW
{
    class Program
    {

        static int GetNumberFromUserInRange(string pQuestion, int pMin, int pMax)
        {
            int result = pMax + 1;

            do
            {
                Console.WriteLine(pQuestion);
                Console.WriteLine("Enter a number between " + pMin + " and " + pMax + " inclusive");
                try
                {
                    result = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(Console.ReadLine() + " is not a valid input.");
                    Console.WriteLine(" ");

                    continue;
                }
                if (result < pMin || result > pMax)
                {
                    Console.WriteLine(result + " is not in range.");
                    Console.WriteLine(" ");
                    continue;
                }
                else
                {
                    return result;
                }
            } while (true);
        }

        static char[,] MakeBoard(int pNumberOfColumns, int pNumberOfRows)
        {

            char[,] grid = new char[pNumberOfColumns, pNumberOfRows];
            Random lettsOfWordsearch = new Random();
            for (int x = 0; x < pNumberOfRows; x++)
            {

                for (int y = 0; y < pNumberOfColumns; y++)
                {
                    grid[y, x] = (char)(lettsOfWordsearch.Next(97, 122));

                }
            }
            return grid;
        }

        static void DisplayBoard(char[,] pGrid)
        {
            int x = pGrid.GetLength(1);
            int y = pGrid.GetLength(0);


            // for the row above containing the numbers
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("  ");
            for (int i = 0; i <= y - 1; i++)
            {
                Console.Write(i.ToString().PadLeft(1).PadRight(1) + " ");
            }
            Console.WriteLine();
            Console.ResetColor();

            // output board
            for (int i = 0; i < x; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(i);
                Console.Write(" ");
                Console.ResetColor();
                for (int j = 0; j < y; j++)
                {

                    Console.Write(pGrid[j, i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static void AddWords(string pWord, int pColumn, int pRow, string pDirection, char[,] pGrid)
        {
            char[] splitWord = pWord.ToCharArray();

            if (pDirection == "right")
            {
                for (int i = pColumn; i <= splitWord.Length - 1; i++)
                {
                    pGrid[i, pRow] = splitWord[i];
                }
            }
            else if (pDirection == "left")
            {
                Array.Reverse(splitWord);
                for (int i = pColumn; i >= splitWord.Length + 1 - splitWord.Length; i--)
                {
                    pGrid[i, pRow] = splitWord[i - 1];
                }

            }
            else if (pDirection == "down")
            {
                for (int i = pRow; i <= splitWord.Length - 1; i++)
                {
                    pGrid[pColumn, i] = splitWord[i];
                }
            }
            else if (pDirection == "up")
            {
                Array.Reverse(splitWord);
                for (int i = pRow; i >= splitWord.Length - splitWord.Length; i--)
                {
                    pGrid[pColumn, i] = splitWord[i];
                }
            }
            else if (pDirection == "rightdown")
            {
                for (int i = 0; i <= splitWord.Length - 1; i++)
                {
                    pGrid[pColumn, pRow] = splitWord[i];
                    pRow++;
                    pColumn++;
                }
            }
            else if (pDirection == "rightup")
            {
                for (int i = 0; i <= splitWord.Length - 1; i++)
                {
                    pGrid[pColumn, pRow] = splitWord[i];
                    pRow--;
                    pColumn++;
                }
            }
            else if (pDirection == "leftdown")
            {
                for (int i = 0; i <= splitWord.Length - 1; i++)
                {
                    pGrid[pColumn, pRow] = splitWord[i];
                    pRow++;
                    pColumn--;
                }
            }
            else if (pDirection == "leftup")
            {
                for (int i = 0; i <= splitWord.Length - 1; i++)
                {
                    pGrid[pColumn, pRow] = splitWord[i];
                    pRow--;
                    pColumn--;
                }
            }
        }

        static char FirstLetterChosen(int pFirstX, int pFirstY, char[,] pGrid)
        {
            char firstChosenLetter;
            int firstXCoord = pFirstX;
            int firstYCoord = pFirstY;
            char[,] grid = pGrid;

            Console.WriteLine("You have chosen : (" + firstYCoord + "," + firstXCoord + ")");
            firstChosenLetter = grid[firstYCoord, firstXCoord];
            Console.Write("Your Chosen Letter is: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(firstChosenLetter);
            Console.ResetColor();
            Console.WriteLine("");


            return firstChosenLetter;
        }

        static char SecondLetterChosen(int pSecondX, int pSecondY, char[,] pGrid)
        {
            char secondChosenLetter;
            int secondXCoord = pSecondX;
            int secondYCoord = pSecondY;
            char[,] grid = pGrid;

            Console.WriteLine("You have chosen : (" + secondYCoord + "," + secondXCoord + ")");
            secondChosenLetter = grid[secondYCoord, secondXCoord];
            Console.Write("Your Chosen Letter is: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(secondChosenLetter);
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");

            return secondChosenLetter;
        }

        static string HorizontalWordMaker(int pFirstX, int pFirstY, int pSecondX, int pSecondY, char[,] pGrid)
        {
            int firstXCoord = pFirstX;
            int firstYCoord = pFirstY;
            int secondXCoord = pSecondX;
            int secondYCoord = pSecondY;
            char[,] grid = pGrid;

            string wordChosenByUser = "";

            //Checks for horizontial win normally 
            if (firstYCoord < secondYCoord)
            {
                for (int i = firstYCoord; i <= secondYCoord; i++)
                {
                    wordChosenByUser += grid[i, secondXCoord].ToString();
                }
                Console.Write("Your Chosen Word is: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(wordChosenByUser);
                Console.ResetColor();
                Console.WriteLine("");
            }

            //Checks for horizontial win reverse 
            else if (firstYCoord > secondYCoord)
            {
                for (int i = firstYCoord; i >= secondYCoord; i--)
                {
                    wordChosenByUser += grid[i, firstXCoord].ToString();
                }
                Console.Write("Your Chosen Word is: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(wordChosenByUser);
                Console.ResetColor();
                Console.WriteLine("");
            }
            return wordChosenByUser;
        }

        static string VerticalWordMaker(int pFirstX, int pFirstY, int pSecondX, int pSecondY, char[,] pGrid)
        {
            int firstXCoord = pFirstX;
            int firstYCoord = pFirstY;
            int secondXCoord = pSecondX;
            int secondYCoord = pSecondY;
            char[,] grid = pGrid;

            string wordChosenByUser = "";

            //Checks for vertical win normally 
            if (firstXCoord < secondXCoord)
            {
                for (int i = firstXCoord; i <= secondXCoord; i++)
                {
                    wordChosenByUser += grid[firstXCoord, i].ToString();
                }
                Console.Write("Your Chosen Word is: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(wordChosenByUser);
                Console.ResetColor();
                Console.WriteLine("");
            }

            //Checks for vertical win reverse 
            else if (firstXCoord > secondXCoord)
            {
                for (int i = firstXCoord; i >= secondXCoord; i--)
                {
                    wordChosenByUser += grid[firstXCoord - 1, i].ToString();

                }
                Console.Write("Your Chosen Word is: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(wordChosenByUser);
                Console.ResetColor();
                Console.WriteLine("");
            }

            return wordChosenByUser;
        }

        static string DiaganolWordMaker(int pFirstX, int pFirstY, int pSecondX, int pSecondY, char[,] pGrid)
        {
            int firstXCoord = pFirstX;
            int firstYCoord = pFirstY;
            int secondXCoord = pSecondX;
            int secondYCoord = pSecondY;
            char[,] grid = pGrid;

            string wordChosenByUser = "";
            // Left Down - done
            if (firstXCoord < secondXCoord && firstYCoord > secondYCoord)
            {
                for (int i = firstXCoord, j = firstYCoord; i <= secondXCoord && j >= secondYCoord; i++, j--)
                {
                    wordChosenByUser += grid[j, i].ToString();

                }
                Console.Write("Your Chosen Word is: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(wordChosenByUser);
                Console.ResetColor();
                Console.WriteLine("");
            }
            //Right Down - done
            else if (firstXCoord < secondXCoord && firstYCoord < secondYCoord)
            {
                for (int i = firstXCoord, j = firstYCoord; i <= secondXCoord && j <= secondYCoord; i++, j++)
                {
                    wordChosenByUser += grid[j, i].ToString();

                }
                Console.Write("Your Chosen Word is: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(wordChosenByUser);
                Console.ResetColor();
                Console.WriteLine("");
            }
            //left up
            else if (firstXCoord > secondXCoord && firstYCoord > secondYCoord)
            {
                for (int i = firstXCoord, j = firstYCoord; i >= secondXCoord && j >= secondYCoord; i--, j--)
                {
                    wordChosenByUser += grid[j, i].ToString();

                }
                Console.Write("Your Chosen Word is: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(wordChosenByUser);
                Console.ResetColor();
                Console.WriteLine("");
            }

            //right up - done
            else if (firstXCoord > secondXCoord && firstYCoord < secondYCoord)
            {
                for (int i = firstXCoord, j = firstYCoord; i >= secondXCoord && j <= secondYCoord; i--, j++)
                {
                    wordChosenByUser += grid[j, i].ToString();

                }
                Console.Write("Your Chosen Word is: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(wordChosenByUser);
                Console.ResetColor();
                Console.WriteLine("");
            }

            return wordChosenByUser;


        }

        static bool WordChecker(string pMadeByUser, List<string> pAllWords, int pWordCounter)
        {
            bool currentWord = pAllWords.Contains(pMadeByUser);
            if (currentWord)
            {
                Console.Write("Well done! You found the Word: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(pMadeByUser);
                Console.ResetColor();
                Console.WriteLine(" ");
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(pMadeByUser + " is not a word!");
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }
            return currentWord;
        }


        static void Main(string[] args)
        {
            bool wordCorrect = false;
            int numberOfWords = 0;
            int wordCounter = 0;
            char[,] grid = new char[9, 5];
            int numberOfColumns = 0;
            int numberOfRows = 0;
            string madeByUser = " ";
            List<string> allWords = new List<string>();
            List<string> foundWords = new List<string>();


            Console.WriteLine(" Wordsearch ACW");
            Console.WriteLine("");
            Console.WriteLine("Select an Option");
            Console.WriteLine("1. Use Default Wordsearch");
            Console.WriteLine("2. Import Wordsearch from file");
            Console.WriteLine("");

            int inputChoice = GetNumberFromUserInRange("Please choose an option above", 1, 2);

            //Loads default file
            if (inputChoice == 1)
            {
                Console.Clear();

                numberOfColumns = 9;
                numberOfRows = 5;
                numberOfWords = 2;
                grid = MakeBoard(numberOfColumns, numberOfRows);
                AddWords("algorithm", 0, 1, "right", grid);
                AddWords("virus", 5, 4, "left", grid);
                allWords.Add("algorithm");
                allWords.Add("virus");
            }
            //Loads a list of files for users to choose from
            else
            {
                bool catchChecker = false;
                string currentWordOfFile = " ";
                do
                {
                    catchChecker = false;
                    allWords.Clear();

                    Console.Clear();
                    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.wrd");

                    Console.WriteLine("Select a file to load");
                    Console.WriteLine("");

                    int counter = 1;
                    foreach (string file in files)
                    {
                        Console.WriteLine(counter++ + "." + " " + file);
                    }

                    Console.WriteLine(" ");
                    int fileToLoad = GetNumberFromUserInRange("Please choose an option", 1, 7);
                    Console.WriteLine(" ");

                    string filepath = files[fileToLoad - 1];
                    StreamReader reader = new StreamReader(filepath);

                    string currentLine = reader.ReadLine();
                    string[] commaSeperatedLine1 = currentLine.Split(',');

                    string directionChecker = "";
                    numberOfColumns = int.Parse(commaSeperatedLine1[0]);
                    numberOfRows = int.Parse(commaSeperatedLine1[1]);
                    numberOfWords = int.Parse(commaSeperatedLine1[2]);
                    Console.Clear();

                    grid = MakeBoard(numberOfColumns, numberOfRows);

                    if (numberOfWords <= 0)
                    {
                        Console.WriteLine("Cannot Load File Due The Number Of Words Being Less Than 0, Press Any Key To Continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        for (int j = 0; j < numberOfWords; j++)
                        {
                            currentLine = reader.ReadLine();
                            commaSeperatedLine1 = currentLine.Split(',');
                            try
                            {
                                currentWordOfFile = commaSeperatedLine1[0];
                                allWords.Add(currentWordOfFile);
                                AddWords(commaSeperatedLine1[0], int.Parse(commaSeperatedLine1[1]), int.Parse(commaSeperatedLine1[2]), commaSeperatedLine1[3], grid);
                                directionChecker = commaSeperatedLine1[3];
                                int firstCood = int.Parse(commaSeperatedLine1[1]);
                            }
                            catch
                            {
                                catchChecker = true;
                                Console.WriteLine("Cannot Load File");
                                Console.ReadKey();
                                break;
                            }
                                if (currentWordOfFile.Length > numberOfColumns && directionChecker == "right" || (currentWordOfFile.Length > numberOfColumns && directionChecker == "left"))
                                {
                                    Console.WriteLine("Cannot Load File Due The Size  Of Words Being Longer Than The Length Of The Board  0, Press Any Key To Continue");
                                    Console.ReadKey();
                                    catchChecker = true;
                                    break;
                                }
                                else if (currentWordOfFile.Length > numberOfRows && directionChecker == "up" || currentWordOfFile.Length > numberOfRows && directionChecker == "down")
                                {
                                    Console.WriteLine("Cannot Load File Due The Size  Of Words Being Longer Than The Length Of The Board  0, Press Any Key To Continue");
                                    Console.ReadKey();
                                    catchChecker = true;
                                    break;
                                }

                        }
                    }
                } while (catchChecker == true || numberOfWords <= 0);
            }

            //Prints out the board and the loops through the words
            do
            {
                DisplayBoard(grid);

                Console.WriteLine("Words to find:");
                foreach (string word in allWords)
                {
                    if (foundWords.Contains(word))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(word);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(word);
                    }
                }
                Console.WriteLine(" ");

                int firstYCoord = GetNumberFromUserInRange("Enter a number for your first column.", 0, numberOfColumns - 1);
                int firstXCoord = GetNumberFromUserInRange("Enter a number for your first row.", 0, numberOfRows - 1);
                FirstLetterChosen(firstXCoord, firstYCoord, grid);
                Console.WriteLine(" ");
                int secondYCoord = GetNumberFromUserInRange("Enter a number for your second column.", 0, numberOfColumns - 1);
                int secondXCoord = GetNumberFromUserInRange("Enter a number for your second row.", 0, numberOfRows - 1);   
                SecondLetterChosen(secondXCoord, secondYCoord, grid);


                if (firstXCoord == secondXCoord)
                {
                    madeByUser = HorizontalWordMaker(firstXCoord, firstYCoord, secondXCoord, secondYCoord, grid);
                    wordCorrect = WordChecker(madeByUser, allWords, wordCounter);

                    if (foundWords.Contains(madeByUser))
                    {
                        Console.WriteLine("That Word Has Already Been Found");
                    }
                    else
                    {
                        wordCounter++;
                        foundWords.Add(madeByUser);
                    }

                    Console.Clear();
                }
                else if (firstYCoord == secondYCoord)
                {
                    madeByUser = VerticalWordMaker(firstXCoord, firstYCoord, secondXCoord, secondYCoord, grid);
                    wordCorrect = WordChecker(madeByUser, allWords, wordCounter);

                    if (foundWords.Contains(madeByUser))
                    {
                        Console.WriteLine("That Word Has Already Been Found");
                    }
                    else
                    {
                        wordCounter++;
                        foundWords.Add(madeByUser);
                    }

                    Console.Clear();
                }
                else if (firstYCoord != secondYCoord && firstXCoord != secondXCoord)
                {
                    madeByUser = DiaganolWordMaker(firstXCoord, firstYCoord, secondXCoord, secondYCoord, grid);
                    wordCorrect = WordChecker(madeByUser, allWords, wordCounter);

                    if (foundWords.Contains(madeByUser))
                    {
                        Console.WriteLine("That Word Has Already Been Found");
                    }
                    else
                    {
                        wordCounter++;
                        foundWords.Add(madeByUser);
                    }

                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(madeByUser + " is not a word");
                    Console.Clear();
                }
            } while (wordCounter < numberOfWords);


            Console.WriteLine("Well done you found all of the words!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}