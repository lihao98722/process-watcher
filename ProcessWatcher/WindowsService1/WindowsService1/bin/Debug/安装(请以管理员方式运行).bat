@setlocal enableextensions
@cd /d "%~dp0"
@echo off
echo 开始执行安装
installutil.exe WindowsService1.exe
echo 完成
pause