/* The following code was generated by JFlex 1.6.1 */

package examenfinal;
import java_cup.runtime.*;
import javax.swing.*;
import java.util.*;


/**
 * This class is a scanner generated by 
 * <a href="http://www.jflex.de/">JFlex</a> 1.6.1
 * from the specification file <tt>lexico.flex</tt>
 */
public class Lexico implements java_cup.runtime.Scanner {

  /** This character denotes the end of file */
  public static final int YYEOF = -1;

  /** initial size of the lookahead buffer */
  private static final int ZZ_BUFFERSIZE = 16384;

  /** lexical states */
  public static final int YYINITIAL = 0;
  public static final int A = 2;

  /**
   * ZZ_LEXSTATE[l] is the state in the DFA for the lexical state l
   * ZZ_LEXSTATE[l+1] is the state in the DFA for the lexical state l
   *                  at the beginning of a line
   * l is of the form l = 2*k, k a non negative integer
   */
  private static final int ZZ_LEXSTATE[] = { 
     0,  0,  1, 1
  };

  /** 
   * Translates characters to character classes
   */
  private static final String ZZ_CMAP_PACKED = 
    "\11\0\1\6\1\7\1\100\1\7\1\100\22\0\1\10\1\13\1\11"+
    "\2\0\1\36\1\34\1\12\1\25\1\26\1\21\1\17\1\22\1\4"+
    "\1\5\1\20\12\2\1\30\1\27\1\14\1\16\1\15\2\0\1\74"+
    "\1\54\1\56\1\47\1\76\2\1\1\70\1\40\3\1\1\72\2\1"+
    "\1\67\1\1\1\66\1\62\1\75\1\1\1\64\1\1\1\77\2\1"+
    "\1\23\1\3\1\24\1\33\1\1\1\0\1\46\1\61\1\65\1\1"+
    "\1\50\1\51\1\63\1\57\1\52\1\73\1\1\1\55\1\41\1\53"+
    "\1\43\1\42\1\1\1\44\1\71\1\45\1\60\5\1\1\31\1\35"+
    "\1\32\1\37\6\0\1\100\73\0\1\1\7\0\1\1\3\0\1\1"+
    "\3\0\1\1\1\0\1\1\6\0\1\1\6\0\1\1\7\0\1\1"+
    "\3\0\1\1\3\0\1\1\1\0\1\1\6\0\1\1\u1f2d\0\1\100"+
    "\1\100\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\uffff\0\udfe6\0";

  /** 
   * Translates characters to character classes
   */
  private static final char [] ZZ_CMAP = zzUnpackCMap(ZZ_CMAP_PACKED);

  /** 
   * Translates DFA states to action switch labels.
   */
  private static final int [] ZZ_ACTION = zzUnpackAction();

  private static final String ZZ_ACTION_PACKED_0 =
    "\2\0\1\1\1\2\1\3\1\4\1\5\1\6\1\7"+
    "\1\1\1\10\1\11\1\12\1\13\1\14\1\15\1\16"+
    "\1\17\1\20\1\21\1\22\1\23\1\24\1\25\1\26"+
    "\1\27\1\30\1\31\1\1\1\7\1\32\1\33\12\2"+
    "\2\0\1\3\1\34\2\0\1\35\4\0\1\36\1\37"+
    "\1\40\1\0\1\41\1\42\1\43\1\44\1\45\1\46"+
    "\12\2\1\47\7\2\1\50\4\0\1\51\5\0\1\2"+
    "\1\52\21\2\5\0\1\36\6\2\1\53\1\2\1\54"+
    "\2\2\1\55\3\2\1\56\3\2\4\0\11\2\1\57"+
    "\2\2\1\60\2\2\2\0\1\2\1\61\5\2\1\62"+
    "\6\2\1\63\1\64\1\65\3\2\1\66\1\2\1\67"+
    "\1\2\1\70\6\2\1\71\1\2\1\72\1\2\1\73"+
    "\1\2\1\74\1\75\1\76\1\77";

  private static int [] zzUnpackAction() {
    int [] result = new int[198];
    int offset = 0;
    offset = zzUnpackAction(ZZ_ACTION_PACKED_0, offset, result);
    return result;
  }

  private static int zzUnpackAction(String packed, int offset, int [] result) {
    int i = 0;       /* index in packed string  */
    int j = offset;  /* index in unpacked array */
    int l = packed.length();
    while (i < l) {
      int count = packed.charAt(i++);
      int value = packed.charAt(i++);
      do result[j++] = value; while (--count > 0);
    }
    return j;
  }


  /** 
   * Translates a state to a row index in the transition table
   */
  private static final int [] ZZ_ROWMAP = zzUnpackRowMap();

