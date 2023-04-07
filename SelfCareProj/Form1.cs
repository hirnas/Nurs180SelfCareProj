using System;
using System.Threading.Channels;
using System.Windows.Forms;

namespace SelfCareProj
{
    public partial class Form1 : Form
    {
        int baseStressValue = 0;
        private TaskCompletionSource<bool> _tcs;
        int tempInt = 0;
        string tempstr;
        bool tempBool = false;
        public Form1()
        {
            InitializeComponent();
            StressBar.Value = 50;
            KeyPreview = true;
            KeyPress += Form1_KeyPress;
            Tutorial();
        }

        private async Task Tutorial()
        {
            GameOutputScreen.Clear();
            GameOutputScreen.AppendText("It is the week before exams, tensions are at an all time high and everyone is stressed, " +
                "nearing the end of term, you are nearing burnout and have one final week of lessons to go, how will you balance your work so you don’t overexert yourself?"
                + Environment.NewLine + "(press the enter key to continue)");
            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            GameOutputScreen.Clear();
            GameOutputScreen.AppendText("This game is based on a day in the life of me, the narrator."
                + Environment.NewLine + "(press the enter key to continue)");
            UserInputBox.Focus();
            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            GameOutputScreen.Clear();
            GameOutputScreen.AppendText("The weekend is over, you sleep soundly as you prepare yourself for the most dreaded and stressful day of the week: Monday, with your first lesson at 11am."
                + Environment.NewLine + "(enter the time at which you want to wake up, " + Environment.NewLine +
                "as a single number for the hour, between 4 and 15 in the textbox below)");
            int result;
            while (true)
            {
                _tcs = new TaskCompletionSource<bool>();
                await _tcs.Task;
                if (int.TryParse(UserInputBox.Text, out result) && result < 16 && result > 3)
                {
                    tempInt = result;
                    UserInputBox.Clear();
                    break;
                }
                else
                {
                    GameOutputScreen.Clear();
                    GameOutputScreen.AppendText("invalid input, please try again, must be a number between 4 and 15 inclusive");
                    UserInputBox.Clear();
                }
            }

            tempInt = result;
            GameOutputScreen.Clear();
            if (result < 7)
            {
                GameOutputScreen.AppendText("you are up very early, maybe you had a bad dream or something, unless you slept rather early the night before, you are not getting enough sleep, " +
                    "it is suggested for teens to have 8-10 hours of sleep, and adults to have 7-9. Your lack of sleep may have adverse effects and may make you more on edge, " +
                    "increasing your stress levels." + Environment.NewLine + "{stress +10}" + Environment.NewLine + "do you:" + Environment.NewLine + "Go back to sleep?" +
                    Environment.NewLine + "Stay awake?" + Environment.NewLine + "input the value of the option, they are ordered top to bottom, from 1.");
                UpdateStressBar(10);
                while (true)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    if (int.TryParse(UserInputBox.Text, out result) && result < 3 && result > 0)
                    {
                        UserInputBox.Clear();
                        break;
                    }
                    else
                    {
                        GameOutputScreen.Clear();
                        GameOutputScreen.AppendText("invalid input, please try again, must be 1 or 2");
                        UserInputBox.Clear();
                    }
                }

                GameOutputScreen.Clear();
                if (result == 1)
                {
                    GameOutputScreen.AppendText("You go back to sleep and wake up at 10, this is what I would do, however this is because I almost never wake up at this hour voluntarily." +
                        Environment.NewLine + "{stress -5}");
                    UpdateStressBar(-5);
                }
                else
                {
                    GameOutputScreen.AppendText("You decide to stay awake until your first lesson, I would not do this, " +
                        "this would keep me drowsy and unfocused for the rest of the day, I would find this to lower my mood, " +
                        "stress me out, and not be able to do what I would normally." + Environment.NewLine + "{stress +10}");
                    UpdateStressBar(10);
                }
                GameOutputScreen.AppendText(Environment.NewLine + "(press enter to continue)");

            }
            else if (result == 7 || result == 8)
            {
                GameOutputScreen.AppendText("hopefully you had an early night in order to get the amount of sleep that you need, since you’re up so early " +
                    "maybe you can go for a run or go to the gym, or do a bit of work before your first lesson, I personally would have prioritized sleep " +
                    "over that and sleep for an hour or two more." + Environment.NewLine + "{stress +5}" + Environment.NewLine + "do you:" + Environment.NewLine + "Go to the gym?" +
                    Environment.NewLine + "Go for a run?" + Environment.NewLine + "Get some work done?" + Environment.NewLine + "input the value of the option, they are ordered top to bottom, from 1.");
                UpdateStressBar(5);
                while (true)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    if (int.TryParse(UserInputBox.Text, out result) && result < 4 && result > 0)
                    {
                        UserInputBox.Clear();
                        break;
                    }
                    else
                    {
                        GameOutputScreen.Clear();
                        GameOutputScreen.AppendText("invalid input, please try again, must be a number from 1-3");
                        UserInputBox.Clear();
                    }
                }

