CLEAR
DEAC WIND ALL
RELE WIND ALL
SET STAT BAR On
SET SAFETY OFF
SET TALK OFF
SET CURSOR ON
SET CENTURY ON
SET BLINK OFF
SET DATE BRITISH
CLOSE ALL
CLEAR
CLOSE DATABASES 

SELECT B.RECNO,a.NAME AS LATE_NAME,A.DATE,A.AMOUNT AS TOT_AMOUNT,;
A.MASALA AS MAKHRAJ,(A.AMOUNT/A.MASALA) AS EXTRACTION_VALUE,A.MAK_TYPE,;
b.SHARE,B.AMMOUNT,b.NAME as rel_name,B.RELATION ;
	FROM INHERIT a, DETAIL b ;
	WHERE a.RECNO = b.RECNO;
	INTO TABLE INH_CHEC

DO DP IN WINDOW
IF dp='P'
   RELEASE WINDOW w1
   DO print IN inh2
ELSE
   DO DISP IN inh2
ENDIF

PROCEDURE DISP
DEAC WIND ALL
RELE WIND ALL
CLEAR
DEFINE WINDOW WARIS AT 0,0 SIZE 33,140;
   SHADOW PANEL MINIMIZE FLOAT GROW;
   TITLE "** INHERITANCE CASES DISPLAY SHEET **";
   FOOTER "DESIGNED BY: MUHAMMAD REHAN QADRI";
   FONT "ARIAL",8
ACTIVATE WINDOW WARIS
MOVE WINDOW WARIS CENTER

set message to "Press Escape To Continue"
BROWS TITLE "FINAL RESULT" NOEDIT NODELET NOAPPEND

SET CURSOR OFF
DEAC WIND ALL
RELE WIND ALL
CLEAR
CLOS ALL
SET MESSAGE TO

PROCEDURE PRINT
CLEAR
REPORT FORM inh_all PREV
REPORT FORM inh_all TO PRINT PROMPT