  private static final String ZZ_ROWMAP_PACKED_0 =
    "\0\0\0\101\0\202\0\303\0\u0104\0\202\0\u0145\0\202"+
    "\0\202\0\u0186\0\u01c7\0\u0208\0\u0249\0\u028a\0\u02cb\0\u030c"+
    "\0\202\0\202\0\202\0\202\0\202\0\202\0\202\0\202"+
    "\0\202\0\202\0\202\0\202\0\u034d\0\u038e\0\202\0\202"+
    "\0\u03cf\0\u0410\0\u0451\0\u0492\0\u04d3\0\u0514\0\u0555\0\u0596"+
    "\0\u05d7\0\u0618\0\u0659\0\u069a\0\u06db\0\202\0\u0186\0\u071c"+
    "\0\202\0\u075d\0\u079e\0\u01c7\0\u07df\0\u0820\0\202\0\202"+
    "\0\u0861\0\202\0\202\0\202\0\202\0\202\0\202\0\u08a2"+
    "\0\u08e3\0\u0924\0\u0965\0\u09a6\0\u09e7\0\u0a28\0\u0a69\0\u0aaa"+
    "\0\u0aeb\0\u0b2c\0\u0b6d\0\u0bae\0\u0bef\0\u0c30\0\u0c71\0\u0cb2"+
    "\0\u0cf3\0\u069a\0\u0d34\0\u0d75\0\u0db6\0\u0df7\0\202\0\u0e38"+
    "\0\u0e79\0\u0eba\0\u0efb\0\u0f3c\0\u0f7d\0\303\0\u0fbe\0\u0fff"+
    "\0\u1040\0\u1081\0\u10c2\0\u1103\0\u1144\0\u1185\0\u11c6\0\u1207"+
    "\0\u1248\0\u1289\0\u12ca\0\u130b\0\u134c\0\u138d\0\u13ce\0\u140f"+
    "\0\u1450\0\u1491\0\u14d2\0\u1513\0\202\0\u1554\0\u1595\0\u15d6"+
    "\0\u1617\0\u1658\0\u1699\0\303\0\u16da\0\303\0\u171b\0\u175c"+
    "\0\303\0\u179d\0\u17de\0\u181f\0\303\0\u1860\0\u18a1\0\u18e2"+
    "\0\u1923\0\u1964\0\u19a5\0\u19e6\0\u1a27\0\u1a68\0\u1aa9\0\u1aea"+
    "\0\u1b2b\0\u1b6c\0\u1bad\0\u1bee\0\u1c2f\0\303\0\u1c70\0\u1cb1"+
    "\0\303\0\u1cf2\0\u1d33\0\u1d74\0\u1db5\0\u1df6\0\303\0\u1e37"+
    "\0\u1e78\0\u1eb9\0\u1efa\0\u1f3b\0\303\0\u1f7c\0\u1fbd\0\u1ffe"+
    "\0\u203f\0\u2080\0\u20c1\0\303\0\303\0\303\0\u2102\0\u2143"+
    "\0\u2184\0\303\0\u21c5\0\303\0\u2206\0\303\0\u2247\0\u2288"+
    "\0\u22c9\0\u230a\0\u234b\0\u238c\0\303\0\u23cd\0\303\0\u240e"+
    "\0\303\0\u244f\0\303\0\303\0\303\0\303";

  private static int [] zzUnpackRowMap() {
    int [] result = new int[198];
    int offset = 0;
    offset = zzUnpackRowMap(ZZ_ROWMAP_PACKED_0, offset, result);
    return result;
  }

  private static int zzUnpackRowMap(String packed, int offset, int [] result) {
    int i = 0;  /* index in packed string  */
    int j = offset;  /* index in unpacked array */
    int l = packed.length();
    while (i < l) {
      int high = packed.charAt(i++) << 16;
      result[j++] = high | packed.charAt(i++);
    }
    return j;
  }

  /** 
   * The transition table of the DFA
   */
  private static final int [] ZZ_TRANS = zzUnpackTrans();

