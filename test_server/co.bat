@echo off
for %%i in (tcp*.erl) do erlc -o ../ebin %%i
pause