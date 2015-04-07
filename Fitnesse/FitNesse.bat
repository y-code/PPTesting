@echo off

cd /d %~dp0
java -cp "lib\fitnesse-standalone.jar" fitnesseMain.FitNesseMain -p 80 -d . -r FitNesseRoot %*
pause