  private static final String ZZ_TRANS_PACKED_0 =
    "\1\3\1\4\1\5\1\6\1\7\1\10\3\11\1\12"+
    "\1\13\1\14\1\15\1\16\1\17\1\20\1\21\1\22"+
    "\1\23\1\24\1\25\1\26\1\27\1\30\1\31\1\32"+
    "\1\33\1\34\1\35\1\36\1\37\1\40\1\41\6\4"+
    "\1\42\4\4\1\43\1\4\1\44\3\4\1\45\1\4"+
    "\1\46\1\4\1\47\1\50\1\51\1\4\1\52\5\4"+
    "\1\0\7\3\1\0\70\3\103\0\2\4\1\0\1\53"+
    "\33\0\40\4\3\0\1\5\2\0\1\54\75\0\1\55"+
    "\1\0\1\56\75\0\3\57\1\60\4\57\1\61\1\62"+
    "\1\57\2\0\5\57\2\0\6\57\2\0\1\57\2\0"+
    "\40\57\2\0\2\63\1\64\1\65\1\64\5\0\1\64"+
    "\2\0\5\64\2\0\6\64\5\0\40\63\14\0\1\66"+
    "\2\0\1\67\15\0\1\70\60\0\1\71\1\0\1\72"+
    "\100\0\1\73\100\0\1\74\101\0\1\75\115\0\1\76"+
    "\101\0\1\77\44\0\2\4\1\0\1\53\33\0\1\4"+
    "\1\100\11\4\1\101\24\4\2\0\2\4\1\0\1\53"+
    "\33\0\3\4\1\102\4\4\1\103\1\4\1\104\25\4"+
    "\2\0\2\4\1\0\1\53\33\0\3\4\1\105\34\4"+
    "\2\0\2\4\1\0\1\53\33\0\3\4\1\106\13\4"+
    "\1\107\20\4\2\0\2\4\1\0\1\53\33\0\5\4"+
    "\1\110\2\4\1\111\1\4\1\112\25\4\2\0\2\4"+
    "\1\0\1\53\33\0\6\4\1\113\31\4\2\0\2\4"+
    "\1\0\1\53\33\0\10\4\1\114\27\4\2\0\2\4"+
    "\1\0\1\53\33\0\4\4\1\115\1\4\1\116\31\4"+
    "\2\0\2\4\1\0\1\53\33\0\6\4\1\117\31\4"+
    "\2\0\2\4\1\0\1\53\33\0\3\4\1\120\6\4"+
    "\1\121\25\4\3\0\1\4\100\0\1\122\102\0\1\123"+
    "\76\0\1\57\77\0\2\124\1\62\1\125\1\62\5\0"+
    "\1\62\2\0\5\62\2\0\6\62\5\0\40\124\2\0"+
    "\2\63\1\126\1\65\1\126\3\63\1\0\1\127\1\126"+
    "\2\0\5\126\2\0\6\126\2\0\1\63\2\0\40\63"+
    "\3\0\1\63\77\0\3\66\1\130\1\66\2\0\1\66"+
    "\1\131\1\0\1\66\2\0\5\66\2\0\6\66\5\0"+
    "\40\66\2\0\3\71\1\132\4\71\1\133\1\0\1\71"+
    "\1\0\1\134\5\71\2\0\6\71\2\0\1\71\2\0"+
    "\40\71\2\0\2\4\1\0\1\53\33\0\2\4\1\135"+
    "\35\4\2\0\2\4\1\0\1\53\33\0\5\4\1\136"+
    "\32\4\2\0\2\4\1\0\1\53\33\0\20\4\1\137"+
    "\17\4\2\0\2\4\1\0\1\53\33\0\5\4\1\140"+
    "\3\4\1\141\26\4\2\0\2\4\1\0\1\53\33\0"+
    "\21\4\1\142\16\4\2\0\2\4\1\0\1\53\33\0"+
    "\3\4\1\143\34\4\2\0\2\4\1\0\1\53\33\0"+
    "\13\4\1\144\24\4\2\0\2\4\1\0\1\53\33\0"+
    "\6\4\1\145\31\4\2\0\2\4\1\0\1\53\33\0"+
    "\4\4\1\146\33\4\2\0\2\4\1\0\1\53\33\0"+
    "\15\4\1\147\22\4\2\0\2\4\1\0\1\53\33\0"+
    "\13\4\1\150\24\4\2\0\2\4\1\0\1\53\33\0"+
    "\25\4\1\151\12\4\2\0\2\4\1\0\1\53\33\0"+
    "\5\4\1\152\32\4\2\0\2\4\1\0\1\53\33\0"+
    "\12\4\1\153\25\4\2\0\2\4\1\0\1\53\33\0"+
    "\4\4\1\154\33\4\2\0\2\4\1\0\1\53\33\0"+
    "\31\4\1\155\6\4\2\0\2\4\1\0\1\53\33\0"+
    "\31\4\1\156\6\4\2\0\2\4\1\0\1\53\33\0"+
    "\10\4\1\157\27\4\3\0\1\55\77\0\2\124\1\160"+
    "\1\125\1\160\3\124\1\0\1\57\1\160\2\0\5\160"+
    "\2\0\6\160\2\0\1\124\2\0\40\124\3\0\1\124"+
    "\77\0\2\63\1\126\1\65\1\126\4\0\1\127\1\126"+
    "\2\0\5\126\2\0\6\126\5\0\40\63\3\0\1\66"+
    "\77\0\3\131\1\161\4\131\1\66\1\162\1\131\2\0"+
    "\5\131\2\0\6\131\2\0\1\131\2\0\40\131\3\0"+
    "\1\71\77\0\3\133\1\163\4\133\1\71\1\164\1\133"+
    "\2\0\5\133\2\0\6\133\2\0\1\133\2\0\40\133"+
    "\16\0\1\165\64\0\2\4\1\0\1\53\33\0\3\4"+
    "\1\166\34\4\2\0\2\4\1\0\1\53\33\0\21\4"+
    "\1\167\16\4\2\0\2\4\1\0\1\53\33\0\10\4"+
    "\1\170\27\4\2\0\2\4\1\0\1\53\33\0\10\4"+
    "\1\171\1\4\1\172\25\4\2\0\2\4\1\0\1\53"+
    "\33\0\20\4\1\173\17\4\2\0\2\4\1\0\1\53"+
    "\33\0\15\4\1\174\22\4\2\0\2\4\1\0\1\53"+
    "\33\0\5\4\1\175\32\4\2\0\2\4\1\0\1\53"+
    "\33\0\4\4\1\176\33\4\2\0\2\4\1\0\1\53"+
    "\33\0\12\4\1\177\25\4\2\0\2\4\1\0\1\53"+
    "\33\0\10\4\1\200\27\4\2\0\2\4\1\0\1\53"+
    "\33\0\3\4\1\201\34\4\2\0\2\4\1\0\1\53"+
    "\33\0\12\4\1\202\25\4\2\0\2\4\1\0\1\53"+
    "\33\0\3\4\1\203\34\4\2\0\2\4\1\0\1\53"+
    "\33\0\13\4\1\204\24\4\2\0\2\4\1\0\1\53"+
    "\33\0\6\4\1\205\31\4\2\0\2\4\1\0\1\53"+
    "\33\0\5\4\1\206\32\4\2\0\2\4\1\0\1\53"+
    "\33\0\5\4\1\207\32\4\2\0\2\4\1\0\1\53"+
    "\33\0\13\4\1\210\24\4\2\0\2\124\1\160\1\125"+
    "\1\160\4\0\1\57\1\160\2\0\5\160\2\0\6\160"+
    "\5\0\40\124\3\0\1\131\77\0\2\211\1\162\1\212"+
    "\1\162\5\0\1\162\2\0\5\162\2\0\6\162\5\0"+
    "\40\211\3\0\1\133\77\0\2\213\1\164\1\214\1\164"+
    "\5\0\1\164\2\0\5\164\2\0\6\164\5\0\40\213"+
    "\2\0\2\4\1\0\1\53\33\0\4\4\1\215\33\4"+
    "\2\0\2\4\1\0\1\53\33\0\15\4\1\216\22\4"+
    "\2\0\2\4\1\0\1\53\33\0\13\4\1\217\24\4"+
    "\2\0\2\4\1\0\1\53\33\0\25\4\1\220\12\4"+
    "\2\0\2\4\1\0\1\53\33\0\13\4\1\221\24\4"+
    "\2\0\2\4\1\0\1\53\33\0\33\4\1\222\4\4"+
    "\2\0\2\4\1\0\1\53\33\0\12\4\1\223\25\4"+
    "\2\0\2\4\1\0\1\53\33\0\13\4\1\224\24\4"+
    "\2\0\2\4\1\0\1\53\33\0\25\4\1\225\12\4"+
    "\2\0\2\4\1\0\1\53\33\0\3\4\1\226\34\4"+
    "\2\0\2\4\1\0\1\53\33\0\4\4\1\227\33\4"+
    "\2\0\2\4\1\0\1\53\33\0\25\4\1\230\12\4"+
    "\2\0\2\4\1\0\1\53\33\0\6\4\1\231\31\4"+
    "\2\0\2\4\1\0\1\53\33\0\4\4\1\232\33\4"+
    "\2\0\2\4\1\0\1\53\33\0\5\4\1\233\32\4"+
    "\2\0\2\211\1\234\1\212\1\234\3\211\1\0\1\131"+
    "\1\234\2\0\5\234\2\0\6\234\2\0\1\211\2\0"+
    "\40\211\3\0\1\211\77\0\2\213\1\235\1\214\1\235"+
    "\3\213\1\0\1\133\1\235\2\0\5\235\2\0\6\235"+
    "\2\0\1\213\2\0\40\213\3\0\1\213\77\0\2\4"+
    "\1\0\1\53\33\0\5\4\1\236\32\4\2\0\2\4"+
    "\1\0\1\53\33\0\10\4\1\237\27\4\2\0\2\4"+
    "\1\0\1\53\33\0\10\4\1\240\27\4\2\0\2\4"+
    "\1\0\1\53\33\0\5\4\1\241\32\4\2\0\2\4"+
    "\1\0\1\53\33\0\12\4\1\242\25\4\2\0\2\4"+
    "\1\0\1\53\33\0\6\4\1\243\31\4\2\0\2\4"+
    "\1\0\1\53\33\0\13\4\1\244\24\4\2\0\2\4"+
    "\1\0\1\53\33\0\23\4\1\245\14\4\2\0\2\4"+
    "\1\0\1\53\33\0\25\4\1\246\12\4\2\0\2\4"+
    "\1\0\1\53\33\0\13\4\1\247\24\4\2\0\2\4"+
    "\1\0\1\53\33\0\12\4\1\250\25\4\2\0\2\4"+
    "\1\0\1\53\33\0\6\4\1\251\31\4\2\0\2\4"+
    "\1\0\1\53\33\0\4\4\1\252\33\4\2\0\2\211"+
    "\1\234\1\212\1\234\4\0\1\131\1\234\2\0\5\234"+
    "\2\0\6\234\5\0\40\211\2\0\2\213\1\235\1\214"+
    "\1\235\4\0\1\133\1\235\2\0\5\235\2\0\6\235"+
    "\5\0\40\213\2\0\2\4\1\0\1\53\33\0\6\4"+
    "\1\253\31\4\2\0\2\4\1\0\1\53\33\0\4\4"+
    "\1\254\33\4\2\0\2\4\1\0\1\53\33\0\3\4"+
    "\1\255\34\4\2\0\2\4\1\0\1\53\33\0\4\4"+
    "\1\256\33\4\2\0\2\4\1\0\1\53\33\0\4\4"+
    "\1\257\33\4\2\0\2\4\1\0\1\53\33\0\20\4"+
    "\1\260\17\4\2\0\2\4\1\0\1\53\33\0\12\4"+
    "\1\261\25\4\2\0\2\4\1\0\1\53\33\0\3\4"+
    "\1\262\34\4\2\0\2\4\1\0\1\53\33\0\2\4"+
    "\1\263\35\4\2\0\2\4\1\0\1\53\33\0\4\4"+
    "\1\264\33\4\2\0\2\4\1\0\1\53\33\0\6\4"+
    "\1\265\31\4\2\0\2\4\1\0\1\53\33\0\4\4"+
    "\1\266\33\4\2\0\2\4\1\0\1\53\33\0\34\4"+
    "\1\267\1\270\1\271\1\4\2\0\2\4\1\0\1\53"+
    "\33\0\6\4\1\272\31\4\2\0\2\4\1\0\1\53"+
    "\33\0\3\4\1\273\34\4\2\0\2\4\1\0\1\53"+
    "\33\0\6\4\1\274\31\4\2\0\2\4\1\0\1\53"+
    "\33\0\31\4\1\275\6\4\2\0\2\4\1\0\1\53"+
    "\33\0\22\4\1\276\15\4\2\0\2\4\1\0\1\53"+
    "\33\0\22\4\1\277\15\4\2\0\2\4\1\0\1\53"+
    "\33\0\37\4\1\300\2\0\2\4\1\0\1\53\33\0"+
    "\4\4\1\301\33\4\2\0\2\4\1\0\1\53\33\0"+
    "\13\4\1\302\24\4\2\0\2\4\1\0\1\53\33\0"+
    "\15\4\1\303\22\4\2\0\2\4\1\0\1\53\33\0"+
    "\35\4\1\304\2\4\2\0\2\4\1\0\1\53\33\0"+
    "\27\4\1\305\10\4\2\0\2\4\1\0\1\53\33\0"+
    "\6\4\1\306\31\4\1\0";

