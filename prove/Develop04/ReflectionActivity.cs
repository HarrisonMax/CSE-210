using System;
using System.Collections.Generic;
using System.Threading;

namespace WellnessActivitiesProgram
{
    public class ReflectionActivity : Activity
    {
        private readonly string[] Prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly string[] ReflectionQuestions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life.")
        {
        }

        public override void PerformActivity()
        {
            Console.WriteLine("Reflecting on a meaningful experience...");
            string prompt = Prompts[new Random().Next(Prompts.Length)];
            Console.WriteLine($"\nReflect on the following prompt:\n{prompt}\n");
            PauseWithSpinner(5);
            AskReflectionQuestions();
        }

        private void AskReflectionQuestions()
        {
            foreach (var question in ReflectionQuestions)
            {
                Console.WriteLine(question);
                PauseWithSpinner(5);
            }
        }
    }
}