                GameOutputScreen.Clear();
                if (result == 1)
                {
                    GameOutputScreen.AppendText("You decide to go to the gym for a workout before your lessons, you get back in time to prepare for your first lesson. This is a good choice, " +
                        "but I would rather spend some time exercising outside instead, getting some fresh air helps me clear my mind and be more mindful of what I might be doing during the day. " +
                        Environment.NewLine + "{stress -10}");
                    UpdateStressBar(-10);
                }
                else if (result == 2)
                {
                    GameOutputScreen.AppendText("Great decision, you get to exercise and spend time outdoors breathing in the fresh air, you get back in time to prepare for your first lesson. " +
                        "I would most likely choose this over going to the gym if the weather is nice since I find the outdoors to help me destress and clear my head." + Environment.NewLine + "{stress -15} ");
                    UpdateStressBar(-15);
                }
                else
                {
                    GameOutputScreen.AppendText("Nice, you get some progress on that end of term project you were stressed about, and got to add some fresh ideas for it that you had when you woke up " +
                        Environment.NewLine + "{stress -5}");
                    UpdateStressBar(-5);
                }
                GameOutputScreen.AppendText(Environment.NewLine + "(press enter to continue)");

            }
            else if (result == 9 || result == 10)
            {
                GameOutputScreen.AppendText("great, this is what I would do too, this allows you to get more than enough sleep and still have more than enough time to get ready for the lesson" +
                    Environment.NewLine + "{Stress -5}" + Environment.NewLine + "(press enter to continue)");
                UpdateStressBar(-5);
            }
            else
            {
                tempInt = result - 10;
                GameOutputScreen.AppendText("maybe you had a very late night or was exhausted, you may have missed the first" + (tempInt > 3 ? "3" : tempInt.ToString()) + "lessons, but sometimes it is good to take " +
                    "a break if you are overwhelmed or too tired instead of pushing yourself too far, personally I may skip the first lecture of the day if that was the case for me, but I would " +
                    "be too paranoid to miss more than that." + Environment.NewLine + "{stress +" + (tempInt * 5).ToString() + "}" + Environment.NewLine + "(press enter to continue)");
                UpdateStressBar(5 * tempInt);
                tempInt = result;
            }

            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            GameOutputScreen.Clear();
            if (tempInt < 11)
            {
                GameOutputScreen.AppendText("It is about time to get ready for lessons, you got changed and packed your bags, you might have some time to have some breakfast, do you:" + Environment.NewLine +
                    "Have a decent breakfast before heading to your lesson?" + Environment.NewLine + "Grab whatever you can find on your way to your lesson?" + Environment.NewLine +
                    "Just head out, you can always get an early lunch?" + Environment.NewLine + "input the value of the option, they are ordered top to bottom, from 1.");
                while (true)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    if (int.TryParse(UserInputBox.Text, out result) && result < 4 && result > 0)
                    {
                        UserInputBox.Clear();
                        break;
                    }
                    else
                    {
                        GameOutputScreen.Clear();
                        GameOutputScreen.AppendText("invalid input, please try again, must be a number from 1-3");
                        UserInputBox.Clear();
                    }
                }
                GameOutputScreen.Clear();
                if (result == 1)
                {
                    GameOutputScreen.AppendText("Nice, having this in your system will improve your mood and keep you energized for the day, this is what I would do, and is what I do on most days." +
                        Environment.NewLine + "{stress -5}");
                    UpdateStressBar(-5);
                }
                else if (result == 2)
                {
                    GameOutputScreen.AppendText("At least you’re eating something, but a balanced diet is important to manage your mood, and doing this constantly is not a good thing. I wouldn’t do this, " +
                        "the time it takes for me to get a balanced meal outside would take about the same if not longer than it would take me to cook one at home. Most of the time I would have prepared for " +
                        "breakfast the day before, or make something simple.");
                }
                else
                {
                    GameOutputScreen.AppendText("Not great, you realized that you have a decently packed schedule for a few hours and won’t be able to grab a bite to eat, I always try to get something in my " +
                        "system before I start my day properly, especially if I have time to spare." + Environment.NewLine + "{stress +10}");
                    UpdateStressBar(10);
                    tempBool = true;
                }
                tempInt = 1;
            }
            else if (tempInt == 11 || tempInt == 12)
            {
                GameOutputScreen.AppendText("you have a lecture in less than an hour that you can still get to on time, do you:" + Environment.NewLine +
                    "Skip this lesson as well?" + Environment.NewLine + "Grab a bite before heading to this lecture?" + Environment.NewLine +
                    "Head to the lecture so you aren’t late to this one as well?" + Environment.NewLine + "input the value of the option, they are ordered top to bottom, from 1.");
                while (true)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    if (int.TryParse(UserInputBox.Text, out result) && result < 4 && result > 0)
                    {
                        UserInputBox.Clear();
                        break;
                    }
                    else
                    {
                        GameOutputScreen.Clear();
                        GameOutputScreen.AppendText("invalid input, please try again, must be a number from 1-3");
                        UserInputBox.Clear();
                    }
                }
                GameOutputScreen.Clear();
                if (result == 1)
                {
                    GameOutputScreen.AppendText("You may be having a bad day, but this may contribute to stressing you out even more. I would not do this unless I had a really tight deadline to meet." +
                        Environment.NewLine + "{stress +5}");
                    UpdateStressBar(5);
                }
                else if (result == 2)
                {
                    GameOutputScreen.AppendText("I would do this too, even if you have missed a lecture or two it is definitely worth it to go to a lecture instead of giving up altogether, it is also a " +
                        "good choice to grab food before doing so, this will improve your mood and maybe make up for you waking up to missing a lecture." + Environment.NewLine + "{stress -5}");
                    UpdateStressBar(5);
                }
                else
                {
                    GameOutputScreen.AppendText("You are stressing yourself out, you shouldn’t wake up and head directly to your lecture without even eating anything, that could’ve had a chance to calm you " +
                        "down and made up for waking up to missing a lesson. This is something I would not do." + Environment.NewLine + "{stress +10}");
                    UpdateStressBar(10);
                }
                tempInt = 1;
            }
            else
            {
                GameOutputScreen.AppendText("you’ve just missed most of your lectures of the day, now you have some time to kill before your nursing 180 synchronous lecture at 4, do you:" + Environment.NewLine +
                    "Get some food?" + Environment.NewLine + "Get some work done?" + Environment.NewLine +
                    "Rest a bit before joining the zoom call?" + Environment.NewLine + "input the value of the option, they are ordered top to bottom, from 1.");
                while (true)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    if (int.TryParse(UserInputBox.Text, out result) && result < 4 && result > 0)
                    {
                        UserInputBox.Clear();
                        break;
                    }
                    else
                    {
                        GameOutputScreen.Clear();
                        GameOutputScreen.AppendText("invalid input, please try again, must be a number from 1-3");
                        UserInputBox.Clear();
                    }
                }
                GameOutputScreen.Clear();
                if (result == 1)
                {
                    GameOutputScreen.AppendText("You should probably do this, you most likely haven’t had a meal in over 12 hours, this isn’t exactly great for your physical or mental health, " +
                        "this is what I would do before anything else." + Environment.NewLine + "{stress -5}");
                    UpdateStressBar(-5);
                    tempInt = 2;
                }
                else if (result == 2)
                {
                    GameOutputScreen.AppendText("To be fairly honest, if I were to wake up later in the afternoon about 2 or 3, I would most likely also get some work done, and end up having an " +
                        "earlier dinner instead, but if it is a bit earlier in the afternoon, I would definitely say that grabbing a bite would be beneficial. Though getting some work out of the " +
                        "way may improve stress levels, not having food in your system might put you in a foul mood." + Environment.NewLine + "{stress +10}");
                    UpdateStressBar(10);
                    tempInt = 3;
                }
                else
                {
                    GameOutputScreen.AppendText("I would not do this, not only have you skipped ¾ lectures today, you also have not gotten any work done, at this point you will most likely stay up " +
                        "late, be really stressed, or both, this has a bad effect on your mental health." + Environment.NewLine + "{stress +15}");
                    UpdateStressBar(15);
                    tempInt = 3;
                }
            }
            GameOutputScreen.AppendText(Environment.NewLine + "(press enter to continue)");
            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            GameOutputScreen.Clear();
            if (tempInt == 1 || tempInt == 2)
            {
                if (tempInt == 1)
                {
                    GameOutputScreen.AppendText("You have just finished most of your lectures of the day, its now 2. If I didn’t have breakfast I would be grabbing lunch right now. You have your nursing " +
                        "180 synchronous lecture at 4, " + (tempBool ? "after eating your lunch" : "") + "you have a few hours to kill, do you want to:");
                }
                else
                {
                    GameOutputScreen.AppendText("You’ve had something to eat, you still have some time to kill before nursing, do you want to:");
                }
                GameOutputScreen.AppendText(Environment.NewLine + "Get some work done?" + Environment.NewLine + "Just chill, maybe hang out with friends or some alone time?" + Environment.NewLine +
                    "Go out for a walk, maybe with friends?" + Environment.NewLine + "input the value of the option, they are ordered top to bottom, from 1.");
                while (true)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    if (int.TryParse(UserInputBox.Text, out result) && result < 4 && result > 0)
                    {
                        UserInputBox.Clear();
                        break;
                    }
                    else
                    {
                        GameOutputScreen.Clear();
                        GameOutputScreen.AppendText("invalid input, please try again, must be a number from 1-3");
                        UserInputBox.Clear();
                    }
                }
                GameOutputScreen.Clear();
                if (result == 1)
                {
                    GameOutputScreen.AppendText("Nice, you got some worries off your chest about that project you have due in a few days, I might do this sometimes, " +
                        "but after three hours straight of lectures, I tend to take a slight break from work before my last lecture of the day." + Environment.NewLine + "{stress -5}");
                    UpdateStressBar(-5);
                    tempInt = 2;
                }
                else if (result == 2)
                {
                    GameOutputScreen.AppendText("Great, some well deserved rest after 3 hours straight of lectures, I would take this time to recollect my thoughts, " +
                        "calm down, and maybe plan out my work for the evening." + Environment.NewLine + "{stress -10}");
                    UpdateStressBar(-10);
                    tempInt = 3;
                }
                else
                {
                    GameOutputScreen.AppendText("Good choice, if the weather was good I might’ve done this as well, spending time outdoors can refresh your mind, " +
                        "it certainly does for me, quite well at that. However, make sure to get back in time for nursing, it may be hard to keep track of time outside!" + Environment.NewLine + "{stress -15}");
                    UpdateStressBar(-15);
                    tempInt = 3;
                }
                GameOutputScreen.AppendText(Environment.NewLine + "(press enter to continue)");
                _tcs = new TaskCompletionSource<bool>();
                await _tcs.Task;
                GameOutputScreen.Clear();
            }
            GameOutputScreen.AppendText("Its time for nursing. Following along with the lesson’s breathing exercises and other techniques may help you manage your stress. " +
                "This lecture is a lot less stressful to me than my usual lectures, it allows me to wind down and is a nice ending to my Mondays." +
                Environment.NewLine + "(press enter to continue)");
            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            GameOutputScreen.Clear();
            GameOutputScreen.AppendText("Nursing just finished and you got a bit of work done, its about 6 or 7. What do you do now?" + Environment.NewLine + "Go out and grab some dinner" +
                Environment.NewLine + "Eat at home, cook/delivery" + Environment.NewLine + "Work" + Environment.NewLine + "Have some down time" + Environment.NewLine + "input the value of the option, they are ordered top to bottom, from 1.");
            while (true)
            {
                _tcs = new TaskCompletionSource<bool>();
                await _tcs.Task;
                if (int.TryParse(UserInputBox.Text, out result) && result < 5 && result > 0)
                {
                    UserInputBox.Clear();
                    break;
                }
                else
                {
                    GameOutputScreen.Clear();
                    GameOutputScreen.AppendText("invalid input, please try again, must be a number from 1-4");
                    UserInputBox.Clear();
                }
            }
            GameOutputScreen.Clear();
            if (result == 1)
            {
                GameOutputScreen.AppendText("It is good that you are grabbing dinner, however it may take more time than making your meal or ordering delivery, shortening the time you have to do other activities, though you are getting some time outside, " +
                    "from my experience, it might have an overall negative impact on your stress levels." + Environment.NewLine + "{stress +5}" + Environment.NewLine + "(press enter to continue)");
                UpdateStressBar(5);
                _tcs = new TaskCompletionSource<bool>();
                await _tcs.Task;
                GameOutputScreen.Clear();
                GameOutputScreen.AppendText("After grabbing dinner out with some friends, you decide to get some work done and get some downtime afterwards, what");

            }
            else if (result == 2)
            {
                GameOutputScreen.AppendText("This is what I do, mostly I cook, cooking allows you to control what you eat more, and I also find it to be destressing " +
                    "at times, cooking allows you to take your mind off work, and may find you a new hobby as it did me!" + Environment.NewLine + "(press enter to continue)");
                _tcs = new TaskCompletionSource<bool>();
                await _tcs.Task;
                GameOutputScreen.Clear();
                GameOutputScreen.AppendText("Ordering takeaway is also a relatively good option, it saves you time especially if you have a lot of work to do, you still control your diet to a degree, " +
                    "and can allow you to manage your time better." + Environment.NewLine + "{stress - 5}" + Environment.NewLine + "(press enter to continue)");
                UpdateStressBar(-5);
                _tcs = new TaskCompletionSource<bool>();
                await _tcs.Task;
                GameOutputScreen.Clear();
                GameOutputScreen.AppendText("You are energized after having your dinner, having finished school for the day you decide to finish up some work and spend some of your free time doing something you love." + Environment.NewLine + "What");
            }
            else if (result == 3)
            {
                GameOutputScreen.AppendText("If I had a lot of work I may be tempted to do this, but I would in most cases have dinner first. I find not having had food prior to attempting to work after a long day to result in a lot of procrastination. " +
                    "You end up procrastinating for a few hours before finally picking up some work, but you still struggle to focus and get distracted every now and then." + Environment.NewLine + "{stress +10}" + Environment.NewLine + "What");
                UpdateStressBar(10);
            }
            else
            {
                GameOutputScreen.AppendText("Sometimes I might do this too, I might do this if I had a pretty late lunch and have little to no work to do for the week, I would chill for a bit, and maybe grab a bite later on in the evening if I do get hungry, " +
                    "I find this gives me time to organize my thoughts and do things I love. Overall, this choice is completely valid in some cases." + Environment.NewLine + "{stress -10}" + Environment.NewLine + "What");
                UpdateStressBar(-10);
            }

            GameOutputScreen.AppendText(" time do you want to stay up until? Your first lesson tomorrow is at 10." + Environment.NewLine + "(input an hour between 10pm and 6am, as a single number in 24hr format. E.g. 22 for 10pm, 24 for midnight)");
            while (true)
            {
                _tcs = new TaskCompletionSource<bool>();
                await _tcs.Task;
                if (int.TryParse(UserInputBox.Text, out result) && ((result < 25 && result > 21) || (result < 7 && result > 0)))
                {
                    tempInt = result;
                    UserInputBox.Clear();
                    break;
                }
                else
                {
                    GameOutputScreen.Clear();
                    GameOutputScreen.AppendText("invalid input, please try again, must be a number between 22 and 24, or 1 and 6 inclusive");
                    UserInputBox.Clear();
                }
            }

            tempInt = result;
            GameOutputScreen.Clear();
            if (result > 21)
            {
                GameOutputScreen.AppendText("This is a decent time to sleep, you will get plenty of sleep, making sure that you are energized for tomorrow.");
            }
            else if (result < 4)
            {
                GameOutputScreen.AppendText("this is understandable if you feel productive or have some work that you have to do, I also normally sleep between " +
                    "midnight and 3am, but since your lesson tomorrow specifically is at 10, you may not get the amount of sleep that you want." + Environment.NewLine + "{stress +5}");
                UpdateStressBar(5);
            }
            else
            {
                GameOutputScreen.AppendText("this is too late, you will wake up drowsy and drained, this is good for neither your mental or physical health, " +
                    "may stop you from waking up on time, may keep you unfocused for the day, I would not do this, nor suggest anyone do this." + Environment.NewLine + "{stress +10}");
                UpdateStressBar(10);
            }
            GameOutputScreen.AppendText(Environment.NewLine + "(press enter to continue)");
            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            GameOutputScreen.Clear();
            GameOutputScreen.AppendText("what time do you wake up at?" + Environment.NewLine + "(enter a number between 6 and 15)");
            while (true)
            {
                _tcs = new TaskCompletionSource<bool>();
                await _tcs.Task;
                if (int.TryParse(UserInputBox.Text, out result) && (result < 16 && result > 5))
                {
                    UserInputBox.Clear();
                    break;
                }
                else
                {
                    GameOutputScreen.Clear();
                    GameOutputScreen.AppendText("invalid input, please try again, must be a number between 6 and 15 inclusive");
                    UserInputBox.Clear();
                }
            }
            int hoursSlept;
            if (tempInt > 10)
            {
                tempInt -= 24;
            }
            hoursSlept = result - tempInt;
            GameOutputScreen.Clear();
            GameOutputScreen.AppendText("you have slept for " + hoursSlept + " hours, ");
            if (hoursSlept < 6)
            {
                GameOutputScreen.AppendText("you are not getting enough sleep, the suggested amount of sleep is 7-9 hours for adults, " +
                    "and 8-10 for teens, I tend to aim for 8 hours a day, your head will feel foggy and heavy for the day, this makes you inattentive, " +
                    "and may increase your stress." + Environment.NewLine + "{stress +15}");
                UpdateStressBar(15);
            }
            else if (hoursSlept < 10)
            {
                GameOutputScreen.AppendText("for me 6-9 hours is the sweet spot, 6 hours though slightly lacking is just enough to keep me ready for the day, " +
                    "and any more than 9 hours and I might want to sleep more. This is ok, you are just about getting the recommended hours of sleep, " +
                    "and are ready for the day to come." + Environment.NewLine + "{stress -10}");
                UpdateStressBar(-10);
            }
            else if (hoursSlept == 10)
            {
                GameOutputScreen.AppendText("this is the border between just right and too much, any more than this and you may feel groggy, this is ok, " +
                    "but you might have trouble sleeping tonight. Personally, this may be a bit too much, though it varies from person to person." + Environment.NewLine + "{stress +5}");
                UpdateStressBar(5);
            }
            else
            {
                GameOutputScreen.AppendText("this is a lot of sleep, you are losing a lot of time during the day and this may make you more stressed, " +
                    "this may also prevent you from sleeping when you want to tonight and you might feel a bit heavy for the rest of the day from sleeping so much. " +
                    "I avoid this." + Environment.NewLine + "{stress +5}");
                UpdateStressBar(10);
            }
            GameOutputScreen.AppendText("(press enter to continue)");
            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            GameOutputScreen.Clear();
            GameOutputScreen.AppendText("Well done! You survived! That was a brief day in my life and the possible routes of that day, you started the game with a stress level of 50, and ended with a stress level of "
                + StressBar.Value + " out of 100!" + Environment.NewLine);
            if (StressBar.Value < 20)
            {
                GameOutputScreen.AppendText("Wow! you managed to lower your overall stress levels from the start by a considerable amount!");
            }
            else if (StressBar.Value < 61)
            {
                GameOutputScreen.AppendText("You managed to keep your stress level pretty close to what you started with, you made pretty balanced choices, well done!");
            }
            else if (StressBar.Value < 80)
            {
                GameOutputScreen.AppendText("Your stress levels had increased over the day, but still at a somewhat managed level, next time maybe try to change up your choices a little bit since you were close to reaching burnout.");
            }
            else
            {
                GameOutputScreen.AppendText("That may not be the best score, you were extremely close to burnout, next time maybe try reconsidering some choices. At this score, not just your mental, but also physical health would be affected, watch out!");
            }
            GameOutputScreen.AppendText(Environment.NewLine + "Do remember that these scores are arbitrary and according to what I have experienced, I do understand that it may not be the most accurate representation of what you may experience in real life."
                + Environment.NewLine + "Thank you for playing!" + Environment.NewLine + "Do feel free to play again to see what other routes or scores you can get!" + Environment.NewLine + "press enter to exit the application");
            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                _tcs?.TrySetResult(true);
            }
        }

        public void UpdateStressBar(int x)
        {
            Thread.Sleep(100);
            if (StressBar.Value + x > baseStressValue && StressBar.Value + x < 100) 
            { 
                StressBar.Value += x;
            } 
            else if (StressBar.Value + x < baseStressValue)
            {
                StressBar.Value = baseStressValue;
            }
            else
            {
                StressBar.Value = 100;
                StressBar.ForeColor = Color.Red;
                GameOutputScreen.Clear();
                GameOutputScreen.AppendText("Oh no! you got too stressed and reached burnout, maybe you can try again." + Environment.NewLine + "the application will automatically close momentarily");
                Thread.Sleep(5000);
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void StressBar_Click(object sender, EventArgs e)
        {

        }
    }
}