  private static int [] zzUnpackTrans() {
    int [] result = new int[9360];
    int offset = 0;
    offset = zzUnpackTrans(ZZ_TRANS_PACKED_0, offset, result);
    return result;
  }

  private static int zzUnpackTrans(String packed, int offset, int [] result) {
    int i = 0;       /* index in packed string  */
    int j = offset;  /* index in unpacked array */
    int l = packed.length();
    while (i < l) {
      int count = packed.charAt(i++);
      int value = packed.charAt(i++);
      value--;
      do result[j++] = value; while (--count > 0);
    }
    return j;
  }


  /* error codes */
  private static final int ZZ_UNKNOWN_ERROR = 0;
  private static final int ZZ_NO_MATCH = 1;
  private static final int ZZ_PUSHBACK_2BIG = 2;

  /* error messages for the codes above */
  private static final String ZZ_ERROR_MSG[] = {
    "Unknown internal scanner error",
    "Error: could not match input",
    "Error: pushback value was too large"
  };

  /**
   * ZZ_ATTRIBUTE[aState] contains the attributes of state <code>aState</code>
   */
  private static final int [] ZZ_ATTRIBUTE = zzUnpackAttribute();

  private static final String ZZ_ATTRIBUTE_PACKED_0 =
    "\2\0\1\11\2\1\1\11\1\1\2\11\7\1\14\11"+
    "\2\1\2\11\12\1\2\0\1\1\1\11\2\0\1\11"+
    "\4\0\1\1\2\11\1\0\6\11\23\1\4\0\1\11"+
    "\5\0\23\1\5\0\1\11\23\1\4\0\17\1\2\0"+
    "\51\1";

