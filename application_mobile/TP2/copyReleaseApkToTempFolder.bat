SET destination=c:\temp\release.apk
SET source=.\Tp2\Tp2.Android\bin\Release\TP2.Android-Signed.apk

del %destination%
copy  %source% %destination%