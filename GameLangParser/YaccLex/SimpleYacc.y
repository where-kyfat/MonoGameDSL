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
			public List<Type> lstBVal;
			public Type typeVal;

			public VariablesInitNode vInitVal;
			public InitializeNode initVal;
			public UpdateNode upVal;
			public LoadContentNode lConVal;
       }

%using GameLangParser.Nodes;
%namespace GameLangParser

%token BLOCKBEGIN BLOCKEND SEMICOLON OPBRACKET CLBRACKET VAR COMMA OPPARENTHESES CLPARENTHESES ASSIGN
%token <sVal> CODEBLOCK BLOCKSPRITESINIT BLOCKVARIBLESINIT BLOCKLOADCONTENT BLOCKINITIALIZE BLOCKUPDATE ID 
%token <typeVal> BEHAVIOUR

%type <spsIVal> blockSpritesInit
%type <spIVal> spriteInit
%type <lstSIVal> spritesInit
%type <lstBVal> behaviours

%type <vInitVal> blockVariablesInit
%type <lConVal> blockLoadContent
%type <initVal> blockInitialize
%type <upVal> blockUpdate
%type <sVal> funtionality


%%

progr   :  blockSpritesInit blockVariablesInit blockInitialize blockLoadContent blockUpdate 
		{ root.AddNode($1); root.AddNode($2); root.AddNode($3); root.AddNode($4); root.AddNode($5);}
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


blockVariablesInit: BLOCKVARIBLESINIT BLOCKBEGIN funtionality BLOCKEND 
		{ $$ = new VariablesInitNode($3, $1); }
		;

blockLoadContent: BLOCKLOADCONTENT BLOCKBEGIN funtionality BLOCKEND 
		{ $$ = new LoadContentNode($3, $1); }
		;

blockInitialize	 : BLOCKINITIALIZE BLOCKBEGIN funtionality BLOCKEND 
		{ $$ = new InitializeNode($3, $1); }
		;

blockUpdate		 : BLOCKUPDATE BLOCKBEGIN funtionality BLOCKEND 
		{ $$ = new UpdateNode($3, $1);}
		;

funtionality	 : CODEBLOCK
		{ $$ = $1; }
		;
%%