  private static int [] zzUnpackAttribute() {
    int [] result = new int[198];
    int offset = 0;
    offset = zzUnpackAttribute(ZZ_ATTRIBUTE_PACKED_0, offset, result);
    return result;
  }

  private static int zzUnpackAttribute(String packed, int offset, int [] result) {
    int i = 0;       /* index in packed string  */
    int j = offset;  /* index in unpacked array */
    int l = packed.length();
    while (i < l) {
      int count = packed.charAt(i++);
      int value = packed.charAt(i++);
      do result[j++] = value; while (--count > 0);
    }
    return j;
  }

  /** the input device */
  private java.io.Reader zzReader;

  /** the current state of the DFA */
  private int zzState;

  /** the current lexical state */
  private int zzLexicalState = YYINITIAL;

  /** this buffer contains the current text to be matched and is
      the source of the yytext() string */
  private char zzBuffer[] = new char[ZZ_BUFFERSIZE];

  /** the textposition at the last accepting state */
  private int zzMarkedPos;

  /** the current text position in the buffer */
  private int zzCurrentPos;

  /** startRead marks the beginning of the yytext() string in the buffer */
  private int zzStartRead;

  /** endRead marks the last character in the buffer, that has been read
      from input */
  private int zzEndRead;

  /** number of newlines encountered up to the start of the matched text */
  private int yyline;

  /** the number of characters up to the start of the matched text */
  private int yychar;

  /**
   * the number of characters from the last newline up to the start of the 
   * matched text
   */
  private int yycolumn;

  /** 
   * zzAtBOL == true <=> the scanner is currently at the beginning of a line
   */
  private boolean zzAtBOL = true;

  /** zzAtEOF == true <=> the scanner is at the EOF */
  private boolean zzAtEOF;

  /** denotes if the user-EOF-code has already been executed */
  private boolean zzEOFDone;
  
  /** 
   * The number of occupied positions in zzBuffer beyond zzEndRead.
   * When a lead/high surrogate has been read from the input stream
   * into the final zzBuffer position, this will have a value of 1;
   * otherwise, it will have a value of 0.
   */
  private int zzFinalHighSurrogate = 0;


  /**
   * Creates a new scanner
   *
   * @param   in  the java.io.Reader to read input from.
   */
  public Lexico(java.io.Reader in) {
    this.zzReader = in;
  }


  /** 
   * Unpacks the compressed character translation table.
   *
   * @param packed   the packed character translation table
   * @return         the unpacked character translation table
   */
  private static char [] zzUnpackCMap(String packed) {
    char [] map = new char[0x110000];
    int i = 0;  /* index in packed string  */
    int j = 0;  /* index in unpacked array */
    while (i < 256) {
      int  count = packed.charAt(i++);
      char value = packed.charAt(i++);
      do map[j++] = value; while (--count > 0);
    }
    return map;
  }


  /**
   * Refills the input buffer.
   *
   * @return      <code>false</code>, iff there was new input.
   * 
   * @exception   java.io.IOException  if any I/O-Error occurs
   */
  private boolean zzRefill() throws java.io.IOException {

    /* first: make room (if you can) */
    if (zzStartRead > 0) {
      zzEndRead += zzFinalHighSurrogate;
      zzFinalHighSurrogate = 0;
      System.arraycopy(zzBuffer, zzStartRead,
                       zzBuffer, 0,
                       zzEndRead-zzStartRead);

      /* translate stored positions */
      zzEndRead-= zzStartRead;
      zzCurrentPos-= zzStartRead;
      zzMarkedPos-= zzStartRead;
      zzStartRead = 0;
    }

    /* is the buffer big enough? */
    if (zzCurrentPos >= zzBuffer.length - zzFinalHighSurrogate) {
      /* if not: blow it up */
      char newBuffer[] = new char[zzBuffer.length*2];
      System.arraycopy(zzBuffer, 0, newBuffer, 0, zzBuffer.length);
      zzBuffer = newBuffer;
      zzEndRead += zzFinalHighSurrogate;
      zzFinalHighSurrogate = 0;
    }

    /* fill the buffer with new input */
    int requested = zzBuffer.length - zzEndRead;
    int numRead = zzReader.read(zzBuffer, zzEndRead, requested);

    /* not supposed to occur according to specification of java.io.Reader */
    if (numRead == 0) {
      throw new java.io.IOException("Reader returned 0 characters. See JFlex examples for workaround.");
    }
    if (numRead > 0) {
      zzEndRead += numRead;
      /* If numRead == requested, we might have requested to few chars to
         encode a full Unicode character. We assume that a Reader would
         otherwise never return half characters. */
      if (numRead == requested) {
        if (Character.isHighSurrogate(zzBuffer[zzEndRead - 1])) {
          --zzEndRead;
          zzFinalHighSurrogate = 1;
        }
      }
      /* potentially more input available */
      return false;
    }

    /* numRead < 0 ==> end of stream */
    return true;
  }

    
  /**
   * Closes the input stream.
   */
  public final void yyclose() throws java.io.IOException {
    zzAtEOF = true;            /* indicate end of file */
    zzEndRead = zzStartRead;  /* invalidate buffer    */

    if (zzReader != null)
      zzReader.close();
  }


