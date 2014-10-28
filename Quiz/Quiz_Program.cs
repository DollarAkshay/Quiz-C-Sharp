using System;
using System.Threading;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz{

    struct Question {
        public string q;
        public string[] choice;
        public char ans;
        public bool media;
    }

    class Quiz_Program{

        static Question[] QBank = new Question[10];
        static int[] remaining = new int[10];
        static SpeechSynthesizer synth = new SpeechSynthesizer();
        static int MAX = 6;
        static double fast = 1;


        static void intro(){

            synth.SpeakAsync("Welcome, to the Greatest Noob Quiz created by, Aakshay. Prepare to be amazed, ladies and gentlemen. I'm Peter, and I shall be the host for the day. Hope you enjoy, playing this quiz. Lets Begin. , ,");

            Console.SetWindowPosition(0, 0);
            Console.WindowWidth = 110;

            int freq = 3;
            int r=-3*freq, y=-2*freq, g=-1*freq, b=0,i;

            for (; r <110+freq; r++, y++, g++, b++){
                Console.Clear();
                for (i = 0; i < 110; i++){
                    if (i > b-freq && i <= b)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (i > g - freq && i <= g)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (i > y - freq && i <= y)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else if (i > r - freq && i <= r)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    if(i<50)
                        Console.Write("█");
                    else if(i<52 || (i>=52 && i<=58 && i%2==1))
                        Console.Write(" ");
                    else if (i == 52){
                        if(r>=52)
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Q");
                    }
                    else if (i == 54){
                        if (y >= 54)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("U");
                    }
                    else if (i == 56){
                        if (g >= 56)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("I");
                    }
                    else if (i == 58){
                        if (b >= 58)
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Z");
                    }
                    else if (i <= 60)
                        Console.Write(" ");
                    else if (i < 110)
                        Console.Write("█");
                }
                Thread.Sleep((int)(110/fast));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            
        }

        static void initializeQuestions(){
            
            const string format = "{0,-40}";

            //Question 1
            QBank[0].q = "What does the fox say ?";
            QBank[0].choice = new String[4];
            QBank[0].choice[0] = string.Format(format, "Meow");
            QBank[0].choice[1] = string.Format(format, "Woof-Woof");
            QBank[0].choice[2] = string.Format(format, "Chacha-chacha-chacha-chow!");
            QBank[0].choice[3] = string.Format(format, "Moo");
            QBank[0].ans = 'C';
            QBank[0].media = false;

            //Question 2
            QBank[1].q = "What is the first letter in the english alphabet ?";
            QBank[1].choice = new String[4];
            QBank[1].choice[0] = string.Format(format, "C");
            QBank[1].choice[1] = string.Format(format, "D");
            QBank[1].choice[2] = string.Format(format, "A");
            QBank[1].choice[3] = string.Format(format, "B");
            QBank[1].ans = 'C';
            QBank[1].media = false;

            //Question 3
            QBank[2].q = "Why do Java programmers wear glasses ?";
            QBank[2].choice = new String[4];
            QBank[2].choice[0] = string.Format(format, "Because they can");
            QBank[2].choice[1] = string.Format(format, "Because they are big nerds.");
            QBank[2].choice[2] = string.Format(format, "Because they love Frames");
            QBank[2].choice[3] = string.Format(format, "Because they cant C#");
            QBank[2].ans = 'D';
            QBank[2].media = false;

            //Question 4
            QBank[3].q = "What is Debugging ?";
            QBank[3].choice = new String[4];
            QBank[3].choice[0] = string.Format(format, "Removing insects from under the bed");
            QBank[3].choice[1] = string.Format(format, "Removing the needles from the haystack");
            QBank[3].choice[2] = string.Format(format, "Asking someone to stop bugging you");
            QBank[3].choice[3] = string.Format(format, "Something that your supervisor asks you to do");
            QBank[3].ans = 'B';
            QBank[3].media = false;

            //Question 5
            QBank[4].q = "What is WYSIWYMGIYRRLAAGW ?";
            QBank[4].choice = new String[4];
            QBank[4].choice[0] = string.Format(format, "Huh ?");
            QBank[4].choice[1] = string.Format(format, "Can't answer. Not in syllabus");
            QBank[4].choice[2] = string.Format(format, "Lady Gaga's Latest Song");
            QBank[4].choice[3] = string.Format(format, "What You See Is What You Might Get If You’re Really Really Lucky And All Goes Well");
            QBank[4].ans = 'D';
            QBank[4].media = false;

            //Question 6
            QBank[5].q = "Can you recognise this audio clip ?";
            QBank[5].choice = new String[4];
            QBank[5].choice[0] = string.Format(format, "National Anthem of Toyland");
            QBank[5].choice[1] = string.Format(format, "Justin Beiber when he has reached puberty");
            QBank[5].choice[2] = string.Format(format, "Theme music of Avengers");
            QBank[5].choice[3] = string.Format(format, "Italian Plumber's Music");
            QBank[5].ans = 'D';
            QBank[5].media = true;

            for (int i = 0; i <MAX; i++){
                remaining[i] = i;
            }
        
        }

        static void playMedia(int n){

            switch (n){
                case 5:
                    Console.Beep(659, 125);
                    Console.Beep(659, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(167);
					Console.Beep(523, 125);
					Console.Beep(659, 125);
					Thread.Sleep(125);
					Console.Beep(784, 125);
					Thread.Sleep(375);
					Console.Beep(392, 125);
					Thread.Sleep(375);
					Console.Beep(523, 125);
					Thread.Sleep(250);
					Console.Beep(392, 125);
					Thread.Sleep(250);
					Console.Beep(330, 125);
					Thread.Sleep(250);
					Console.Beep(440, 125);
					Thread.Sleep(125);
					Console.Beep(494, 125);
					Thread.Sleep(125);
					Console.Beep(466, 125);
					Thread.Sleep(42);
					Console.Beep(440, 125);
					Thread.Sleep(125);
					Console.Beep(392, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(125);
					Console.Beep(784, 125);
					Thread.Sleep(125);
					Console.Beep(880, 125);
					Thread.Sleep(125);
					Console.Beep(698, 125);
					Console.Beep(784, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(125);
					Console.Beep(523, 125);
					Thread.Sleep(125);
					Console.Beep(587, 125);
					Console.Beep(494, 125);
					Thread.Sleep(125);
					Console.Beep(523, 125);
					Thread.Sleep(250);
					Console.Beep(392, 125);
					Thread.Sleep(250);
					Console.Beep(330, 125);
					Thread.Sleep(250);
					Console.Beep(440, 125);
					Thread.Sleep(125);
					Console.Beep(494, 125);
					Thread.Sleep(125);
					Console.Beep(466, 125);
					Thread.Sleep(42);
					Console.Beep(440, 125);
					Thread.Sleep(125);
					Console.Beep(392, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(125);
					Console.Beep(784, 125);
					Thread.Sleep(125);
					Console.Beep(880, 125);
					Thread.Sleep(125);
					Console.Beep(698, 125);
					Console.Beep(784, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(125);
					Console.Beep(523, 125);
					Thread.Sleep(125);
					Console.Beep(587, 125);
					Console.Beep(494, 125);
					Thread.Sleep(375);
					Console.Beep(784, 125);
					Console.Beep(740, 125);
					Console.Beep(698, 125);
					Thread.Sleep(42);
					Console.Beep(622, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(167);
					Console.Beep(415, 125);
					Console.Beep(440, 125);
					Console.Beep(523, 125);
					Thread.Sleep(125);
					Console.Beep(440, 125);
					Console.Beep(523, 125);
					Console.Beep(587, 125);
					Thread.Sleep(250);
					Console.Beep(784, 125);
					Console.Beep(740, 125);
					Console.Beep(698, 125);
					Thread.Sleep(42);
					Console.Beep(622, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(167);
					Console.Beep(698, 125);
					Thread.Sleep(125);
					Console.Beep(698, 125);
					Console.Beep(698, 125);
					Thread.Sleep(625);
					Console.Beep(784, 125);
					Console.Beep(740, 125);
					Console.Beep(698, 125);
					Thread.Sleep(42);
					Console.Beep(622, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(167);
					Console.Beep(415, 125);
					Console.Beep(440, 125);
					Console.Beep(523, 125);
					Thread.Sleep(125);
					Console.Beep(440, 125);
					Console.Beep(523, 125);
					Console.Beep(587, 125);
					Thread.Sleep(250);
					Console.Beep(622, 125);
					Thread.Sleep(250);
					Console.Beep(587, 125);
					Thread.Sleep(250);
					Console.Beep(523, 125);
					Thread.Sleep(1125);
					Console.Beep(784, 125);
					Console.Beep(740, 125);
					Console.Beep(698, 125);
					Thread.Sleep(42);
					Console.Beep(622, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(167);
					Console.Beep(415, 125);
					Console.Beep(440, 125);
					Console.Beep(523, 125);
					Thread.Sleep(125);
					Console.Beep(440, 125);
					Console.Beep(523, 125);
					Console.Beep(587, 125);
					Thread.Sleep(250);
					Console.Beep(784, 125);
					Console.Beep(740, 125);
					Console.Beep(698, 125);
					Thread.Sleep(42);
					Console.Beep(622, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(167);
					Console.Beep(698, 125);
					Thread.Sleep(125);
					Console.Beep(698, 125);
					Console.Beep(698, 125);
					Thread.Sleep(625);
					Console.Beep(784, 125);
					Console.Beep(740, 125);
					Console.Beep(698, 125);
					Thread.Sleep(42);
					Console.Beep(622, 125);
					Thread.Sleep(125);
					Console.Beep(659, 125);
					Thread.Sleep(167);
					Console.Beep(415, 125);
					Console.Beep(440, 125);
					Console.Beep(523, 125);
					Thread.Sleep(125);
					Console.Beep(440, 125);
					Console.Beep(523, 125);
					Console.Beep(587, 125);
					Thread.Sleep(250);
					Console.Beep(622, 125);
					Thread.Sleep(250);
					Console.Beep(587, 125);
					Thread.Sleep(250);
					Console.Beep(523, 125);
					Thread.Sleep(1500);
                    break;
            }


        }

        static void askQuestion(int n,int i){

            //Question
            Console.WriteLine("\nQ {0}.{1}",i, QBank[n].q);
            synth.Speak(QBank[n].q);

            //Play Media if any
            if (QBank[n].media){
                playMedia(n);
            }

            //Option A
            synth.Speak("Is it A.");
            Console.Write("A.{0}", QBank[n].choice[0]);
            synth.Speak(QBank[n].choice[0]);
            //Option B
            synth.Speak(", or B.");
            Console.WriteLine("B.{0}", QBank[n].choice[1]);
            synth.Speak(QBank[n].choice[1]);
            //Option C
            synth.Speak(", or C.");
            Console.Write("C.{0}", QBank[n].choice[2]);
            synth.Speak(QBank[n].choice[2]);
            //Option D
            synth.Speak(", or D.");
            Console.WriteLine("D.{0}", QBank[n].choice[3]);
            synth.Speak(QBank[n].choice[3]);

        }

        static int checkAnswer(Question q, char answer){
            if (q.ans == answer) {
                synth.SpeakAsync("You got that one right");
                for (int j = 200; j < 1500; j += 165)
                    Console.Beep(j, 100);
                Thread.Sleep(1000);
                return 10;
            }
            else{
                Random r = new Random();
                int x = r.Next(2);
                if(x==0)
                    synth.SpeakAsync("I'm Sorry. You got that one wrong.");
                else
                    synth.SpeakAsync("Nope, thats not the correct answer.");
                for (int j = 1200; j > 100; j -= 165)
                    Console.Beep(j, 100);
                Thread.Sleep(1500);
                return -5;
            }
        }

        public static void Main(){

            //Initial Configurations
            synth.Rate = (int)(synth.Rate+fast);
            intro();
            initializeQuestions();

            char ans;
            int score=0,i; 

            Random r = new Random();

            for (i = 0; i < MAX; i++){

                //Choosing a random question
                int next = r.Next(MAX-1 - i);
                askQuestion(remaining[next],i+1);
                
                //Reading User's Answer
                ans = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine("");
                while (ans < 65 || ans > 69){
                    Console.WriteLine("Invalid Option.");
                    ans = Char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine("");
                }

                //Checking if Answer is correct
                score+=checkAnswer(QBank[remaining[next]], ans);
                remaining[next] = remaining[MAX - 1 - i];
            }

            Console.WriteLine("Your Score : {0}\n\n",score);
            synth.SpeakAsync("And that concludes our quiz. You have scored " + score + " points. Congratulation. See you next time. ");
            for (i = 0; i < 110; i++){
                Thread.Sleep(50);
                        Console.ForegroundColor = ConsoleColor.White;
                    if(i<50)
                        Console.Write("█");
                    else if(i<52 || (i>=52 && i<=58 && i%2==1))
                        Console.Write(" ");
                    else if (i == 52){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("E");
                    }
                    else if (i == 54){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("X");
                    }
                    else if (i == 56){
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("I");
                    }
                    else if (i == 58){
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("T");
                    }
                    else if (i <= 60)
                        Console.Write(" ");
                    else if (i < 110)
                        Console.Write("█");
                }
            synth.Speak("Thanks for playing");
            synth.Dispose();
            
        }
    }
}