using System;
using System.Threading;

namespace WellnessActivitiesProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through breathing exercises.")
        {
        }

        public override void PerformActivity()
        {
            Console.WriteLine("Starting breathing cycle...");
            int cycles = Duration / 4; // Each cycle consists of 4 seconds (2s breathe in + 2s breathe out)
            for (int i = 0; i < cycles; i++)
            {
                BreatheIn();
                BreatheOut();
            }
        }

        private void BreatheIn()
        {
            Console.WriteLine("Breathe in...");
            PauseWithSpinner(2);
        }

        private void BreatheOut()
        {
            Console.WriteLine("Breathe out...");
            PauseWithSpinner(2);
        }
    }
}