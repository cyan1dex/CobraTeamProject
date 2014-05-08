using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Cobra.InterpreterNIndexer {
    public class Lexer : Symbol {
        private int curChar(int i) { return input.curChar(i); }
        private void consume() { input.consume(); }
        private void match(int c) { consume(); }
        public int getPos() { return input.getPos(); }
        public void setPos(int i) { input.setPos(i); }
        private CharBuffer input;

        public Lexer(StreamReader f)
        {
            input = new CharBuffer(f, 1);
        }

        public Lexer(string s)
        {
            input = new CharBuffer(s, 1);
        }

        public Token getToken()
        {
            Token retval;
            for (; ; )
            {
                retval = null;

                if (curChar(1) == '\r' || curChar(1) == '\t')
                {
                    consume(); //Consume whitespace
                }

                if (char.IsLetter((char)curChar(1)))
                { retval = identifier(); } //char is letter
                else if (curChar(1) == ' ')
                { consume(); retval = new Token(TOKEN_SPACE, " "); }
                else if (curChar(1) == '\n')
                { consume(); retval = new Token(Special.TOKEN_ENDLINE, "\n"); }
                else if (curChar(1) == '=')
                { consume(); retval = new Token(Special.TOKEN_EQUALS, "="); }
                else if (curChar(1) == '+')
                { consume(); retval = new Token(Special.TOKEN_PLUS, "+"); }
                else if (curChar(1) == '-')
                { consume(); retval = new Token(Special.TOKEN_MINUS, "-"); }
                else if (curChar(1) == '*')
                { consume(); retval = new Token(Special.TOKEN_MULT, "*"); }
                else if (curChar(1) == '$')
                { consume(); retval = new Token(Special.TOKEN_SQRT, "$"); }
                else if (curChar(1) == '%')
                { consume(); retval = new Token(Special.TOKEN_MOD, "%"); }
                else if (curChar(1) == '^')
                { consume(); retval = new Token(Special.TOKEN_POW, "^"); }
                else if (curChar(1) == '/')
                { consume(); retval = new Token(Special.TOKEN_DIV, "/"); }
                else if (curChar(1) == '[')
                { consume(); retval = new Token(TOKEN_LBRACK, "["); }
                else if (curChar(1) == ']')
                { consume(); retval = new Token(TOKEN_RBRACK, "]"); }
                else if (curChar(1) == '(')
                { consume(); retval = new Token(TOKEN_LPAREN, "("); }
                else if (curChar(1) == ')')
                { consume(); retval = new Token(TOKEN_RPAREN, ")"); }
                else if (curChar(1) == ';')
                { consume(); retval = new Token(TOKEN_SEMICOLON, ";"); }
                else if (curChar(1) == '{')
                { consume(); retval = new Token(Reserved.TOKEN_LEFTCURLY, "{"); }
                else if (curChar(1) == '}')
                { consume(); retval = new Token(Reserved.TOKEN_RIGHTCURLY, "}"); }
                else if (curChar(1) == ',')
                { consume(); retval = new Token(TOKEN_COMMA, ","); }
                else if (curChar(1) == 39)
                { consume(); retval = new Token(TOKEN_APOSTROPHE, "'"); }
                else if (curChar(1) == -1)
                { consume(); retval = new Token(TOKEN_EOF, "<eof>"); }
                else consume();
                if (retval != null) return retval;
            }
        }

        //TODO: modify it to purge symbols from string and other erroneous things
        Token identifier() //if char is a letter build string from the chars & match its identifier
        {
            StringBuilder s = new StringBuilder();
            while (char.IsLetter((char)curChar(1)) || (char)curChar(1) == '-' || curChar(1) == 39)
            {
                if ((char.IsLetter((char)curChar(1)) || char.IsNumber((char)curChar(1))))
                {
                    s.Append((char)curChar(1)); //if char is a letter or number append to a string
                    consume(); //than consume from input
                }
                else
                    consume();

            }

            string identity = s.ToString(); //convert to string
            string idLower = identity.ToLower(); //convert to lowercase

            return new Token(TOKEN_IDENTIFIER, idLower);
        }
    }



}