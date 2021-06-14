%using GameLangParser.Exceptions;


%using QUT.Gppg;
%using System.Linq;
%using System.Globalization;
%using System.Reflection;

%namespace GameLangParser
 
%x CODEBLOCK
%x SPRITESINIT
%x INITIALIZE
%x VARIBLES
%x UPDATE

Alpha 	[a-zA-Z_]
Digit   [0-9] 
AlphaDigit {Alpha}|{Digit}
INTNUM  {Digit}+
REALNUM {INTNUM}\.{INTNUM}
ID {Alpha}{AlphaDigit}* 
STRING \".*\"

BLOCKSPRITESINIT "[SPRITES LOGIC SECTION]"
BLOCKVARIBLESINIT "[VARIBLES SECTION]"
BLOCKINITIALIZE "[INITIALIZE SECTION]"
BLOCKUPDATE "[UPDATE SECTION]"

%%

{BLOCKSPRITESINIT} { BEGIN(SPRITESINIT); yylval.sVal = yytext; return (int)Tokens.BLOCKSPRITESINIT; }
{BLOCKVARIBLESINIT} { BEGIN(VARIBLES); yylval.sVal = yytext; return (int)Tokens.BLOCKVARIBLESINIT; }
{BLOCKINITIALIZE} { BEGIN(INITIALIZE); yylval.sVal = yytext; return (int)Tokens.BLOCKINITIALIZE; }
{BLOCKUPDATE} { BEGIN(UPDATE); yylval.sVal = yytext; return (int)Tokens.BLOCKUPDATE; }


"%%" { BEGIN(CODEBLOCK); return (int)Tokens.BLOCKBEGIN; }
<CODEBLOCK>[^\^^]* { yylval.sVal = yytext; return (int)Tokens.CODEBLOCK; }
<CODEBLOCK>"^^" { BEGIN(INITIAL); return (int)Tokens.BLOCKEND; }

//----------------------------------------------SPRITESINIT

<SPRITESINIT> "%%" { return (int)Tokens.BLOCKBEGIN; }
<SPRITESINIT> "^^" { BEGIN(INITIAL); return (int)Tokens.BLOCKEND; }


<SPRITESINIT> {ID}  { 
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

<SPRITESINIT> {STRING} {
  yylval.sVal = yytext;
  return (int)Tokens.STRING;
}

<SPRITESINIT> {INTNUM} { yylval.sVal = yytext; return (int)Tokens.INTNUM; }

<SPRITESINIT> ":=" { return (int)Tokens.ASSIGN; }
<SPRITESINIT> "=" { return (int)Tokens.EQUAL; }
<SPRITESINIT> "(" { return (int)Tokens.OPBRACKET; }
<SPRITESINIT> ")" { return (int)Tokens.CLBRACKET; }
<SPRITESINIT> "," { return (int)Tokens.COMMA;	}
<SPRITESINIT> ";" { return (int)Tokens.SEMICOLON;	}
<SPRITESINIT> "{" { return (int)Tokens.OPPARENTHESES; }
<SPRITESINIT> "}" { return (int)Tokens.CLPARENTHESES; }

//----------------------------------------------INITIALIZE

<INITIALIZE> "%%" { return (int)Tokens.BLOCKBEGIN; }
<INITIALIZE> "^^" { BEGIN(INITIAL); return (int)Tokens.BLOCKEND; }

<INITIALIZE> {ID}  { 
  res = ScannerHelper.GetIDToken(yytext);
  yylval.sVal = yytext;
  return res;
}

<INITIALIZE> {STRING} {
  yylval.sVal = yytext;
  return (int)Tokens.STRING;
}

<INITIALIZE> {INTNUM} { yylval.sVal = yytext; return (int)Tokens.INTNUM; }

<INITIALIZE> "=" { return (int)Tokens.EQUAL; }
<INITIALIZE> "(" { return (int)Tokens.OPBRACKET; }
<INITIALIZE> ")" { return (int)Tokens.CLBRACKET; }
<INITIALIZE> ";" { return (int)Tokens.SEMICOLON; }
<INITIALIZE> "." { return (int)Tokens.DOT; }
<INITIALIZE> "," { return (int)Tokens.COMMA; }
<INITIALIZE> "+" { yylval.sVal = yytext; return (int)Tokens.ADD; }
<INITIALIZE> "-" { yylval.sVal = yytext; return (int)Tokens.SUBSTRACT; }
<INITIALIZE> "*" { yylval.sVal = yytext; return (int)Tokens.DIVIDE; }
<INITIALIZE> "/" { yylval.sVal = yytext; return (int)Tokens.MULTIPLY; }

//----------------------------------------------VARIBLESINIT

<VARIBLES> "%%" { return (int)Tokens.BLOCKBEGIN; }
<VARIBLES> "^^" { BEGIN(INITIAL); return (int)Tokens.BLOCKEND; }

<VARIBLES> {ID}  { 
  res = ScannerHelper.GetIDToken(yytext);
  yylval.sVal = yytext;
  if (res == (int)Tokens.TEXTBOX)
    return (int)Tokens.ID;
  else
    return res;
}

<VARIBLES> {STRING} {
  yylval.sVal = yytext;
  return (int)Tokens.STRING;
}

<VARIBLES> {INTNUM} { yylval.sVal = yytext; return (int)Tokens.INTNUM; }

<VARIBLES> "=" { return (int)Tokens.EQUAL; }
<VARIBLES> ";" { return (int)Tokens.SEMICOLON; }

//----------------------------------------------UPDATEINIT

<UPDATE> "%%" { return (int)Tokens.BLOCKBEGIN; }
<UPDATE> "^^" { BEGIN(INITIAL); return (int)Tokens.BLOCKEND; }

<UPDATE> {ID}  { 
  res = ScannerHelper.GetIDToken(yytext);
  yylval.sVal = yytext;
  return res;
}

<UPDATE> {STRING} {
  yylval.sVal = yytext;
  return (int)Tokens.STRING;
}

<UPDATE> {INTNUM} { yylval.sVal = yytext; return (int)Tokens.INTNUM; }

<UPDATE> "=" { return (int)Tokens.EQUAL; }
<UPDATE> "(" { return (int)Tokens.OPBRACKET; }
<UPDATE> ")" { return (int)Tokens.CLBRACKET; }
<UPDATE> ";" { return (int)Tokens.SEMICOLON; }
<UPDATE> "." { return (int)Tokens.DOT; }
<UPDATE> "," { return (int)Tokens.COMMA; }
<UPDATE> "+" { yylval.sVal = yytext; return (int)Tokens.ADD; }
<UPDATE> "-" { yylval.sVal = yytext; return (int)Tokens.SUBSTRACT; }
<UPDATE> "*" { yylval.sVal = yytext; return (int)Tokens.DIVIDE; }
<UPDATE> "/" { yylval.sVal = yytext; return (int)Tokens.MULTIPLY; }
<UPDATE> "{" { return (int)Tokens.OPPARENTHESES; }
<UPDATE> "}" { return (int)Tokens.CLPARENTHESES; }

<UPDATE> ">" { yylval.sVal = yytext; return (int)Tokens.LESS; }
<UPDATE> "<" { yylval.sVal = yytext; return (int)Tokens.MORE; }

//----------------------------------------------

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
  string errorMsg = string.Format("({0},{1}): Meeted {2}, but waited for {3}", yyline, yycol, args[0], string.Join(" ��� ",  ww));
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
  }
  public static int GetIDToken(string s)
  {
	if (keywords.ContainsKey(s))
	  return keywords[s];
	else
      return (int)Tokens.ID;
  }
  
}