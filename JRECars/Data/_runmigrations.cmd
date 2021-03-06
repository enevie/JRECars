@echo off


rem ********************************************************************************
rem Do not edit this file.  The connection string is passed in as the first parameter
rem For easier use, create a file named _runmigrations.cmd outside of the the repo.
rem Use the template file in this folder as an example.
rem ********************************************************************************


cls

echo *******************************************************************************
echo  Migration Runner
echo *******************************************************************************

set MIGRATOR_CONSOLE_PATH=..\packages\FluentMigrator.1.3.0.0\tools\Migrate.exe
set CONNECTION_STRING=%~1
set MIGRATIONS_DLL_PATH=.\bin\Debug\JREMotorsDB.Data.Migrations.dll

echo.
echo.

echo  Connection String:  %CONNECTION_STRING%
echo  Migrations DLL:     %MIGRATIONS_DLL_PATH%

echo.
echo.

echo Starting migrations in 5 seconds, or press any key to start now...

::timeout /t:5 > nul

echo.
echo.
echo.

%MIGRATOR_CONSOLE_PATH% --provider sqlserver2012 --connection "%CONNECTION_STRING%" --assembly "%MIGRATIONS_DLL_PATH%" --task migrate --output --outputFilename "%TEMP%\TravelTabMigration.SQL"

echo.
echo.
echo.

echo All Done.  Exiting in 5 seconds or press any key to exit now...

::timeout /t:5 > nul

set MIGRATOR_CONSOLE_PATH=
set CONNECTION_STRING=
set MIGRATIONS_DLL_PATH=
echo.
echo.