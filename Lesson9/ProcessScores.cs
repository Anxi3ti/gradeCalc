using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Lesson9
{
    public class ProcessScores
    {
        private int[][] studentArray;
        private int numScores = 0;
      

        public void SetUp()
        {
            
            Console.WriteLine("Enter the number of students.");
            int numStudents = getDataInput();
            Console.WriteLine("Enter the desired number of scores: ");
            numScores = getDataInput();

            studentArray = new int[numStudents][];
        }

        private int getDataInput(bool scoreValue = false)
        {
            bool validInput = false;
            int dataInput = 0;
            while (!validInput)
            {
                try
                {
                    dataInput = int.Parse(Console.ReadLine());
                    
                    if (dataInput > 0 || (scoreValue && !(dataInput < 0)))
                    {
                        validInput = true;
                    }
                    else
                    {
                        validInput = false;
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            return dataInput;
        }

        public void Process()
        {
            for (int i = 0; i < studentArray.Length; i++)
            {
                studentArray[i] = new int[numScores];
                for (int j = 0; j < numScores; j++)
                {
                    studentArray[i][j] = inputScore(i);
                }
            }
        }

        private int inputScore(int student)
        {
            
            Console.WriteLine("Input next score for student {0}: ",student+1);
            int score = getDataInput(true);
            return score;
        }

        private bool ValidateInput(int score)
        {
            if (score < 0 || score > 100)
            {
                Console.WriteLine("Please enter a score between 0 & 100.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void calcStudentScores()
        {
            for (int i = 0; i < studentArray.Length; i++)
            {
                calcGrade(i);
            }
        }

        private void calcGrade(int student)
        {
            int sumScores = 0;

            for (int j = 0; j < numScores; j++)
            {
                sumScores += studentArray[student][j];
            }
            String letterGrade = "";
            
            int totalScore = sumScores / studentArray.Length;

            switch (totalScore)
            {
                case var n when n >= 90:
                    letterGrade = "A";
                    break;
                case var n when n < 90 && n >= 80:
                    letterGrade = "B";
                    break;
                case var n when n < 80 && n >= 70:
                    letterGrade = "C";
                    break;
                case var n when n < 70 && n >= 60:
                    letterGrade = "D";
                    break;
                case var n when n < 60:
                    letterGrade = "F";
                    break;

            }

            Console.WriteLine("Student {0} total score is: {1}",student +1, sumScores);
            Console.WriteLine("Student {0} letter grade is : {1}", student +1, letterGrade);
        }
    }
}

  
