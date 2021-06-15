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
			public UpdateLogicNode ulVal;
			public List<UpdateLogicNode> lstUlVal;

			public IfNode ifVal;
			public LogicalNode logicVal;
			public ConditionNode condVal;
			public ActionNode actVal;
			public List<string> lstSVal;
			public ForEachNode feVal;
       }

%using GameLangParser.Nodes;
%namespace GameLangParser

%token BLOCKBEGIN BLOCKEND SEMICOLON OPBRACKET CLBRACKET VAR COMMA OPPARENTHESES CLPARENTHESES ASSIGN NEW ACTION CONDITION FOREACH IN SPRITES
%token SEMICOLON DOT IF
%token <sVal> CODEBLOCK SPRITESINIT VARIBLESINIT INITIALIZE UPDATE ID STRING FIELD INTNUM INTTYPE STRINGTYPE TEXTBOX
%token <sVal> ADD SUBSTRACT MULTIPLY DIVIDE BOOLVAL EQUAL LESS MORE RAND
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
%type <sVal> id newParams expression T F conditionParam actionParam rand

%type <ifVal> if
%type <logicVal> logic
%type <condVal> condition
%type <actVal> action
%type <lstSVal> conditionParams actionParams 
%type <ulVal> functionality
%type <lstUlVal> funList
%type <feVal> forEach

%%

progr   :  blockSpritesInit blockVariablesInit blockInitialize blockUpdate 
		{ root.AddNode($1); root.AddNode($2); root.AddNode($3); root.AddNode($4);}
		;
		
blockSpritesInit	: SPRITESINIT ASSIGN OPPARENTHESES spritesInit CLPARENTHESES
					{ 
						$$ = new SpritesInitNode(null, $1);
						$$.inits = $4;
					}
					;

blockVariablesInit	: VARIBLESINIT ASSIGN OPPARENTHESES variablesList SEMICOLON CLPARENTHESES 
					{ $$ = new VariablesInitNode(null, $1);  $$.varNodes = $4;}
					;

blockInitialize	: INITIALIZE ASSIGN OPPARENTHESES initList SEMICOLON CLPARENTHESES 
				{ $$ = new InitializeNode(null, $1); $$.assings = $4;}
				;

blockUpdate		: UPDATE ASSIGN OPPARENTHESES funList CLPARENTHESES 
				{ 
					$$ = new UpdateNode(null, $1);
					$$.functionality = $4;
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

spriteInit	: ID OPBRACKET variablesSprite CLBRACKET ASSIGN OPPARENTHESES behaviours CLPARENTHESES
			{
				$$ = new SpriteInitNode($1);
				$$.behaviours = $7;
				$$.variables = $3;
			}
			| ID ASSIGN OPPARENTHESES behaviours CLPARENTHESES
			{
				$$ = new SpriteInitNode($1);
				$$.behaviours = $4;
			}
			;

variablesSprite : assignVariable
				{
					$$ = new List<VarNode>();
					$$.Add($1);
				}
				| variablesSprite COMMA assignVariable
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
				| INTTYPE ID EQUAL rand { $$ = new VarNode($1, $2, $4); }
				;

rand	: RAND OPBRACKET INTNUM CLBRACKET { $$ = string.Format("{0}({1})", $1, $3); }
		| RAND OPBRACKET id CLBRACKET {  $$ = string.Format("{0}({1})", $1, $3); }
		;

variable		: INTTYPE ID { $$ = new VarNode($1, $2); }
				| STRINGTYPE ID { $$ = new VarNode($1, $2); }
				| ID ID { $$ = new VarNode($1, $2); }
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

newParams	: COMMA id COMMA id
			{
				$$ = ',' + $2 + ',' + $4;
			}
			| COMMA INTNUM COMMA INTNUM
			{
				$$ = ',' + $2 + ',' + $4;
			}
			| INTNUM COMMA INTNUM COMMA STRING
			{
				$$ = ',' + $1 + ',' + $3 + ',' + $5;
			}
			| id COMMA id COMMA STRING
			{
				$$ = ',' + $1 + ',' + $3 + ',' + $5;
			}
			| COMMA INTNUM COMMA id
			{
				$$ = ',' + $2 + ',' + $4;
			}
			| COMMA id COMMA INTNUM
			{
				$$ = ',' + $2 + ',' + $4;
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

F			: id { $$ = $1; }
			| INTNUM { $$ = $1; }
			| STRING { $$ = $1; }
			| BOOLVAL { $$ = $1; }
			;


id			: ID
			{
				$$ = $1;
			}
			| ID DOT ID 
			{ $$ = $1 + "." + $3; }
			;


if			: IF OPBRACKET logic CLBRACKET OPPARENTHESES funList CLPARENTHESES
			{
				$$ = new IfNode();
				$$.condition = $3;
				$$.statements = $6;
			}
			;

logic		: BOOLVAL { $$ = new LogicalNode($1); }
			| condition { $$ = new LogicalNode($1.ToString()); }
			| expression EQUAL EQUAL expression { $$ = new LogicalNode($1, $2 + $3, $4); }
			| expression MORE expression { $$ = new LogicalNode($1, $2, $3); }
			| expression LESS expression { $$ = new LogicalNode($1, $2, $3); }
			;

condition	: CONDITION DOT ID OPBRACKET conditionParams CLBRACKET
			{
				$$ = new ConditionNode($3);
				$$.conditionParams = $5;
			}
			| CONDITION DOT ID OPBRACKET CLBRACKET
			{
				$$ = new ConditionNode($3);
			}
			;

conditionParams	: conditionParam
				{
					$$ = new List<string>();
					$$.Add($1);
				}
				| conditionParams COMMA conditionParam
				{
					$1.Add($3);
					$$ = $1;
				}
				;

conditionParam	: F { $$ = $1; }
				;

action	: ACTION DOT ID OPBRACKET actionParams CLBRACKET
		{
			$$ = new ActionNode($3);
			$$.ActionParams = $5;
		}
		;

actionParams	: actionParam
				{
					$$ = new List<string>();
					$$.Add($1);
				}
				| actionParams COMMA actionParam
				{
					$1.Add($3);
					$$ = $1;
				}
				;

actionParam		: F { $$ = $1; }
				;

forEach	: FOREACH OPBRACKET ID ID IN SPRITES CLBRACKET OPPARENTHESES funList CLPARENTHESES
		{
			$$ = new ForEachNode($3, $4);
			$$.statements = $9;
		}
		;

funList	: functionality
		{
			$$ = new List<UpdateLogicNode>();
			$$.Add($1);
		}
		| funList functionality 
		{
			$1.Add($2);
			$$ = $1;
		}
		;

functionality	: assignOrVar SEMICOLON 
				{ 
					$$ = new UpdateLogicNode($1.ToString());
				}
				| assign SEMICOLON 
				{ 
					$$ = new UpdateLogicNode($1);
				}
				| if { $$ = new UpdateLogicNode($1); }
				| action SEMICOLON { $$ = new UpdateLogicNode($1.ToString()); }
				| forEach 
				{
					$$ = new UpdateLogicNode($1);
				}
				;
%%
