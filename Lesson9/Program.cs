namespace Lesson9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ProcessScores processor =  new ProcessScores();
            processor.SetUp();
            processor.Process();
            processor.calcStudentScores();
        }
    }
}