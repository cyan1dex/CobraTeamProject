using System;
using System.Text;
using System.IO;
using Cobra.CustomErrors;

namespace Cobra.QTokenizer
{
    public class QLexer : QSymbol
    {
        private int curChar(int i) { return input.curChar(i); }
        //private int nextChar(int i) { return input.nextChar(i); }
        private void consume() { input.consume(); }
        private void match(int c) { consume(); }
        public int getPos() { return input.getPos(); }
        public void setPos(int i) { input.setPos(i); }
        private QCharBuffer input;
        // is previous character a char?
        private static bool previousChar;

        // needed only if negation info needs to be stored in tokenizer
        //private static bool negated = false;

        public QLexer(StreamReader f)
        {
            input = new QCharBuffer(f, 2);
        }

        public QLexer(string s)
        {
            input = new QCharBuffer(s, 2);
        }

        public QToken getToken()
        {
            QToken retval;
            for (; ; )
            {
                retval = null;
                previousChar = false;

                int intcurChar = curChar(1);
                if (intcurChar == ' ' || intcurChar == '\t' || intcurChar == '\n' || intcurChar == '\r')
                {
                    consume(); //Consume whitespace
                    // retrieve next character
                    intcurChar = curChar(1);
                }

                if (char.IsLetter((char)intcurChar))
                {
                    previousChar = true;
                    retval = identifier(); 
                } //char is letter
                else if (intcurChar == '=')
                { consume(); retval = new QToken(Special.TOKEN_EQUALS, "=", false); }
                else if (intcurChar == '+')
                {

                    if (previousChar)
                        throw new InvalidTokenSequenceException("'+' cannot be appended to query terms.");
                    intcurChar = curChar(2);
                    if (intcurChar == ' ')
                    {
                        consume();
                        retval = new QToken(Special.TOKEN_PLUS, "+", false);
                    }
                    else
                    {
                        string errMsg = "Invalid character '" + (char)intcurChar + "' found after '+'" + Environment.NewLine +
                                        "OR(+) must be surrounded by spaces";
                        throw new InvalidTokenSequenceException(errMsg);
                    }
                }
                else if (intcurChar == '-')
                {
                    intcurChar = curChar(2);
                    if (char.IsLetter((char)intcurChar))
                    {
                        consume();
                        retval = new QToken(TOKEN_MINUS, "-", false);
                    }
                    else
                    {
                        string errMsg = "Valid character not found after '-' symbol.";
                        throw new InvalidTokenSequenceException(errMsg);
                    }
                }
                else if (intcurChar == '*')
                {
                    char testchar = (char)curChar(2);
                    bool test = char.IsLetter(testchar);
                    if ((!previousChar) && (!test))
                    {
                        string errMsg = "Invalid character found before and after the wildcard('*') symbol.";
                        throw new InvalidTokenSequenceException(errMsg);
                    }
                    else
                        retval = identifier(); 
                }
                else if (intcurChar == '"')
                { consume(); retval = new QToken(TOKEN_QUOTE, "\"", false); }
                else if (intcurChar == '$')
                { consume(); retval = new QToken(Special.TOKEN_SQRT, "$", false); }
                else if (intcurChar == '%')
                { consume(); retval = new QToken(Special.TOKEN_MOD, "%", false); }
                else if (intcurChar == '^')
                { consume(); retval = new QToken(Special.TOKEN_POW, "^", false); }
                else if (intcurChar == '/')
                { consume(); retval = new QToken(Special.TOKEN_DIV, "/", false); }
                else if (intcurChar == '[')
                { consume(); retval = new QToken(TOKEN_LBRACK, "[", false); }
                else if (intcurChar == ']')
                { consume(); retval = new QToken(TOKEN_RBRACK, "]", false); }
                else if (intcurChar == '(')
                { consume(); retval = new QToken(TOKEN_LPAREN, "(", false); }
                else if (intcurChar == ')')
                { consume(); retval = new QToken(TOKEN_RPAREN, ")", false); }
                else if (intcurChar == ';')
                { consume(); retval = new QToken(TOKEN_SEMICOLON, ";", false); }
                else if (intcurChar == '{')
                { consume(); retval = new QToken(Reserved.TOKEN_LEFTCURLY, "{", false); }
                else if (intcurChar == '}')
                { consume(); retval = new QToken(Reserved.TOKEN_RIGHTCURLY, "}", false); }
                //else if (intcurChar == ',')
                //{ consume(); retval = new QToken(TOKEN_COMMA, ",", false); }
                else if (intcurChar == -1)
                { consume(); retval = new QToken(TOKEN_EOF, "<eof>", false); }
                else consume();
                if (retval != null) return retval;
            }
        }

        //TODO: modify it to purge symbols from string and other erroneous things
        QToken identifier() //if char is a letter build string from the chars & match its identifier
        {
            StringBuilder s = new StringBuilder();

            // wildcard query string is not to be porterstemmed.
            bool porterstem = true;

            int intcurChar = curChar(1);
            while (char.IsLetter((char)intcurChar) || char.IsNumber((char)intcurChar) //TODO: How to check also for apostrophe
                                      || (char)intcurChar == '-' || (char)intcurChar == '*')
            {
                if ((char)intcurChar == '*')
                    porterstem = false;
                s.Append((char)intcurChar); //if char is a letter append to a string
                consume();             //than consume from input
                intcurChar = curChar(1);
            }

            string identity = s.ToString(); //convert to string
            string idLower = identity.ToLower(); //convert to lowercase

            return new QToken(TOKEN_IDENTIFIER, idLower, porterstem);
        }                
    }
}