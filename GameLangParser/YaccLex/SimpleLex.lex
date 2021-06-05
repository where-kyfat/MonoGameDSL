%using GameLangParser.Exceptions;


%using QUT.Gppg;
%using System.Linq;
%using System.Globalization;

%namespace GameLangParser
 
%x CODEBLOCK

BLOCKSPRITEINIT "[SPRITES LOGIC SECTION]"
BLOCKVARIBLESINIT "[VARIBLES SECTION]"
BLOCKLOADCONTENT "[LOAD CONTENT SECTION]"
BLOCKINITIALIZE "[INITIALIZE SECTION]"
BLOCKUPDATE "[UPDATE SECTION]"

%%

{BLOCKSPRITEINIT} { yylval.sVal = yytext; return (int)Tokens.BLOCKSPRITEINIT; }
{BLOCKVARIBLESINIT} { yylval.sVal = yytext; return (int)Tokens.BLOCKVARIBLESINIT; }
{BLOCKLOADCONTENT} { yylval.sVal = yytext; return (int)Tokens.BLOCKLOADCONTENT; }
{BLOCKINITIALIZE} { yylval.sVal = yytext; return (int)Tokens.BLOCKINITIALIZE; }
{BLOCKUPDATE} { yylval.sVal = yytext; return (int)Tokens.BLOCKUPDATE; }


"%%" { BEGIN(CODEBLOCK); return (int)Tokens.BLOCKBEGIN; }
<CODEBLOCK>[^\^^]* { yylval.sVal = yytext; return (int)Tokens.CODEBLOCK; }
<CODEBLOCK>"^^" { BEGIN(INITIAL); return (int)Tokens.BLOCKEND; }

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