  /**
   * Resets the scanner to read from a new input stream.
   * Does not close the old reader.
   *
   * All internal variables are reset, the old input stream 
   * <b>cannot</b> be reused (internal buffer is discarded and lost).
   * Lexical state is set to <tt>ZZ_INITIAL</tt>.
   *
   * Internal scan buffer is resized down to its initial length, if it has grown.
   *
   * @param reader   the new input stream 
   */
  public final void yyreset(java.io.Reader reader) {
    zzReader = reader;
    zzAtBOL  = true;
    zzAtEOF  = false;
    zzEOFDone = false;
    zzEndRead = zzStartRead = 0;
    zzCurrentPos = zzMarkedPos = 0;
    zzFinalHighSurrogate = 0;
    yyline = yychar = yycolumn = 0;
    zzLexicalState = YYINITIAL;
    if (zzBuffer.length > ZZ_BUFFERSIZE)
      zzBuffer = new char[ZZ_BUFFERSIZE];
  }


  /**
   * Returns the current lexical state.
   */
  public final int yystate() {
    return zzLexicalState;
  }


  /**
   * Enters a new lexical state
   *
   * @param newState the new lexical state
   */
  public final void yybegin(int newState) {
    zzLexicalState = newState;
  }


  /**
   * Returns the text matched by the current regular expression.
   */
  public final String yytext() {
    return new String( zzBuffer, zzStartRead, zzMarkedPos-zzStartRead );
  }


  /**
   * Returns the character at position <tt>pos</tt> from the 
   * matched text. 
   * 
   * It is equivalent to yytext().charAt(pos), but faster
   *
   * @param pos the position of the character to fetch. 
   *            A value from 0 to yylength()-1.
   *
   * @return the character at position pos
   */
  public final char yycharat(int pos) {
    return zzBuffer[zzStartRead+pos];
  }


  /**
   * Returns the length of the matched text region.
   */
  public final int yylength() {
    return zzMarkedPos-zzStartRead;
  }


  /**
   * Reports an error that occured while scanning.
   *
   * In a wellformed scanner (no or only correct usage of 
   * yypushback(int) and a match-all fallback rule) this method 
   * will only be called with things that "Can't Possibly Happen".
   * If this method is called, something is seriously wrong
   * (e.g. a JFlex bug producing a faulty scanner etc.).
   *
   * Usual syntax/scanner level error handling should be done
   * in error fallback rules.
   *
   * @param   errorCode  the code of the errormessage to display
   */
  private void zzScanError(int errorCode) {
    String message;
    try {
      message = ZZ_ERROR_MSG[errorCode];
    }
    catch (ArrayIndexOutOfBoundsException e) {
      message = ZZ_ERROR_MSG[ZZ_UNKNOWN_ERROR];
    }

    throw new Error(message);
  } 


  /**
   * Pushes the specified amount of characters back into the input stream.
   *
   * They will be read again by then next call of the scanning method
   *
   * @param number  the number of characters to be read again.
   *                This number must not be greater than yylength()!
   */
  public void yypushback(int number)  {
    if ( number > yylength() )
      zzScanError(ZZ_PUSHBACK_2BIG);

    zzMarkedPos -= number;
  }


  /**
   * Contains user EOF-code, which will be executed exactly once,
   * when the end of file is reached
   */
  private void zzDoEOF() throws java.io.IOException {
    if (!zzEOFDone) {
      zzEOFDone = true;
      yyclose();
    }
  }


