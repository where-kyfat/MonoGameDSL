// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.3.6
// Machine:  AVILOV-PC
// DateTime: 16.06.2021 9:50:37
// UserName: a.avilov
// Input file <../../YaccLex/SimpleYacc.y>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using GameLangParser.Nodes;

namespace GameLangParser
{
public enum Tokens {
    error=1,EOF=2,BLOCKBEGIN=3,BLOCKEND=4,SEMICOLON=5,OPBRACKET=6,
    CLBRACKET=7,VAR=8,COMMA=9,OPPARENTHESES=10,CLPARENTHESES=11,ASSIGN=12,
    NEW=13,ACTION=14,CONDITION=15,FOREACH=16,IN=17,SPRITES=18,
    DOT=19,IF=20,CODEBLOCK=21,SPRITESINIT=22,VARIBLESINIT=23,INITIALIZE=24,
    UPDATE=25,ID=26,STRING=27,FIELD=28,INTNUM=29,INTTYPE=30,
    STRINGTYPE=31,TEXTBOX=32,ADD=33,SUBSTRACT=34,MULTIPLY=35,DIVIDE=36,
    BOOLVAL=37,EQUAL=38,LESS=39,MORE=40,RAND=41,BEHAVIOUR=42};

public struct ValueType
{ 
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
// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from ../../YaccLex/SimpleYacc.y
	public GameNode root;

    public Parser(AbstractScanner<ValueType, LexLocation> scanner, string patternGame) : base(scanner) 
	{
		this.root = new GameNode(patternGame);
	}
  // End verbatim content from ../../YaccLex/SimpleYacc.y

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[75];
  private static State[] states = new State[187];
  private static string[] nonTerms = new string[] {
      "blockSpritesInit", "spriteInit", "spritesInit", "behaviours", "blockInitialize", 
      "initList", "assign", "blockVariablesInit", "assignOrVar", "assignVariable", 
      "variable", "variablesList", "variablesSprite", "blockUpdate", "id", "newParams", 
      "expression", "T", "F", "conditionParam", "actionParam", "rand", "if", 
      "logic", "condition", "action", "conditionParams", "actionParams", "functionality", 
      "funList", "forEach", "progr", "$accept", };

