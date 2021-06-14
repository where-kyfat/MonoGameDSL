%{
	public GameNode root;

    public Parser(AbstractScanner<ValueType, LexLocation> scanner, string patternGame) : base(scanner) 
	{
		this.root = new GameNode(patternGame);
	}
%}

%output = ../../YaccLex/SimpleYacc.cs

%union { 
			public string sVal;

			public SpritesInitNode spsIVal;
			public SpriteInitNode spIVal;
			public List<SpriteInitNode> lstSIVal;
			public AssignNode singVal;
			public List<AssignNode> lstSingVal;
			public VarNode varVal;
			public List<VarNode> lstvarVal;
			public List<Type> lstBVal;
			public Type typeVal;

			public VariablesInitNode vInitVal;
			public InitializeNode initVal;
			public UpdateNode upVal;
       }

%using GameLangParser.Nodes;
%namespace GameLangParser

%token BLOCKBEGIN BLOCKEND SEMICOLON OPBRACKET CLBRACKET VAR COMMA OPPARENTHESES CLPARENTHESES ASSIGN NEW EQUAL
%token SEMICOLON DOT
%token <sVal> CODEBLOCK BLOCKSPRITESINIT BLOCKVARIBLESINIT BLOCKLOADCONTENT BLOCKINITIALIZE BLOCKUPDATE ID STRING FIELD INTNUM INTTYPE STRINGTYPE TEXTBOX
%token <sVal> ADD SUBSTRACT MULTIPLY DIVIDE
%token <typeVal> BEHAVIOUR

%type <spsIVal> blockSpritesInit
%type <spIVal> spriteInit
%type <lstSIVal> spritesInit
%type <lstBVal> behaviours

%type <initVal> blockInitialize
%type <lstSingVal> initList
%type <singVal> assign

%type <vInitVal> blockVariablesInit
%type <varVal> assignOrVar assignVariable variable
%type <lstvarVal> variablesList variablesSprite

%type <upVal> blockUpdate
%type <sVal> funtionality id newParams expression T F

%%

progr   :  blockSpritesInit blockVariablesInit blockInitialize blockUpdate 
		{ root.AddNode($1); root.AddNode($2); root.AddNode($3); root.AddNode($4);}
		;
		
blockSpritesInit	: BLOCKSPRITESINIT BLOCKBEGIN spritesInit BLOCKEND
					{ 
						$$ = new SpritesInitNode(null, $1);
						$$.inits = $3;
					}
					;

spritesInit : spriteInit 
			{
				$$ = new List<SpriteInitNode>();
				$$.Add($1);
			}
			| spritesInit spriteInit
			{
				$1.Add($2);
				$$ = $1;
			}
			;

spriteInit	: ID ASSIGN OPPARENTHESES behaviours CLPARENTHESES
			{
				$$ = new SpriteInitNode($1);
				$$.behaviours = $4;
			}
			| ID OPBRACKET variablesSprite SEMICOLON CLBRACKET ASSIGN OPPARENTHESES behaviours CLPARENTHESES
			{
				$$ = new SpriteInitNode($1);
				$$.behaviours = $8;
				$$.variables = $3;
			}
			;

variablesSprite : assignVariable
				{
					$$ = new List<VarNode>();
					$$.Add($1);
				}
				| variablesSprite SEMICOLON assignVariable
				{
					$1.Add($3);
					$$ = $1;
				}
				;

behaviours	: BEHAVIOUR 
			{
				$$ = new List<Type>();
				$$.Add($1);
			}
			| behaviours COMMA BEHAVIOUR
			{
				$1.Add($3);
				$$ = $1;
			}
			;


blockVariablesInit	: BLOCKVARIBLESINIT BLOCKBEGIN variablesList SEMICOLON BLOCKEND 
					{ $$ = new VariablesInitNode(null, $1);  $$.varNodes = $3;}
					;

variablesList	: assignOrVar
				{
					$$ = new List<VarNode>();
					$$.Add($1);
				}
				| variablesList SEMICOLON assignOrVar
				{
					$1.Add($3);
					$$ = $1;
				}
				;

assignOrVar		: assignVariable { $$ = $1; }
				| variable { $$ = $1; }
				;

assignVariable	: INTTYPE ID EQUAL INTNUM { $$ = new VarNode($1, $2, $4); }
				| STRINGTYPE ID EQUAL STRING { $$ = new VarNode($1, $2, $4); }
				;

variable		: INTTYPE ID { $$ = new VarNode($1, $2); }
				| STRINGTYPE ID { $$ = new VarNode($1, $2); }
				| ID ID { $$ = new VarNode($1, $2); }
				;


blockInitialize	: BLOCKINITIALIZE BLOCKBEGIN initList SEMICOLON BLOCKEND 
				{ $$ = new InitializeNode(null, $1); $$.assings = $3;}
				;

initList	: assign 
			{
				$$ = new List<AssignNode>();
				$$.Add($1);
			}
			| initList SEMICOLON assign 
			{
				$1.Add($3);
				$$ = $1;
			}
			;

assign		: id EQUAL expression
			{
				$$ = new AssignNode($1, $3);
			}
			| id EQUAL NEW id OPBRACKET STRING newParams CLBRACKET
			{
				$$ = new AssignNode($1, $4, $6, $7);
			}
			| id EQUAL NEW TEXTBOX OPBRACKET newParams CLBRACKET
			{
				$$ = new AssignNode($1, $4, $6);
			}
			| id EQUAL STRING
			{
				$$ = new AssignNode($1, $3);
			}
			;

newParams	: COMMA INTNUM COMMA INTNUM
			{
				$$ = ',' + $2 + ',' + $4;
			}
			| INTNUM COMMA INTNUM COMMA STRING
			{
				$$ = ',' + $1 + ',' + $3 + ',' + $5;
			}
			;


expression	: T {$$ = $1;}
			| expression ADD T 		{$$ = string.Format("{0} {1} {2}", $1, $2, $3);}
			| expression SUBSTRACT T	{$$ = string.Format("{0} {1} {2}", $1, $2, $3);}
			;

T    		: F {$$ = $1;}
			| T MULTIPLY F		{$$ = string.Format("{0} {1} {2}", $1, $2, $3);}
			| T DIVIDE F		{$$ = string.Format("{0} {1} {2}", $1, $2, $3);}
			;

F			: ID { $$ = $1; }
			| FIELD { $$ = $1; }
			| INTNUM { $$ = $1; }
			| STRING { $$ = $1; }
			;

id			: ID
			{
				$$ = $1;
			}
			| FIELD
			{
				$$ = $1;
			}
			;


blockUpdate		 : BLOCKUPDATE BLOCKBEGIN funtionality BLOCKEND 
		{ $$ = new UpdateNode($3, $1);}
		;

funtionality	 : CODEBLOCK
		{ $$ = $1; }
		;
%%