  /**
   * Resumes scanning until the next regular expression is matched,
   * the end of input is encountered or an I/O-Error occurs.
   *
   * @return      the next token
   * @exception   java.io.IOException  if any I/O-Error occurs
   */
  public java_cup.runtime.Symbol next_token() throws java.io.IOException {
    int zzInput;
    int zzAction;

    // cached fields:
    int zzCurrentPosL;
    int zzMarkedPosL;
    int zzEndReadL = zzEndRead;
    char [] zzBufferL = zzBuffer;
    char [] zzCMapL = ZZ_CMAP;

    int [] zzTransL = ZZ_TRANS;
    int [] zzRowMapL = ZZ_ROWMAP;
    int [] zzAttrL = ZZ_ATTRIBUTE;

    while (true) {
      zzMarkedPosL = zzMarkedPos;

      yychar+= zzMarkedPosL-zzStartRead;

      boolean zzR = false;
      int zzCh;
      int zzCharCount;
      for (zzCurrentPosL = zzStartRead  ;
           zzCurrentPosL < zzMarkedPosL ;
           zzCurrentPosL += zzCharCount ) {
        zzCh = Character.codePointAt(zzBufferL, zzCurrentPosL, zzMarkedPosL);
        zzCharCount = Character.charCount(zzCh);
        switch (zzCh) {
        case '\u000B':
        case '\u000C':
        case '\u0085':
        case '\u2028':
        case '\u2029':
          yyline++;
          yycolumn = 0;
          zzR = false;
          break;
        case '\r':
          yyline++;
          yycolumn = 0;
          zzR = true;
          break;
        case '\n':
          if (zzR)
            zzR = false;
          else {
            yyline++;
            yycolumn = 0;
          }
          break;
        default:
          zzR = false;
          yycolumn += zzCharCount;
        }
      }

      if (zzR) {
        // peek one character ahead if it is \n (if we have counted one line too much)
        boolean zzPeek;
        if (zzMarkedPosL < zzEndReadL)
          zzPeek = zzBufferL[zzMarkedPosL] == '\n';
        else if (zzAtEOF)
          zzPeek = false;
        else {
          boolean eof = zzRefill();
          zzEndReadL = zzEndRead;
          zzMarkedPosL = zzMarkedPos;
          zzBufferL = zzBuffer;
          if (eof) 
            zzPeek = false;
          else 
            zzPeek = zzBufferL[zzMarkedPosL] == '\n';
        }
        if (zzPeek) yyline--;
      }
      zzAction = -1;

      zzCurrentPosL = zzCurrentPos = zzStartRead = zzMarkedPosL;
  
      zzState = ZZ_LEXSTATE[zzLexicalState];

      // set up zzAction for empty match case:
      int zzAttributes = zzAttrL[zzState];
      if ( (zzAttributes & 1) == 1 ) {
        zzAction = zzState;
      }


      zzForAction: {
        while (true) {
    
          if (zzCurrentPosL < zzEndReadL) {
            zzInput = Character.codePointAt(zzBufferL, zzCurrentPosL, zzEndReadL);
            zzCurrentPosL += Character.charCount(zzInput);
          }
          else if (zzAtEOF) {
            zzInput = YYEOF;
            break zzForAction;
          }
          else {
            // store back cached positions
            zzCurrentPos  = zzCurrentPosL;
            zzMarkedPos   = zzMarkedPosL;
            boolean eof = zzRefill();
            // get translated positions and possibly new buffer
            zzCurrentPosL  = zzCurrentPos;
            zzMarkedPosL   = zzMarkedPos;
            zzBufferL      = zzBuffer;
            zzEndReadL     = zzEndRead;
            if (eof) {
              zzInput = YYEOF;
              break zzForAction;
            }
            else {
              zzInput = Character.codePointAt(zzBufferL, zzCurrentPosL, zzEndReadL);
              zzCurrentPosL += Character.charCount(zzInput);
            }
          }
          int zzNext = zzTransL[ zzRowMapL[zzState] + zzCMapL[zzInput] ];
          if (zzNext == -1) break zzForAction;
          zzState = zzNext;

          zzAttributes = zzAttrL[zzState];
          if ( (zzAttributes & 1) == 1 ) {
            zzAction = zzState;
            zzMarkedPosL = zzCurrentPosL;
            if ( (zzAttributes & 8) == 8 ) break zzForAction;
          }

        }
      }

      // store back cached position
      zzMarkedPos = zzMarkedPosL;

      if (zzInput == YYEOF && zzStartRead == zzCurrentPos) {
        zzAtEOF = true;
            zzDoEOF();
          { return new java_cup.runtime.Symbol(sym.EOF); }
      }
      else {
        switch (zzAction < 0 ? zzAction : ZZ_ACTION[zzAction]) {
          case 1: 
            { System.out.println("error lexico en la fila "+yyline +" y en la columna " + yycolumn);  /*imprime que error */
Sintactico.error="error lexico en la fila "+yyline +" y en la columna " + yycolumn;
            }
          case 64: break;
          case 2: 
            { return new Symbol(sym.IDENTIFICADOR,     yyline, yycolumn, yytext());
            }
          case 65: break;
          case 3: 
            { return new Symbol(sym.DIGITO,     yyline, yycolumn, yytext());
            }
          case 66: break;
          case 4: 
            { return new Symbol(sym.INVERS,     yyline, yycolumn, yytext());
            }
          case 67: break;
          case 5: 
            { return new Symbol(sym.MENOS,    yyline, yycolumn, yytext());
            }
          case 68: break;
          case 6: 
            { return new Symbol(sym.PUNTO,    yyline, yycolumn, yytext());
            }
          case 69: break;
          case 7: 
            { /*no hace nada, aumenta una columna*/
            }
          case 70: break;
          case 8: 
            { return new Symbol(sym.APOSTROFE,     yyline, yycolumn, yytext());
            }
          case 71: break;
          case 9: 
            { return new Symbol(sym.NOT,     yyline, yycolumn, yytext());
            }
          case 72: break;
          case 10: 
            { return new Symbol(sym.MENOR,     yyline, yycolumn, yytext());
            }
          case 73: break;
          case 11: 
            { return new Symbol(sym.MAYOR,     yyline, yycolumn, yytext());
            }
          case 74: break;
          case 12: 
            { return new Symbol(sym.IGUAL,     yyline, yycolumn, yytext());
            }
          case 75: break;
          case 13: 
            { return new Symbol(sym.MAS,    yyline, yycolumn, yytext());
            }
          case 76: break;
          case 14: 
            { return new Symbol(sym.DIVISION,    yyline, yycolumn, yytext());
            }
          case 77: break;
          case 15: 
            { return new Symbol(sym.MULTIPLICACION,    yyline, yycolumn, yytext());
            }
          case 78: break;
          case 16: 
            { return new Symbol(sym.COMA,    yyline, yycolumn, yytext());
            }
          case 79: break;
          case 17: 
            { return new Symbol(sym.CORA,      yyline, yycolumn, yytext());
            }
          case 80: break;
          case 18: 
            { return new Symbol(sym.CORC,     yyline, yycolumn, yytext());
            }
          case 81: break;
          case 19: 
            { return new Symbol(sym.PARAB,      yyline, yycolumn, yytext());
            }
          case 82: break;
          case 20: 
            { return new Symbol(sym.PARC,     yyline, yycolumn, yytext());
            }
          case 83: break;
          case 21: 
            { return new Symbol(sym.PUNTOCOMA,     yyline, yycolumn, yytext());
            }
          case 84: break;
          case 22: 
            { return new Symbol(sym.DOSPUNTOS,     yyline, yycolumn, yytext());
            }
          case 85: break;
          case 23: 
            { return new Symbol(sym.LLAVEA,     yyline, yycolumn, yytext());
            }
          case 86: break;
          case 24: 
            { return new Symbol(sym.LLAVEC,     yyline, yycolumn, yytext());
            }
          case 87: break;
          case 25: 
            { return new Symbol(sym.POT,     yyline, yycolumn, yytext());
            }
          case 88: break;
          case 26: 
            { return new Symbol(sym.PORCENTAJE,     yyline, yycolumn, yytext());
            }
          case 89: break;
          case 27: 
            { return new Symbol(sym.DIFERENCIA,     yyline, yycolumn, yytext());
            }
          case 90: break;
          case 28: 
            { return new Symbol(sym.DECREMENTO,     yyline, yycolumn, yytext());
            }
          case 91: break;
          case 29: 
            { return new Symbol(sym.CADENA,     yyline, yycolumn, yytext());
            }
          case 92: break;
          case 30: 
            { return new Symbol(sym.COMENTARIO,     yyline, yycolumn, yytext());
            }
          case 93: break;
          case 31: 
            { return new Symbol(sym.DISTINTO,     yyline, yycolumn, yytext());
            }
          case 94: break;
          case 32: 
            { return new Symbol(sym.XOR,     yyline, yycolumn, yytext());
            }
          case 95: break;
          case 33: 
            { return new Symbol(sym.MENORIGUAL,yyline, yycolumn, yytext());
            }
          case 96: break;
          case 34: 
            { return new Symbol(sym.MAYORIGUAL,yyline, yycolumn, yytext());
            }
          case 97: break;
          case 35: 
            { return new Symbol(sym.IGUALIGUAL,     yyline, yycolumn, yytext());
            }
          case 98: break;
          case 36: 
            { return new Symbol(sym.INCREMENTO,     yyline, yycolumn, yytext());
            }
          case 99: break;
          case 37: 
            { return new Symbol(sym.AND,     yyline, yycolumn, yytext());
            }
          case 100: break;
          case 38: 
            { return new Symbol(sym.OR,     yyline, yycolumn, yytext());
            }
          case 101: break;
          case 39: 
            { return new Symbol(sym.SI,    yyline, yycolumn, yytext());
            }
          case 102: break;
          case 40: 
            { return new Symbol(sym.DECIMAL,     yyline, yycolumn, yytext());
            }
          case 103: break;
          case 41: 
            { return new Symbol(sym.ID,     yyline, yycolumn, yytext());
            }
          case 104: break;
          case 42: 
            { return new Symbol(sym.INT,    yyline, yycolumn, yytext());
            }
          case 105: break;
          case 43: 
            { return new Symbol(sym.BOOL,    yyline, yycolumn, yytext());
            }
          case 106: break;
          case 44: 
            { return new Symbol(sym.CHAR,    yyline, yycolumn, yytext());
            }
          case 107: break;
          case 45: 
            { return new Symbol(sym.SINO,    yyline, yycolumn, yytext());
            }
          case 108: break;
          case 46: 
            { return new Symbol(sym.PARA,    yyline, yycolumn, yytext());
            }
          case 109: break;
          case 47: 
            { return new Symbol(sym.VACIO,    yyline, yycolumn, yytext());
            }
          case 110: break;
          case 48: 
            { return new Symbol(sym.HASTA,    yyline, yycolumn, yytext());
            }
          case 111: break;
          case 49: 
            { return new Symbol(sym.DOUBLE,    yyline, yycolumn, yytext());
            }
          case 112: break;
          case 50: 
            { return new Symbol(sym.STRING,    yyline, yycolumn, yytext());
            }
          case 113: break;
          case 51: 
            { return new Symbol(sym.DETENER,    yyline, yycolumn, yytext());
            }
          case 114: break;
          case 52: 
            { return new Symbol(sym.DEFECTO,    yyline, yycolumn, yytext());
            }
          case 115: break;
          case 53: 
            { return new Symbol(sym.DEFINIR, yyline, yycolumn, yytext());
            }
          case 116: break;
          case 54: 
            { return new Symbol(sym.RETORNO,    yyline, yycolumn, yytext());
            }
          case 117: break;
          case 55: 
            { return new Symbol(sym.MOSTRAR,    yyline, yycolumn, yytext());
            }
          case 118: break;
          case 56: 
            { return new Symbol(sym.IMPORTAR, yyline, yycolumn, yytext());
            }
          case 119: break;
          case 57: 
            { return new Symbol(sym.MIENTRAS,    yyline, yycolumn, yytext());
            }
          case 120: break;
          case 58: 
            { return new Symbol(sym.DIBUJARTS,    yyline, yycolumn, yytext());
            }
          case 121: break;
          case 59: 
            { return new Symbol(sym.CONTINUAR,    yyline, yycolumn, yytext());
            }
          case 122: break;
          case 60: 
            { return new Symbol(sym.PRINCIPAL,    yyline, yycolumn, yytext());
            }
          case 123: break;
          case 61: 
            { return new Symbol(sym.DIBUJARAST,    yyline, yycolumn, yytext());
            }
          case 124: break;
          case 62: 
            { return new Symbol(sym.DIBUJAREXP,    yyline, yycolumn, yytext());
            }
          case 125: break;
          case 63: 
            { return new Symbol(sym.SELECCIONA,    yyline, yycolumn, yytext());
            }
          case 126: break;
          default:
            zzScanError(ZZ_NO_MATCH);
        }
      }
    }
  }


}
