for /f "tokens=*" %%a in ('dir obj /b /ad /s ^|sort') do rd "%%a" /s/q
for /f "tokens=*" %%a in ('dir bin /b /ad /s ^|sort') do rd "%%a" /s/q

del *.pch /s /q
del *.ncb /s /q
del *.opt /s /q
del *.plg /s /q
del *.obj /s /q
REM del *.exe /s /q
del *.bsc /s /q
del *.bak /s /q
REM del *.pdb /s /q
del *.sql /s /q
REM del *.mdb /s /q
del *.lib /s /q
del *.exp /s /q
del *.ilk /s /q
del *.idb /s /q
del *.aps /s /q
del *.suo /s /q /a:h
del *.o /s /q
REM del *.user /s /q
