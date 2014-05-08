using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.InterpreterNIndexer {
    public class Symbol {
        public const int TOKEN_IDENTIFIER = 1; //Variable identifier
        public const int TOKEN_SEMICOLON = 2;
        public const int TOKEN_SPACE = 3;
        public const int TOKEN_COMMENT = 4;
        public const int TOKEN_LBRACK = 5;
        public const int TOKEN_RBRACK = 6;
        public const int TOKEN_LPAREN = 7;
        public const int TOKEN_RPAREN = 8;
        public const int TOKEN_COMMA = 9;
        public const int TOKEN_ENDLINE = 10;
        public const int TOKEN_APOSTROPHE = 11;
        public const int TOKEN_EOF = 999;
    }



    public class Special : Symbol {
        public const int TOKEN_PLUS = 19;
        public const int TOKEN_MINUS = 20;
        public const int TOKEN_MULT = 21;
        public const int TOKEN_DIV = 22;
        public const int TOKEN_EQUALS = 23;
        public const int TOKEN_NEQUALS = 24;
        public const int TOKEN_GREATER = 25;
        public const int TOKEN_GREATEREQ = 26;
        public const int TOKEN_LESS = 27;
        public const int TOKEN_LESSEQ = 28;
        public const int TOKEN_NOT = 29;
        public const int TOKEN_AND = 30;
        public const int TOKEN_OR = 31;
        public const int TOKEN_MOD = 32;
        public const int TOKEN_SQRT = 33;
        public const int TOKEN_POW = 34;
    }

    public class Reserved : Symbol {

        public const int TOKEN_LEFTCURLY = 66;
        public const int TOKEN_RIGHTCURLY = 67;
    }
}
