
::-------------------------------------------------
:: * Initialize *
del /s /ah /f *.suo
del /s /f *.user
del /s /f *.cache
del /s /f *.keep
del /s /ah StyleCop.Cache

rd /s /q bin obj packages 

del dirs.txt
dir /s /b /ad bin > dirs.txt
dir /s /b /ad obj >> dirs.txt
dir /s /b /ad packages >> dirs.txt

for /f "delims=;" %%i in (dirs.txt) DO rd /s /q "%%i"
del dirs.txt
