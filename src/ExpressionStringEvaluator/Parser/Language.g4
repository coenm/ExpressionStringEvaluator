grammar Language;

/*------------------------------------------------------------------
 * PARSER RULES
 *------------------------------------------------------------------*/
textExpression          : ( envvariable | booleanexpression | textWithSpaces | variable | function )*
                        ;

argumentExpression      : ( envvariable | booleanexpression | words | variable | function )* | '"' argumentTextExpression '"'
                        ;

argumentTextExpression  : ( envvariable | booleanexpression | textWithSpacesEscaped | variable | function )*
                        ;

booleanexpression       : ( TRUE | FALSE )
                        ;

envvariable             : '%' KEY '%'
                        ;

variable                : '{' var=KEY (':' arg=textWithSpaces)? '}'
                        ;

function                : '{' func=KEY '(' ' '* arg=args ' '* ')' '}'
                        ;

args                    : argumentExpression ( ' '* ',' ' '* argumentExpression ' '*)* 
                        ;

textWithSpaces          : (WORD | KEY | ':' | ' ' | ',' | TRUE | FALSE | '"' )+
                        ;

textWithSpacesEscaped   : (WORD | KEY | ':' | ' ' | ',' | TRUE | FALSE | '\\' '"' )+
                        ;

words                   : ( WORD | KEY | ':' )+
                        ;

/*------------------------------------------------------------------
 * LEXER RULES
 *------------------------------------------------------------------*/
fragment T          : ('T'|'t') ;
fragment R          : ('R'|'r') ;
fragment U          : ('U'|'u') ;
fragment E          : ('E'|'e') ;
fragment F          : ('F'|'f') ;
fragment A          : ('A'|'a') ;
fragment L          : ('L'|'l') ;
fragment S          : ('S'|'s') ;

fragment LETTER     : [a-zA-Z] ;
fragment DIGIT      : [0-9] ;
fragment UNDERSCORE : '_' ;
fragment WS         : ' ' ;
fragment DOT        : '.' ;
fragment MINUS      : '-' ;
fragment SEMICOLUMN : ':' ;
fragment SLASH      : '/' ;
fragment BACKSLASH  : '\\' '\\' ;
fragment PERCENT    : '\\' '%' ;
fragment BRACKET_OPEN    : '\\' '{' ;
fragment BRACKET_CLOSE    : '\\' '}' ;
fragment ATSIGN     : '@' ;
fragment SYMBOLS    : ('?'|'!'|'#'|'$'|'^'|'&'|'*'|'='|';'|'>'|'<') ;
fragment BR_OPEN : '[';
fragment BR_CLOSE : ']';

TRUE                : ( T R U E );
FALSE               : ( F A L S E );

KEY                 : LETTER(LETTER|DIGIT|UNDERSCORE|DOT|MINUS|BR_OPEN|BR_CLOSE)+ ;
WORD                : (LETTER|DIGIT|UNDERSCORE|DOT|MINUS|SLASH|BACKSLASH|PERCENT|BRACKET_OPEN|BRACKET_CLOSE|ATSIGN|SYMBOLS)+;
NEWLINE             : ('\r'? '\n' | '\r') -> channel(HIDDEN) ;
WHITESPACE          : (' ' | '\t' ) -> channel(HIDDEN) ;