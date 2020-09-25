using System;

namespace game
{
    class Program
    {
        static string[] GetQuestions(int length)
        {
            string[] questions = new string[length];
            questions[0] = "Сколько будет два плюс два умноженное на два";
            questions[1] = "Бревно нужно распилить на 10 частей, сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно минут для трех уколов?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
        static int[] GetAnswers(int length)
        {
            int[] answers = new int[length];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }
        static string GetDiagnose(double length, double correctAnswers)
        {
            double answerScore = (correctAnswers / length) *100;
            string diagnose = "";
            if(answerScore >= 0 && answerScore < 20)
            {
                diagnose = "Идиот";
            }
            else if(answerScore >= 20 && answerScore < 40)
            {
                diagnose = "Кретин";
            }
            else if(answerScore >= 40 && answerScore < 60)
            {
                diagnose = "Дурак";
            }else if(answerScore >= 60 && answerScore < 80)
            {
                diagnose = "Нормальный";
            }else if(answerScore >= 80 && answerScore < 100)
            {
                diagnose = "Талант";
            }
            else if(answerScore == 100)
            {
                diagnose = "Гений";
            }
            return diagnose;
        }
        static int[] GetRandomSequence(int from, int to)
        {
            Random rnd = new Random();
            int[] a = new int[to];
            a[0] = rnd.Next(from, to);
            for (int i = 1; i < to;)
            {
                int num = rnd.Next(from, to);
                int j;
                for (j = 0; j < i; j++)
                {
                    if (num == a[j])
                        break;
                }
                if (j == i)
                {
                    a[i] = num;
                    i++;
                }
            }
            return a;

        }
        static void Main(string[] args)
        {
            int length = 5;
            string[] questions = GetQuestions(length);
            int[] answers = GetAnswers(length);

            int correctAnswersCount = 0;
            int[] randomNumbersSequence = GetRandomSequence(0, length);
            Console.WriteLine("Введите Ваше ФИО");
            string name = Console.ReadLine();

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Вопрос N:" + (i+1) + ": " + questions[randomNumbersSequence[i]]);
                var usersAnswerAsString = Console.ReadLine();
                int usersAnswerAsNumber;
                while(!int.TryParse(usersAnswerAsString, out usersAnswerAsNumber))
                {
                    Console.WriteLine("Пожалуйста, введите число!");
                    usersAnswerAsString = Console.ReadLine();
                }
               
                var correctAnswer = answers[randomNumbersSequence[i]];

                if (usersAnswerAsNumber == correctAnswer)
                {
                    correctAnswersCount++;
                }
            }

            string usersDiagnose = GetDiagnose(Convert.ToDouble(length), Convert.ToDouble(correctAnswersCount));

            Console.WriteLine(name + ", Ваш диагноз " + usersDiagnose + "!");

        }
    }
}