  static Parser() {
    states[0] = new State(new int[]{22,158},new int[]{-32,1,-1,3});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{23,149},new int[]{-8,4});
    states[4] = new State(new int[]{24,141},new int[]{-5,5});
    states[5] = new State(new int[]{25,7},new int[]{-14,6});
    states[6] = new State(-2);
    states[7] = new State(new int[]{12,8});
    states[8] = new State(new int[]{10,9});
    states[9] = new State(new int[]{30,16,31,30,26,35,32,37,20,89,14,98,16,109},new int[]{-30,10,-29,119,-9,13,-10,15,-11,34,-7,39,-15,41,-23,88,-26,96,-31,108});
    states[10] = new State(new int[]{11,11,30,16,31,30,26,35,32,37,20,89,14,98,16,109},new int[]{-29,12,-9,13,-10,15,-11,34,-7,39,-15,41,-23,88,-26,96,-31,108});
    states[11] = new State(-6);
    states[12] = new State(-69);
    states[13] = new State(new int[]{5,14});
    states[14] = new State(-70);
    states[15] = new State(-17);
    states[16] = new State(new int[]{26,17});
    states[17] = new State(new int[]{38,18,5,-24});
    states[18] = new State(new int[]{29,19,41,21},new int[]{-22,20});
    states[19] = new State(-19);
    states[20] = new State(-21);
    states[21] = new State(new int[]{6,22});
    states[22] = new State(new int[]{29,23,26,27},new int[]{-15,25});
    states[23] = new State(new int[]{7,24});
    states[24] = new State(-22);
    states[25] = new State(new int[]{7,26});
    states[26] = new State(-23);
    states[27] = new State(new int[]{19,28,7,-50,35,-50,36,-50,33,-50,34,-50,5,-50,38,-50,40,-50,39,-50,6,-50,9,-50});
    states[28] = new State(new int[]{26,29});
    states[29] = new State(-51);
    states[30] = new State(new int[]{26,31});
    states[31] = new State(new int[]{38,32,5,-25});
    states[32] = new State(new int[]{27,33});
    states[33] = new State(-20);
    states[34] = new State(-18);
    states[35] = new State(new int[]{26,36,19,28,38,-50});
    states[36] = new State(-26);
    states[37] = new State(new int[]{26,38});
    states[38] = new State(-27);
    states[39] = new State(new int[]{5,40});
    states[40] = new State(-71);
    states[41] = new State(new int[]{38,42});
    states[42] = new State(new int[]{13,57,27,86,26,27,29,49,37,51},new int[]{-17,43,-18,87,-19,54,-15,48});
    states[43] = new State(new int[]{33,44,34,55,5,-30});
    states[44] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-18,45,-19,54,-15,48});
    states[45] = new State(new int[]{35,46,36,52,33,-41,34,-41,5,-41,38,-41,40,-41,39,-41,7,-41});
    states[46] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-19,47,-15,48});
    states[47] = new State(-44);
    states[48] = new State(-46);
    states[49] = new State(-47);
    states[50] = new State(-48);
    states[51] = new State(-49);
    states[52] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-19,53,-15,48});
    states[53] = new State(-45);
    states[54] = new State(-43);
    states[55] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-18,56,-19,54,-15,48});
    states[56] = new State(new int[]{35,46,36,52,33,-42,34,-42,5,-42,38,-42,40,-42,39,-42,7,-42});
    states[57] = new State(new int[]{32,82,26,27},new int[]{-15,58});
    states[58] = new State(new int[]{6,59});
    states[59] = new State(new int[]{27,60});
    states[60] = new State(new int[]{9,63,29,72,26,27},new int[]{-16,61,-15,77});
    states[61] = new State(new int[]{7,62});
    states[62] = new State(-31);
    states[63] = new State(new int[]{29,68,26,27},new int[]{-15,64});
    states[64] = new State(new int[]{9,65});
    states[65] = new State(new int[]{29,67,26,27},new int[]{-15,66});
    states[66] = new State(-34);
    states[67] = new State(-39);
    states[68] = new State(new int[]{9,69});
    states[69] = new State(new int[]{29,70,26,27},new int[]{-15,71});
    states[70] = new State(-35);
    states[71] = new State(-38);
    states[72] = new State(new int[]{9,73});
    states[73] = new State(new int[]{29,74});
    states[74] = new State(new int[]{9,75});
    states[75] = new State(new int[]{27,76});
    states[76] = new State(-36);
    states[77] = new State(new int[]{9,78});
    states[78] = new State(new int[]{26,27},new int[]{-15,79});
    states[79] = new State(new int[]{9,80});
    states[80] = new State(new int[]{27,81});
    states[81] = new State(-37);
    states[82] = new State(new int[]{6,83});
    states[83] = new State(new int[]{9,63,29,72,26,27},new int[]{-16,84,-15,77});
    states[84] = new State(new int[]{7,85});
    states[85] = new State(-32);
    states[86] = new State(new int[]{5,-33,35,-48,36,-48,33,-48,34,-48});
    states[87] = new State(new int[]{35,46,36,52,33,-40,34,-40,5,-40,38,-40,40,-40,39,-40,7,-40});
    states[88] = new State(-72);
    states[89] = new State(new int[]{6,90});
    states[90] = new State(new int[]{37,120,15,122,26,27,29,49,27,50},new int[]{-24,91,-25,121,-17,133,-18,87,-19,54,-15,48});
    states[91] = new State(new int[]{7,92});
    states[92] = new State(new int[]{10,93});
    states[93] = new State(new int[]{30,16,31,30,26,35,32,37,20,89,14,98,16,109},new int[]{-30,94,-29,119,-9,13,-10,15,-11,34,-7,39,-15,41,-23,88,-26,96,-31,108});
    states[94] = new State(new int[]{11,95,30,16,31,30,26,35,32,37,20,89,14,98,16,109},new int[]{-29,12,-9,13,-10,15,-11,34,-7,39,-15,41,-23,88,-26,96,-31,108});
    states[95] = new State(-52);
    states[96] = new State(new int[]{5,97});
    states[97] = new State(-73);
    states[98] = new State(new int[]{19,99});
    states[99] = new State(new int[]{26,100});
    states[100] = new State(new int[]{6,101});
    states[101] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-28,102,-21,107,-19,106,-15,48});
    states[102] = new State(new int[]{7,103,9,104});
    states[103] = new State(-63);
    states[104] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-21,105,-19,106,-15,48});
    states[105] = new State(-65);
    states[106] = new State(-66);
    states[107] = new State(-64);
    states[108] = new State(-74);
    states[109] = new State(new int[]{6,110});
    states[110] = new State(new int[]{26,111});
    states[111] = new State(new int[]{26,112});
    states[112] = new State(new int[]{17,113});
    states[113] = new State(new int[]{18,114});
    states[114] = new State(new int[]{7,115});
    states[115] = new State(new int[]{10,116});
    states[116] = new State(new int[]{30,16,31,30,26,35,32,37,20,89,14,98,16,109},new int[]{-30,117,-29,119,-9,13,-10,15,-11,34,-7,39,-15,41,-23,88,-26,96,-31,108});
    states[117] = new State(new int[]{11,118,30,16,31,30,26,35,32,37,20,89,14,98,16,109},new int[]{-29,12,-9,13,-10,15,-11,34,-7,39,-15,41,-23,88,-26,96,-31,108});
    states[118] = new State(-67);
    states[119] = new State(-68);
    states[120] = new State(new int[]{7,-53,35,-49,36,-49,38,-49,33,-49,34,-49,40,-49,39,-49});
    states[121] = new State(-54);
    states[122] = new State(new int[]{19,123});
    states[123] = new State(new int[]{26,124});
    states[124] = new State(new int[]{6,125});
    states[125] = new State(new int[]{7,131,26,27,29,49,27,50,37,51},new int[]{-27,126,-20,132,-19,130,-15,48});
    states[126] = new State(new int[]{7,127,9,128});
    states[127] = new State(-58);
    states[128] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-20,129,-19,130,-15,48});
    states[129] = new State(-61);
    states[130] = new State(-62);
    states[131] = new State(-59);
    states[132] = new State(-60);
    states[133] = new State(new int[]{38,134,33,44,34,55,40,137,39,139});
    states[134] = new State(new int[]{38,135});
    states[135] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-17,136,-18,87,-19,54,-15,48});
    states[136] = new State(new int[]{33,44,34,55,7,-55});
    states[137] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-17,138,-18,87,-19,54,-15,48});
    states[138] = new State(new int[]{33,44,34,55,7,-56});
    states[139] = new State(new int[]{26,27,29,49,27,50,37,51},new int[]{-17,140,-18,87,-19,54,-15,48});
    states[140] = new State(new int[]{33,44,34,55,7,-57});
    states[141] = new State(new int[]{12,142});
    states[142] = new State(new int[]{10,143});
    states[143] = new State(new int[]{26,27},new int[]{-6,144,-7,148,-15,41});
    states[144] = new State(new int[]{5,145});
    states[145] = new State(new int[]{11,146,26,27},new int[]{-7,147,-15,41});
    states[146] = new State(-5);
    states[147] = new State(-29);
    states[148] = new State(-28);
    states[149] = new State(new int[]{12,150});
    states[150] = new State(new int[]{10,151});
    states[151] = new State(new int[]{30,16,31,30,26,156,32,37},new int[]{-12,152,-9,157,-10,15,-11,34});
    states[152] = new State(new int[]{5,153});
    states[153] = new State(new int[]{11,154,30,16,31,30,26,156,32,37},new int[]{-9,155,-10,15,-11,34});
    states[154] = new State(-4);
    states[155] = new State(-16);
    states[156] = new State(new int[]{26,36});
    states[157] = new State(-15);
    states[158] = new State(new int[]{12,159});
    states[159] = new State(new int[]{10,160});
    states[160] = new State(new int[]{26,164},new int[]{-3,161,-2,186});
    states[161] = new State(new int[]{11,162,26,164},new int[]{-2,163});
    states[162] = new State(-3);
    states[163] = new State(-8);
    states[164] = new State(new int[]{6,165,12,182});
    states[165] = new State(new int[]{30,177,31,179},new int[]{-13,166,-10,181});
    states[166] = new State(new int[]{7,167,9,175});
    states[167] = new State(new int[]{12,168});
    states[168] = new State(new int[]{10,169});
    states[169] = new State(new int[]{42,174},new int[]{-4,170});
    states[170] = new State(new int[]{11,171,9,172});
    states[171] = new State(-9);
    states[172] = new State(new int[]{42,173});
    states[173] = new State(-14);
    states[174] = new State(-13);
    states[175] = new State(new int[]{30,177,31,179},new int[]{-10,176});
    states[176] = new State(-12);
    states[177] = new State(new int[]{26,178});
    states[178] = new State(new int[]{38,18});
    states[179] = new State(new int[]{26,180});
    states[180] = new State(new int[]{38,32});
    states[181] = new State(-11);
    states[182] = new State(new int[]{10,183});
    states[183] = new State(new int[]{42,174},new int[]{-4,184});
    states[184] = new State(new int[]{11,185,9,172});
    states[185] = new State(-10);
    states[186] = new State(-7);

    rules[1] = new Rule(-33, new int[]{-32,2});
    rules[2] = new Rule(-32, new int[]{-1,-8,-5,-14});
    rules[3] = new Rule(-1, new int[]{22,12,10,-3,11});
    rules[4] = new Rule(-8, new int[]{23,12,10,-12,5,11});
    rules[5] = new Rule(-5, new int[]{24,12,10,-6,5,11});
    rules[6] = new Rule(-14, new int[]{25,12,10,-30,11});
    rules[7] = new Rule(-3, new int[]{-2});
    rules[8] = new Rule(-3, new int[]{-3,-2});
    rules[9] = new Rule(-2, new int[]{26,6,-13,7,12,10,-4,11});
    rules[10] = new Rule(-2, new int[]{26,12,10,-4,11});
    rules[11] = new Rule(-13, new int[]{-10});
    rules[12] = new Rule(-13, new int[]{-13,9,-10});
    rules[13] = new Rule(-4, new int[]{42});
    rules[14] = new Rule(-4, new int[]{-4,9,42});
    rules[15] = new Rule(-12, new int[]{-9});
    rules[16] = new Rule(-12, new int[]{-12,5,-9});
    rules[17] = new Rule(-9, new int[]{-10});
    rules[18] = new Rule(-9, new int[]{-11});
    rules[19] = new Rule(-10, new int[]{30,26,38,29});
    rules[20] = new Rule(-10, new int[]{31,26,38,27});
    rules[21] = new Rule(-10, new int[]{30,26,38,-22});
    rules[22] = new Rule(-22, new int[]{41,6,29,7});
    rules[23] = new Rule(-22, new int[]{41,6,-15,7});
    rules[24] = new Rule(-11, new int[]{30,26});
    rules[25] = new Rule(-11, new int[]{31,26});
    rules[26] = new Rule(-11, new int[]{26,26});
    rules[27] = new Rule(-11, new int[]{32,26});
    rules[28] = new Rule(-6, new int[]{-7});
    rules[29] = new Rule(-6, new int[]{-6,5,-7});
    rules[30] = new Rule(-7, new int[]{-15,38,-17});
    rules[31] = new Rule(-7, new int[]{-15,38,13,-15,6,27,-16,7});
    rules[32] = new Rule(-7, new int[]{-15,38,13,32,6,-16,7});
    rules[33] = new Rule(-7, new int[]{-15,38,27});
    rules[34] = new Rule(-16, new int[]{9,-15,9,-15});
    rules[35] = new Rule(-16, new int[]{9,29,9,29});
    rules[36] = new Rule(-16, new int[]{29,9,29,9,27});
    rules[37] = new Rule(-16, new int[]{-15,9,-15,9,27});
    rules[38] = new Rule(-16, new int[]{9,29,9,-15});
    rules[39] = new Rule(-16, new int[]{9,-15,9,29});
    rules[40] = new Rule(-17, new int[]{-18});
    rules[41] = new Rule(-17, new int[]{-17,33,-18});
    rules[42] = new Rule(-17, new int[]{-17,34,-18});
    rules[43] = new Rule(-18, new int[]{-19});
    rules[44] = new Rule(-18, new int[]{-18,35,-19});
    rules[45] = new Rule(-18, new int[]{-18,36,-19});
    rules[46] = new Rule(-19, new int[]{-15});
    rules[47] = new Rule(-19, new int[]{29});
    rules[48] = new Rule(-19, new int[]{27});
    rules[49] = new Rule(-19, new int[]{37});
    rules[50] = new Rule(-15, new int[]{26});
    rules[51] = new Rule(-15, new int[]{26,19,26});
    rules[52] = new Rule(-23, new int[]{20,6,-24,7,10,-30,11});
    rules[53] = new Rule(-24, new int[]{37});
    rules[54] = new Rule(-24, new int[]{-25});
    rules[55] = new Rule(-24, new int[]{-17,38,38,-17});
    rules[56] = new Rule(-24, new int[]{-17,40,-17});
    rules[57] = new Rule(-24, new int[]{-17,39,-17});
    rules[58] = new Rule(-25, new int[]{15,19,26,6,-27,7});
    rules[59] = new Rule(-25, new int[]{15,19,26,6,7});
    rules[60] = new Rule(-27, new int[]{-20});
    rules[61] = new Rule(-27, new int[]{-27,9,-20});
    rules[62] = new Rule(-20, new int[]{-19});
    rules[63] = new Rule(-26, new int[]{14,19,26,6,-28,7});
    rules[64] = new Rule(-28, new int[]{-21});
    rules[65] = new Rule(-28, new int[]{-28,9,-21});
    rules[66] = new Rule(-21, new int[]{-19});
    rules[67] = new Rule(-31, new int[]{16,6,26,26,17,18,7,10,-30,11});
    rules[68] = new Rule(-30, new int[]{-29});
    rules[69] = new Rule(-30, new int[]{-30,-29});
    rules[70] = new Rule(-29, new int[]{-9,5});
    rules[71] = new Rule(-29, new int[]{-7,5});
    rules[72] = new Rule(-29, new int[]{-23});
    rules[73] = new Rule(-29, new int[]{-26,5});
    rules[74] = new Rule(-29, new int[]{-31});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
    switch (action)
    {
      case 2: // progr -> blockSpritesInit, blockVariablesInit, blockInitialize, blockUpdate
{ root.AddNode(ValueStack[ValueStack.Depth-4].spsIVal); root.AddNode(ValueStack[ValueStack.Depth-3].vInitVal); root.AddNode(ValueStack[ValueStack.Depth-2].initVal); root.AddNode(ValueStack[ValueStack.Depth-1].upVal);}
        break;
      case 3: // blockSpritesInit -> SPRITESINIT, ASSIGN, OPPARENTHESES, spritesInit, 
              //                     CLPARENTHESES
{ 
						CurrentSemanticValue.spsIVal = new SpritesInitNode();
						CurrentSemanticValue.spsIVal.inits = ValueStack[ValueStack.Depth-2].lstSIVal;
					}
        break;
      case 4: // blockVariablesInit -> VARIBLESINIT, ASSIGN, OPPARENTHESES, variablesList, 
              //                       SEMICOLON, CLPARENTHESES
{ CurrentSemanticValue.vInitVal = new VariablesInitNode();  CurrentSemanticValue.vInitVal.varNodes = ValueStack[ValueStack.Depth-3].lstvarVal;}
        break;
      case 5: // blockInitialize -> INITIALIZE, ASSIGN, OPPARENTHESES, initList, SEMICOLON, 
              //                    CLPARENTHESES
{ CurrentSemanticValue.initVal = new InitializeNode(); CurrentSemanticValue.initVal.assings = ValueStack[ValueStack.Depth-3].lstSingVal;}
        break;
      case 6: // blockUpdate -> UPDATE, ASSIGN, OPPARENTHESES, funList, CLPARENTHESES
{ 
					CurrentSemanticValue.upVal = new UpdateNode();
					CurrentSemanticValue.upVal.functionality = ValueStack[ValueStack.Depth-2].lstUlVal;
				}
        break;
      case 7: // spritesInit -> spriteInit
{
				CurrentSemanticValue.lstSIVal = new List<SpriteInitNode>();
				CurrentSemanticValue.lstSIVal.Add(ValueStack[ValueStack.Depth-1].spIVal);
			}
        break;
      case 8: // spritesInit -> spritesInit, spriteInit
{
				ValueStack[ValueStack.Depth-2].lstSIVal.Add(ValueStack[ValueStack.Depth-1].spIVal);
				CurrentSemanticValue.lstSIVal = ValueStack[ValueStack.Depth-2].lstSIVal;
			}
        break;
      case 9: // spriteInit -> ID, OPBRACKET, variablesSprite, CLBRACKET, ASSIGN, OPPARENTHESES, 
              //               behaviours, CLPARENTHESES
{
				CurrentSemanticValue.spIVal = new SpriteInitNode(ValueStack[ValueStack.Depth-8].sVal);
				CurrentSemanticValue.spIVal.behaviours = ValueStack[ValueStack.Depth-2].lstBVal;
				CurrentSemanticValue.spIVal.variables = ValueStack[ValueStack.Depth-6].lstvarVal;
			}
        break;
      case 10: // spriteInit -> ID, ASSIGN, OPPARENTHESES, behaviours, CLPARENTHESES
{
				CurrentSemanticValue.spIVal = new SpriteInitNode(ValueStack[ValueStack.Depth-5].sVal);
				CurrentSemanticValue.spIVal.behaviours = ValueStack[ValueStack.Depth-2].lstBVal;
			}
        break;
      case 11: // variablesSprite -> assignVariable
{
					CurrentSemanticValue.lstvarVal = new List<VarNode>();
					CurrentSemanticValue.lstvarVal.Add(ValueStack[ValueStack.Depth-1].varVal);
				}
        break;
      case 12: // variablesSprite -> variablesSprite, COMMA, assignVariable
{
					ValueStack[ValueStack.Depth-3].lstvarVal.Add(ValueStack[ValueStack.Depth-1].varVal);
					CurrentSemanticValue.lstvarVal = ValueStack[ValueStack.Depth-3].lstvarVal;
				}
        break;
      case 13: // behaviours -> BEHAVIOUR
{
				CurrentSemanticValue.lstBVal = new List<Type>();
				CurrentSemanticValue.lstBVal.Add(ValueStack[ValueStack.Depth-1].typeVal);
			}
        break;
      case 14: // behaviours -> behaviours, COMMA, BEHAVIOUR
{
				ValueStack[ValueStack.Depth-3].lstBVal.Add(ValueStack[ValueStack.Depth-1].typeVal);
				CurrentSemanticValue.lstBVal = ValueStack[ValueStack.Depth-3].lstBVal;
			}
        break;
      case 15: // variablesList -> assignOrVar
{
					CurrentSemanticValue.lstvarVal = new List<VarNode>();
					CurrentSemanticValue.lstvarVal.Add(ValueStack[ValueStack.Depth-1].varVal);
				}
        break;
      case 16: // variablesList -> variablesList, SEMICOLON, assignOrVar
{
					ValueStack[ValueStack.Depth-3].lstvarVal.Add(ValueStack[ValueStack.Depth-1].varVal);
					CurrentSemanticValue.lstvarVal = ValueStack[ValueStack.Depth-3].lstvarVal;
				}
        break;
      case 17: // assignOrVar -> assignVariable
{ CurrentSemanticValue.varVal = ValueStack[ValueStack.Depth-1].varVal; }
        break;
      case 18: // assignOrVar -> variable
{ CurrentSemanticValue.varVal = ValueStack[ValueStack.Depth-1].varVal; }
        break;
      case 19: // assignVariable -> INTTYPE, ID, EQUAL, INTNUM
{ CurrentSemanticValue.varVal = new VarNode(ValueStack[ValueStack.Depth-4].sVal, ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 20: // assignVariable -> STRINGTYPE, ID, EQUAL, STRING
{ CurrentSemanticValue.varVal = new VarNode(ValueStack[ValueStack.Depth-4].sVal, ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 21: // assignVariable -> INTTYPE, ID, EQUAL, rand
{ CurrentSemanticValue.varVal = new VarNode(ValueStack[ValueStack.Depth-4].sVal, ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 22: // rand -> RAND, OPBRACKET, INTNUM, CLBRACKET
{ CurrentSemanticValue.sVal = string.Format("{0}({1})", ValueStack[ValueStack.Depth-4].sVal, ValueStack[ValueStack.Depth-2].sVal); }
        break;
      case 23: // rand -> RAND, OPBRACKET, id, CLBRACKET
{  CurrentSemanticValue.sVal = string.Format("{0}({1})", ValueStack[ValueStack.Depth-4].sVal, ValueStack[ValueStack.Depth-2].sVal); }
        break;
      case 24: // variable -> INTTYPE, ID
{ CurrentSemanticValue.varVal = new VarNode(ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 25: // variable -> STRINGTYPE, ID
{ CurrentSemanticValue.varVal = new VarNode(ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 26: // variable -> ID, ID
{ CurrentSemanticValue.varVal = new VarNode(ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 27: // variable -> TEXTBOX, ID
{ CurrentSemanticValue.varVal = new VarNode(ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 28: // initList -> assign
{
				CurrentSemanticValue.lstSingVal = new List<AssignNode>();
				CurrentSemanticValue.lstSingVal.Add(ValueStack[ValueStack.Depth-1].singVal);
			}
        break;
      case 29: // initList -> initList, SEMICOLON, assign
{
				ValueStack[ValueStack.Depth-3].lstSingVal.Add(ValueStack[ValueStack.Depth-1].singVal);
				CurrentSemanticValue.lstSingVal = ValueStack[ValueStack.Depth-3].lstSingVal;
			}
        break;
      case 30: // assign -> id, EQUAL, expression
{
				CurrentSemanticValue.singVal = new AssignNode(ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-1].sVal);
			}
        break;
      case 31: // assign -> id, EQUAL, NEW, id, OPBRACKET, STRING, newParams, CLBRACKET
{
				CurrentSemanticValue.singVal = new AssignNode(ValueStack[ValueStack.Depth-8].sVal, ValueStack[ValueStack.Depth-5].sVal, ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-2].sVal);
			}
        break;
      case 32: // assign -> id, EQUAL, NEW, TEXTBOX, OPBRACKET, newParams, CLBRACKET
{
				CurrentSemanticValue.singVal = new AssignNode(ValueStack[ValueStack.Depth-7].sVal, ValueStack[ValueStack.Depth-4].sVal, ValueStack[ValueStack.Depth-2].sVal);
			}
        break;
      case 33: // assign -> id, EQUAL, STRING
{
				CurrentSemanticValue.singVal = new AssignNode(ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-1].sVal);
			}
        break;
      case 34: // newParams -> COMMA, id, COMMA, id
{
				CurrentSemanticValue.sVal = ',' + ValueStack[ValueStack.Depth-3].sVal + ',' + ValueStack[ValueStack.Depth-1].sVal;
			}
        break;
      case 35: // newParams -> COMMA, INTNUM, COMMA, INTNUM
{
				CurrentSemanticValue.sVal = ',' + ValueStack[ValueStack.Depth-3].sVal + ',' + ValueStack[ValueStack.Depth-1].sVal;
			}
        break;
      case 36: // newParams -> INTNUM, COMMA, INTNUM, COMMA, STRING
{
				CurrentSemanticValue.sVal = ',' + ValueStack[ValueStack.Depth-5].sVal + ',' + ValueStack[ValueStack.Depth-3].sVal + ',' + ValueStack[ValueStack.Depth-1].sVal;
			}
        break;
      case 37: // newParams -> id, COMMA, id, COMMA, STRING
{
				CurrentSemanticValue.sVal = ',' + ValueStack[ValueStack.Depth-5].sVal + ',' + ValueStack[ValueStack.Depth-3].sVal + ',' + ValueStack[ValueStack.Depth-1].sVal;
			}
        break;
      case 38: // newParams -> COMMA, INTNUM, COMMA, id
{
				CurrentSemanticValue.sVal = ',' + ValueStack[ValueStack.Depth-3].sVal + ',' + ValueStack[ValueStack.Depth-1].sVal;
			}
        break;
      case 39: // newParams -> COMMA, id, COMMA, INTNUM
{
				CurrentSemanticValue.sVal = ',' + ValueStack[ValueStack.Depth-3].sVal + ',' + ValueStack[ValueStack.Depth-1].sVal;
			}
        break;
      case 40: // expression -> T
{CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal;}
        break;
      case 41: // expression -> expression, ADD, T
{CurrentSemanticValue.sVal = string.Format("{0} {1} {2}", ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal);}
        break;
      case 42: // expression -> expression, SUBSTRACT, T
{CurrentSemanticValue.sVal = string.Format("{0} {1} {2}", ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal);}
        break;
      case 43: // T -> F
{CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal;}
        break;
      case 44: // T -> T, MULTIPLY, F
{CurrentSemanticValue.sVal = string.Format("{0} {1} {2}", ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal);}
        break;
      case 45: // T -> T, DIVIDE, F
{CurrentSemanticValue.sVal = string.Format("{0} {1} {2}", ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal);}
        break;
      case 46: // F -> id
{ CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal; }
        break;
      case 47: // F -> INTNUM
{ CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal; }
        break;
      case 48: // F -> STRING
{ CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal; }
        break;
      case 49: // F -> BOOLVAL
{ CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal; }
        break;
      case 50: // id -> ID
{
				CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal;
			}
        break;
      case 51: // id -> ID, DOT, ID
{ CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-3].sVal + "." + ValueStack[ValueStack.Depth-1].sVal; }
        break;
      case 52: // if -> IF, OPBRACKET, logic, CLBRACKET, OPPARENTHESES, funList, CLPARENTHESES
{
				CurrentSemanticValue.ifVal = new IfNode();
				CurrentSemanticValue.ifVal.condition = ValueStack[ValueStack.Depth-5].logicVal;
				CurrentSemanticValue.ifVal.statements = ValueStack[ValueStack.Depth-2].lstUlVal;
			}
        break;
      case 53: // logic -> BOOLVAL
{ CurrentSemanticValue.logicVal = new LogicalNode(ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 54: // logic -> condition
{ CurrentSemanticValue.logicVal = new LogicalNode(ValueStack[ValueStack.Depth-1].condVal.ToString()); }
        break;
      case 55: // logic -> expression, EQUAL, EQUAL, expression
{ CurrentSemanticValue.logicVal = new LogicalNode(ValueStack[ValueStack.Depth-4].sVal, ValueStack[ValueStack.Depth-3].sVal + ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 56: // logic -> expression, MORE, expression
{ CurrentSemanticValue.logicVal = new LogicalNode(ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 57: // logic -> expression, LESS, expression
{ CurrentSemanticValue.logicVal = new LogicalNode(ValueStack[ValueStack.Depth-3].sVal, ValueStack[ValueStack.Depth-2].sVal, ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 58: // condition -> CONDITION, DOT, ID, OPBRACKET, conditionParams, CLBRACKET
{
				CurrentSemanticValue.condVal = new ConditionNode(ValueStack[ValueStack.Depth-4].sVal);
				CurrentSemanticValue.condVal.conditionParams = ValueStack[ValueStack.Depth-2].lstSVal;
			}
        break;
      case 59: // condition -> CONDITION, DOT, ID, OPBRACKET, CLBRACKET
{
				CurrentSemanticValue.condVal = new ConditionNode(ValueStack[ValueStack.Depth-3].sVal);
			}
        break;
      case 60: // conditionParams -> conditionParam
{
					CurrentSemanticValue.lstSVal = new List<string>();
					CurrentSemanticValue.lstSVal.Add(ValueStack[ValueStack.Depth-1].sVal);
				}
        break;
      case 61: // conditionParams -> conditionParams, COMMA, conditionParam
{
					ValueStack[ValueStack.Depth-3].lstSVal.Add(ValueStack[ValueStack.Depth-1].sVal);
					CurrentSemanticValue.lstSVal = ValueStack[ValueStack.Depth-3].lstSVal;
				}
        break;
      case 62: // conditionParam -> F
{ CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal; }
        break;
      case 63: // action -> ACTION, DOT, ID, OPBRACKET, actionParams, CLBRACKET
{
			CurrentSemanticValue.actVal = new ActionNode(ValueStack[ValueStack.Depth-4].sVal);
			CurrentSemanticValue.actVal.ActionParams = ValueStack[ValueStack.Depth-2].lstSVal;
		}
        break;
      case 64: // actionParams -> actionParam
{
					CurrentSemanticValue.lstSVal = new List<string>();
					CurrentSemanticValue.lstSVal.Add(ValueStack[ValueStack.Depth-1].sVal);
				}
        break;
      case 65: // actionParams -> actionParams, COMMA, actionParam
{
					ValueStack[ValueStack.Depth-3].lstSVal.Add(ValueStack[ValueStack.Depth-1].sVal);
					CurrentSemanticValue.lstSVal = ValueStack[ValueStack.Depth-3].lstSVal;
				}
        break;
      case 66: // actionParam -> F
{ CurrentSemanticValue.sVal = ValueStack[ValueStack.Depth-1].sVal; }
        break;
      case 67: // forEach -> FOREACH, OPBRACKET, ID, ID, IN, SPRITES, CLBRACKET, OPPARENTHESES, 
               //            funList, CLPARENTHESES
{
			CurrentSemanticValue.feVal = new ForEachNode(ValueStack[ValueStack.Depth-8].sVal, ValueStack[ValueStack.Depth-7].sVal);
			CurrentSemanticValue.feVal.statements = ValueStack[ValueStack.Depth-2].lstUlVal;
		}
        break;
      case 68: // funList -> functionality
{
			CurrentSemanticValue.lstUlVal = new List<UpdateLogicNode>();
			CurrentSemanticValue.lstUlVal.Add(ValueStack[ValueStack.Depth-1].ulVal);
		}
        break;
      case 69: // funList -> funList, functionality
{
			ValueStack[ValueStack.Depth-2].lstUlVal.Add(ValueStack[ValueStack.Depth-1].ulVal);
			CurrentSemanticValue.lstUlVal = ValueStack[ValueStack.Depth-2].lstUlVal;
		}
        break;
      case 70: // functionality -> assignOrVar, SEMICOLON
{ 
					CurrentSemanticValue.ulVal = new UpdateLogicNode(ValueStack[ValueStack.Depth-2].varVal.ToString());
				}
        break;
      case 71: // functionality -> assign, SEMICOLON
{ 
					CurrentSemanticValue.ulVal = new UpdateLogicNode(ValueStack[ValueStack.Depth-2].singVal);
				}
        break;
      case 72: // functionality -> if
{ CurrentSemanticValue.ulVal = new UpdateLogicNode(ValueStack[ValueStack.Depth-1].ifVal); }
        break;
      case 73: // functionality -> action, SEMICOLON
{ CurrentSemanticValue.ulVal = new UpdateLogicNode(ValueStack[ValueStack.Depth-2].actVal.ToString()); }
        break;
      case 74: // functionality -> forEach
{
					CurrentSemanticValue.ulVal = new UpdateLogicNode(ValueStack[ValueStack.Depth-1].feVal);
				}
        break;
    }
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
