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
USE DETAIL IN 1 ALIAS DET
USE INHERIT IN 2 ALIAS INH
SELECT INH
SET ORDER TO TAG RECno
SELECT DET
SET RELATION TO RECno INTO INH
SELECT INH
DO GETINPUT IN WINDOW
rec=0
@ 2,10 say "Enter Record No. To Display" font "ARIAL",12 style "bt"
@ 2,65 get rec PICTURE "99999" font "ARIAL",12 style "b"
read
RELE WIND W2
DO DP IN WINDOW
IF dp='P'
   RELEASE WINDOW w1
   DO print IN inh1
ELSE
   DO DISP IN inh1
ENDIF

PROCEDURE DISP
DEAC WIND ALL
RELE WIND ALL
CLEAR
locate for recno=rec 
if .not. found()
wait window "Record Not Found"
else
IF ISCOLOR()
DEFINE WINDOW WARIS AT 0,0 SIZE 30-2,125-2;
   SHADOW PANEL MINIMIZE FLOAT GROW;
   TITLE "** INFORMATION FORM THE USER **";
   FOOTER "DESIGNED BY: MUHAMMAD REHAN QADRI";
   FONT "MS SANS SERIF",8;
   COLOR RGB (,,255,192,192,192);
   FILL FILE SYS(5)+SYS(2003)+"\MARB009.BMP"
ELSE
DEFINE WINDOW WARIS AT 0,0 SIZE 30-2,125-2;
   SHADOW PANEL MINIMIZE FLOAT GROW;
   TITLE "** INFORMATION FORM THE USER **";
   FOOTER "DESIGNED BY: MUHAMMAD REHAN QADRI";
   FONT "MS SANS SERIF",8;
   COLOR RGB (,,255,192,192,192)
ENDIF
ACTIVATE WINDOW WARIS
MOVE WINDOW WARIS CENTER
SELECT INH
LOCATE FOR RECNO=REC
CLEAR
@ 0,5 SAY "REC# :" FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR B+
@ 0,15 SAY REC FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR G*
@ 0,30 SAY "NAME OF THE LATE :" FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR B+
@ 0,65 SAY NAME FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR G*
@ 1.5,5 SAY "AMMOUNT: " FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR B+
@ 1.5,25 SAY AMOUNT FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR G*
abc=amount
@ 1.5,45 SAY "MAKHRAJ: " FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR B+
@ 1.5,65 SAY MAsala FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR G*
@ 1.5,80 SAY "EXPIRATION: " FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR B+
@ 1.5,106 SAY DATE FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR G*
@ 4.5,0 SAY PADC( "EXTRACTION TYPE:",WCOLS("WARIS")-10 ) FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR R+
LOCATE FOR RECNO=REC
@ 4.5,0 SAY PADC( INH.MAK_TYPE,WCOLS("WARIS")+70 ) FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR R+
@ 3,5 SAY "EXTRACTION VALUE:" FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR R+
@ 3,35 SAY amount/MAsala FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR R+
SELECT DET
CALC SUM(AMMOUNT) FOR RECNO=REC TO DIFF
DIFF=abc-DIFF
@ 3,75 SAY "DIFFERENCE:" FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR R+
@ 3,95 SAY DIFF FONT "TIMES NEW ROMAN",12 STYLE "BT" COLOR R+
DEFINE WINDOW WARIS1 IN WINDOW WARIS AT 6,0 SIZE 30-10,125-4;
   SHADOW MINIMIZE FLOAT GROW;
   TITLE "FINAL RESULT FOR THE SHARE AND AMMOUNT OF EACH RELATIVE";
   FOOTER "DESIGNED BY: MUHAMMAD REHAN QADRI";
   FONT "MS SANS SERIF",8;
   COLOR RGB (,,255,192,192,192)
ACTIVATE WIND WARIS1
set message to "Press Escape To Continue"
BROWS FIELDS NAME,RELATION,SHARE,AMMOUNT WINDOW WARIS1 TITLE "FINAL RESULT" NOEDIT NODELET FONT "TIMES NEW ROMAN",12 STYLE "BT" WIDTH 26 COLOR SCHEME 8 FOR RECNO=REC
endif
DEAC WIND ALL
RELE WIND ALL
SET MESSAGE TO

PROCEDURE PRINT
CLOSE DATABASES 
SELECT B.RECNO,a.NAME AS LATE_NAME,A.DATE,A.AMOUNT AS TOT_AMOUNT,;
A.MASALA AS MAKHRAJ,(A.AMOUNT/A.MASALA) AS EXTRACTION_VALUE,A.MAK_TYPE,;
b.SHARE,B.AMMOUNT,b.NAME as rel_name,B.RELATION ;
	FROM INHERIT a, DETAIL b ;
	WHERE a.RECNO = b.RECNO INTO TABLE INH_CHECK
CLEAR
locate for recno=rec
if found()
REPORT FORM INHERIT PREV FOR RECNO=REC
REPORT FORM INHERIT TO PRINT PROMPT FOR RECNO=REC
else
wait window "Record Not Found"
endif