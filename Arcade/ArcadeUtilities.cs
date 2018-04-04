using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;


namespace Arcade
{
    public class ArcadeUtilities
    {
        // Set the time in seconds for program shut down if not being used.
        private static int resetValue = 180; 

        private static int countdown;

        const int MAX_HIGHSCORES = 5;
        public static List<int> scoresList = new List<int>();
        public static List<string> namesList = new List<string>();

        public static List<HighScore> highScoreDB = new List<HighScore>();

        public ArcadeUtilities()
        { 
        }

        #region return to Arcade UI when program not in use

        /// <summary>
        /// Creates a timer and timer event to run in the background of the Arcade program.
        /// The timer will countdown from a predetermined value and will shut down
        /// the program if there is no input after that time elapses. Call this method when 
        /// arcade program initializes the main form.
        /// </summary>
        public static void InUseCheck()
        {
            InUseReset();

            Timer inUse = new Timer();
            inUse.Tick += new EventHandler(InUse_Tick);
            inUse.Interval = 1000; //1000ms = 1sec
            inUse.Enabled = true;
            inUse.Start();
        }

        /// <summary>
        /// Timer method used to countdown to 0 from predetermined value and shut down
        /// the program if it gets to 0. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void InUse_Tick(object sender, EventArgs e)
        {
            if (countdown == 0)
            {
                Application.Exit();
            }
            else
            {
                countdown--;
            }
        }

        /// <summary>
        /// Resets the countdown timer value used to determine if program
        /// should be shut down. Call this method whenever the program receives 
        /// input from the user to reset the countdown value. 
        /// This would often be in a Key Press method.
        /// </summary>
        public static void InUseReset()
        {
            countdown = resetValue;
        }

        #endregion

        /// <summary>
        /// Places a blank black background on screen and runs Arcade program
        /// on top of it. Call this method when arcade program initializes the main form.
        /// </summary>
        public static void CreateBackground()
        {
            Form bg = new Form();
            bg.WindowState = FormWindowState.Maximized;
            bg.FormBorderStyle = FormBorderStyle.None;
            bg.BackColor = Color.Black;
            bg.Show();
        }

        #region scoring

        /// <summary>
        /// Loads high scores from highscores.xml file and places into an object list 
        /// within ArcadeUtilities.
        /// </summary>
        public static void LoadScores()
        {
            //open xml file
            XmlTextReader reader = new XmlTextReader("highscores.xml");

            //read through entire xml file
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    //read the first value into the scores list
                    int score = Convert.ToInt16(reader.ReadString());
                    
                    //move to the next value and read it into the names list
                    reader.ReadToNextSibling("name");
                    string name = reader.ReadString();

                    //add high score to object list
                    HighScore newScore = new HighScore(score, name);
                    highScoreDB.Add(newScore);
                }
            }

            //close the file
            reader.Close();
        }     

        public static void SaveScores(int newScore, string newName)
        {
            HighScore newHighScore = new HighScore(newScore, newName);

            if (newScore < highScoreDB[highScoreDB.Count() - 1].score)
            {
                highScoreDB.Add(newHighScore);
            }
            else
            {
                for (int i = 0; i < highScoreDB.Count(); i++)
                {
                    if (newScore > highScoreDB[i].score)
                    {
                        highScoreDB.Insert(i, newHighScore);
                        break;
                    }
                }
            }

            if (highScoreDB.Count() > MAX_HIGHSCORES)
            {
                highScoreDB.RemoveAt(MAX_HIGHSCORES);
            }

            XmlTextWriter writer = new XmlTextWriter("highscores.xml", null);
            writer.Formatting = Formatting.Indented;
            
            //Write the "highscores" root element
            writer.WriteStartElement("highscores");

            for (int i = 0; i < highScoreDB.Count(); i++)
            {
                //Start "highscore" element
                writer.WriteStartElement("highscore");

                //Write sub-elements
                writer.WriteElementString("score", Convert.ToString(highScoreDB[i].score));
                writer.WriteElementString("name", highScoreDB[i].name);

                // end the "highscore" element
                writer.WriteEndElement();
            }

            // end the "highscores" root element
            writer.WriteEndElement();

            //Write the XML to file and close the writer
            writer.Close();
        }
        
        /// <summary>
        /// A screen is presented that allows the user to enter a new high score. 
        /// </summary>
        /// <param name="newValue">High score to be added</param>
        /// <param name="textColor">Color of main body text</param>
        /// <param name="formColor">Color of high score form</param>
        /// <param name="titleColor">Color of title text on high score form</param>
        public static void NewScore(int newValue, Color textColor, Color formColor, Color titleColor)
        {
            EnterScore es = new EnterScore(newValue, textColor, formColor, titleColor);
            es.Show();
        }

        #endregion

        /// <summary>
        /// Brings up a pause menu. From there user can exit program or continue
        /// </summary>
        /// <param name="timer">The game timer</param>
        /// <param name="textColor">Color of main body text</param>
        /// <param name="formColor">Color of pause form</param>
        /// <param name="titleColor">Color of word "Pause" on pause form</param>
        public static void PauseGame(Timer timer, Color textColor, Color formColor, Color titleColor)
        {
            timer.Stop();
            PauseScreen ps = new PauseScreen(timer, textColor, formColor, titleColor);
            ps.Show();
        }

    }

    public class HighScore
    {
        public int score; 
        public string name;

        public HighScore(int _score, string _name)
        {
            score = _score;
            name = _name;
        }
    }
}
