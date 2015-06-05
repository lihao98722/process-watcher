@setlocal enableextensions
@cd /d "%~dp0"
@echo off
echo 开始执行卸载
installutil /u WindowsService1.exe
echo 完成
pause