%using GameLangParser.Exceptions;


%using QUT.Gppg;
%using System.Linq;
%using System.Globalization;
%using System.Reflection;

%namespace GameLangParser
 
%x CODEBLOCK
%x SPRITESINIT

BOOLVal	true|false
Alpha 	[a-zA-Z_]
Digit   [0-9] 
AlphaDigit {Alpha}|{Digit}
INTNUM  {Digit}+
REALNUM {INTNUM}\.{INTNUM}
ID {Alpha}{AlphaDigit}* 

BLOCKSPRITESINIT "[SPRITES LOGIC SECTION]"
BLOCKVARIBLESINIT "[VARIBLES SECTION]"
BLOCKLOADCONTENT "[LOAD CONTENT SECTION]"
BLOCKINITIALIZE "[INITIALIZE SECTION]"
BLOCKUPDATE "[UPDATE SECTION]"

%%

{BLOCKSPRITESINIT} { BEGIN(SPRITESINIT); yylval.sVal = yytext; return (int)Tokens.BLOCKSPRITESINIT; }
{BLOCKVARIBLESINIT} { yylval.sVal = yytext; return (int)Tokens.BLOCKVARIBLESINIT; }
{BLOCKLOADCONTENT} { yylval.sVal = yytext; return (int)Tokens.BLOCKLOADCONTENT; }
{BLOCKINITIALIZE} { yylval.sVal = yytext; return (int)Tokens.BLOCKINITIALIZE; }
{BLOCKUPDATE} { yylval.sVal = yytext; return (int)Tokens.BLOCKUPDATE; }


"%%" { BEGIN(CODEBLOCK); return (int)Tokens.BLOCKBEGIN; }
<CODEBLOCK>[^\^^]* { yylval.sVal = yytext; return (int)Tokens.CODEBLOCK; }
<CODEBLOCK>"^^" { BEGIN(INITIAL); return (int)Tokens.BLOCKEND; }

<SPRITESINIT> "%%" { return (int)Tokens.BLOCKBEGIN; }
<SPRITESINIT> "^^" { BEGIN(INITIAL); return (int)Tokens.BLOCKEND; }

<SPRITESINIT> {ID}  { 
  int res = ScannerHelper.GetIDToken(yytext);
  if (res == (int)Tokens.ID)
	yylval.sVal = yytext;
  else
  {
    string name_space = "MonogameLib.Behaviours.";
    string dll = "MonogameLib";
    yylval.typeVal = Type.GetType(name_space + yytext + ", " + dll);
  }
  return res;
}

<SPRITESINIT> ":=" { return (int)Tokens.ASSIGN; }
<SPRITESINIT> "," { return (int)Tokens.COMMA;	}
<SPRITESINIT> "{" { return (int)Tokens.OPPARENTHESES; }
<SPRITESINIT> "}" { return (int)Tokens.CLPARENTHESES; }

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
  }
  public static int GetIDToken(string s)
  {
	if (keywords.ContainsKey(s))
	  return keywords[s];
	else
      return (int)Tokens.ID;
  }
  
}