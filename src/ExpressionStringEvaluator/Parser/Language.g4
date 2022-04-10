grammar Language;

/*------------------------------------------------------------------
 * PARSER RULES
 *------------------------------------------------------------------*/
expression          : ( envvariable | booleanexpression | textWithSpaces | variable | function )*
                    ;

expression2         : ( envvariable | booleanexpression | words | variable | function )* | '"' expression '"'
                    ;

booleanexpression   : ( TRUE | FALSE )
                    ;

envvariable         : '%' KEY '%'
                    ;

variable            : '{' var=KEY (':' arg=textWithSpaces)? '}'
                    ;

function            : '{' func=KEY '(' arg=args ')' '}'
                    ;

args                : ar1=expression ( ' '* ',' ' '* expression2 )+
                    ;

textWithSpaces      : (WORD | KEY | ':' | ' ' | TRUE | FALSE )+
                    ;

words               : ( WORD | KEY | ':' )+
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
fragment PERCENT    : '%' ;
fragment ATSIGN     : '@' ;

TRUE                : ( T R U E   | '1');
FALSE               : ( F A L S E | '0' );

KEY                 : LETTER(LETTER|DIGIT|UNDERSCORE|DOT|MINUS)+ ;
WORD                : (LETTER|DIGIT|UNDERSCORE|DOT|MINUS|SLASH|ATSIGN)+;
NEWLINE             : ('\r'? '\n' | '\r') -> channel(HIDDEN) ;
WHITESPACE          : (' ' | '\t' ) -> channel(HIDDEN) ;