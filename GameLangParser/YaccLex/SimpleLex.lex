%using GameLangParser.Exceptions;


%using QUT.Gppg;
%using System.Linq;
%using System.Globalization;
%using System.Reflection;

%namespace GameLangParser

Alpha 	[a-zA-Z_]
Digit   [0-9] 
AlphaDigit {Alpha}|{Digit}
INTNUM  {Digit}+
ID {Alpha}{AlphaDigit}* 
STRING \".*\"

%%

{ID}  { 
  int res = ScannerHelper.GetIDToken(yytext);
  if (res == (int)Tokens.ID)
	yylval.sVal = yytext;
  else if (res == (int)Tokens.BEHAVIOUR)
  {
    string name_space = "MonogameLib.Behaviours.";
    string dll = "MonogameLib";
    yylval.typeVal = Type.GetType(name_space + yytext + ", " + dll);
  }
  else
    yylval.sVal = yytext;
  return res;
}

{STRING} {
  yylval.sVal = yytext;
  return (int)Tokens.STRING;
}

{INTNUM} { yylval.sVal = yytext; return (int)Tokens.INTNUM; }

":=" { return (int)Tokens.ASSIGN; }
"="  { yylval.sVal = yytext; return (int)Tokens.EQUAL; }
"("  { return (int)Tokens.OPBRACKET; }
")"  { return (int)Tokens.CLBRACKET; }
","  { return (int)Tokens.COMMA;	}
"."  { return (int)Tokens.DOT; }
";"  { return (int)Tokens.SEMICOLON;	}
"{"  { return (int)Tokens.OPPARENTHESES; }
"}"  { return (int)Tokens.CLPARENTHESES; }
"+"  { yylval.sVal = yytext; return (int)Tokens.ADD; }
"-"  { yylval.sVal = yytext; return (int)Tokens.SUBSTRACT; }
"*"  { yylval.sVal = yytext; return (int)Tokens.DIVIDE; }
"/"  { yylval.sVal = yytext; return (int)Tokens.MULTIPLY; }
">"  { yylval.sVal = yytext; return (int)Tokens.LESS; }
"<"  { yylval.sVal = yytext; return (int)Tokens.MORE; }


[^ \r\n] {
	LexError();
}

%{
  yylloc = new LexLocation(tokLin, tokCol, tokELin, tokECol);
%}

%%

public override void yyerror(string format, params object[] args)
{
  var ww = args.Skip(1).Cast<string>().ToArray();
  string errorMsg = string.Format("({0},{1}): Meeted {2}, but waited for {3}", yyline, yycol, args[0], string.Join(" or ",  ww));
  throw new SyntaxException(errorMsg);
}

public void LexError()
{
  string errorMsg = string.Format("({0},{1}): Unknown symbol {2}", yyline, yycol, yytext);
  throw new LexException(errorMsg);
}

class ScannerHelper 
{
  private static Dictionary<string,int> keywords;

  static ScannerHelper() 
  {
    keywords = new Dictionary<string,int>();

    //Functions
    keywords.Add("Sprites",(int)Tokens.SPRITESINIT);
    keywords.Add("Varibles",(int)Tokens.VARIBLESINIT);
    keywords.Add("Initialize",(int)Tokens.INITIALIZE);
    keywords.Add("Update",(int)Tokens.UPDATE);

    //Behaviours
    
    keywords.Add("_8Directions",(int)Tokens.BEHAVIOUR);
    keywords.Add("BoundToLayout",(int)Tokens.BEHAVIOUR);
    keywords.Add("BulletMovement",(int)Tokens.BEHAVIOUR);
    keywords.Add("DestroyOutSideLayout",(int)Tokens.BEHAVIOUR);
    keywords.Add("Fade",(int)Tokens.BEHAVIOUR);
    keywords.Add("ScrollTo",(int)Tokens.BEHAVIOUR);

    //Initilize
    keywords.Add("new",(int)Tokens.NEW);

    //Varibles
    keywords.Add("int",(int)Tokens.INTTYPE);
    keywords.Add("string", (int)Tokens.STRINGTYPE);
    keywords.Add("TextBox", (int)Tokens.TEXTBOX);

    //Update
    keywords.Add("Conditions",(int)Tokens.CONDITION);
    keywords.Add("Actions",(int)Tokens.ACTION);
    keywords.Add("if", (int)Tokens.IF);

    //Bool
    keywords.Add("true",(int)Tokens.BOOLVAL);
    keywords.Add("false",(int)Tokens.BOOLVAL);
    keywords.Add("getRandom", (int)Tokens.RAND);

    keywords.Add("in", (int)Tokens.IN);
    keywords.Add("ForEach", (int)Tokens.FOREACH);
    keywords.Add("sprites", (int)Tokens.SPRITES);
  }
  public static int GetIDToken(string s)
  {
	if (keywords.ContainsKey(s))
	  return keywords[s];
	else
      return (int)Tokens.ID;
  }
  
}