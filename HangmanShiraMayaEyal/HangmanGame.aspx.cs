using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HangmanShiraMayaEyal
{
    public partial class HangmanGame : System.Web.UI.Page
    {
        public string randWord;
        public string wrongLetterMsg;

        public static bool CharInWord(string randWord, char guessedletter)
        {
            if (randWord.Contains(guessedletter))
            {
                
                return true;                   
            }
            else
            {
                return false;
            }
        }


        public static char[] AddLetterToList(string randWord, char guessedletter, char[] oldGuessedLetters)
        {
            char[] newGuessedLetters = new char[randWord.Length];
            bool IsPlaceTaken = true;
            if (CharInWord(randWord, guessedletter))
            {
                for (int i = 0; i < oldGuessedLetters.Length; i++)
                {
                    if (oldGuessedLetters[i] == ' ' && IsPlaceTaken)
                    {
                        newGuessedLetters[i] = guessedletter;
                        IsPlaceTaken = false;
                    }
                    else
                    {
                        newGuessedLetters[i] = oldGuessedLetters[i];
                    }
                }
            }
            return newGuessedLetters;
        }
        public static string ShowWord(string randWord, char guessedletter, char[] guessedLetters)
        {
            //if(guessedletter != ' ')
            //{
            StringBuilder newWord = new StringBuilder(randWord);
            char[] existingLetters = randWord.ToCharArray();
            for (int i = 0; i < randWord.Length; i++)
            {
                if (existingLetters[i] == guessedletter)
                {
                    newWord[i] = guessedletter;
                }
                else
                {
                    for (int j = 0; j < guessedLetters.Length; j++)
                    {
                        if (guessedLetters[j] == existingLetters[i])
                        {
                            newWord[i] = guessedLetters[j];
                        }
                        //else
                        //{
                        //    newWord[i] = '_';
                        //}
                    }
                }
            }
            return newWord.ToString();
           // }
           //return 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT word FROM Words where CategoryId = "+ Request.QueryString["CategoryId"] + "";
            DataTable dt = SQLHelper.SelectData(sql);
            //int numOfWords = SQLHelper.SelectScalarToInt32("SELECT COUNT(word) FROM Words where CategoryId=" + Request.QueryString["CategoryId"] + "");
            int startNum = 0;
            int endNum = dt.Rows.Count;
            Random ram = new Random();
            int i = ram.Next(startNum, endNum);
            randWord = dt.Rows[i].Field<string>("word").ToString();
            char[] guessedLetters;
            guessedLetters = new char[randWord.Length];
            for (int j = 0; j < guessedLetters.Length; j++)
            {
                guessedLetters[j] = '_';
            }
            if (Request["btnsubmit"] != null)
            {
                
                string b = Request["guessedLetter"].ToString();
                char guessedLetter = char.Parse(b);
                if (guessedLetter != ' ')
                    if(CharInWord(randWord, guessedLetter))
                    {
                        guessedLetters = AddLetterToList(randWord, guessedLetter, guessedLetters);
                        ShowWord(randWord, guessedLetter, guessedLetters);
                    }
                    wrongLetterMsg = "Letter Not in word";
            }
            else
            {
                ShowWord(randWord,' ', guessedLetters);
            }
        }
    }
}