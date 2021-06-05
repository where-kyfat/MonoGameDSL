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
			public SpriteInitNode spIVal;
			public VariablesInitNode vInitVal;
			public InitializeNode initVal;
			public UpdateNode upVal;
			public LoadContentNode lConVal;
       }

%using GameLangParser.Nodes;
%namespace GameLangParser

%token BLOCKBEGIN BLOCKEND SEMICOLON OPBRACKET CLBRACKET VAR COMMA STRCODE
%token <sVal> CODEBLOCK BLOCKSPRITEINIT BLOCKVARIBLESINIT BLOCKLOADCONTENT BLOCKINITIALIZE BLOCKUPDATE

%type <spIVal> blockSpriteInit
%type <vInitVal> blockVariablesInit
%type <lConVal> blockLoadContent
%type <initVal> blockInitialize
%type <upVal> blockUpdate
%type <sVal> funtionality


%%

progr   :  blockSpriteInit blockVariablesInit blockInitialize blockLoadContent blockUpdate 
		{ root.AddNode($1); root.AddNode($2); root.AddNode($3); root.AddNode($4); root.AddNode($5);}
		;
		
blockSpriteInit  : BLOCKSPRITEINIT BLOCKBEGIN funtionality BLOCKEND 
		{ $$ = new SpriteInitNode($3, $1); }
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
